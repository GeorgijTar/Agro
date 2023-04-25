using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.Warehouse;
using Agro.Dto.Warehouse;
using Agro.Interfaces.Base.Repositories;
using Agro.Services.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Decommissioning;
using Agro.WPF.Views.Windows.TMC;
using Microsoft.Win32;
using ReportExcelLib;
using ReportExcelLib.Tmc;

namespace Agro.WPF.ViewModels.TMC;
public class TmcSprViewModel : ViewModel
{
    private readonly ITmcSprRepository<Tmc> _tmcSprRepository;
    private TmcSprDto _selectedTmcSprDto = null!;
    public TmcSprDto SelectedTmcSprDto { get => _selectedTmcSprDto; set => Set(ref _selectedTmcSprDto, value); }

    private ObservableCollection<TmcSprDto> _tmcSprDtoCollection = null!;
    public ObservableCollection<TmcSprDto> TmcSprDtoCollection { get => _tmcSprDtoCollection; set => Set(ref _tmcSprDtoCollection, value); }

    private List<string> _storageLocations = null!;
    public List<string> StorageLocations { get => _storageLocations; set => Set(ref _storageLocations, value); }


    public TmcSprViewModel(ITmcSprRepository<Tmc> tmcSprRepository)
    {
        _tmcSprRepository = tmcSprRepository;
        Title = "Справочник остатков ТМЦ";
        LoadData();
    }

    private async void LoadData()
    {
        TmcSprDtoCollection = (await _tmcSprRepository.GetAllAsync())!;
        CollectionView = CollectionViewSource.GetDefaultView(TmcSprDtoCollection);
        StorageLocations = new();
        StorageLocations.Add("Все");
        var sl = TmcSprDtoCollection.Select(s => s.StorageLocation).Distinct();
        foreach (var stor in sl)
        {
            StorageLocations.Add(stor);
        }
    }


    #region Filter

    private ICollectionView? _collectionView;
    public ICollectionView? CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private int _idFilter;
    public int IdFilter
    {
        get => _idFilter;
        set
        {
            Set(ref _idFilter, value);
            CollectionView!.Filter = FilterById;
        }
    }

    private string _articleFilter = null!;
    public string ArticleFilter
    {
        get => _articleFilter;
        set
        {
            Set(ref _articleFilter, value);
            CollectionView!.Filter = FilterByArticle;
        }
    }

    private string _nameFilter = null!;
    public string NameFilter
    {
        get => _nameFilter;
        set
        {
            Set(ref _nameFilter, value);
            CollectionView!.Filter = FilterByName;
        }
    }


    private string _storageLocation = null!;

    public string StorageLocation
    {
        get => _storageLocation;
        set
        {
            Set(ref _storageLocation, value);
            CollectionView!.Filter = FilterBySL;
        }
    }

    private bool FilterBySL(object obj)
    {
        if (!string.IsNullOrEmpty(StorageLocation))
        {
            if (StorageLocation == "Все") return true;

            TmcSprDto? dto = obj as TmcSprDto;
            return dto!.StorageLocation.ToUpper().Contains(StorageLocation.ToUpper());
        }
        return true;
    }


    private bool FilterByName(object count)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            TmcSprDto? dto = count as TmcSprDto;
            return dto!.NameTmc.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }


    private bool FilterByArticle(object count)
    {
        if (!string.IsNullOrEmpty(ArticleFilter))
        {
            TmcSprDto? dto = count as TmcSprDto;
            if (dto!.Article != null!)
            {
                return dto!.Article.ToUpper().Contains(ArticleFilter.ToUpper());
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private bool FilterById(object count)
    {
        if (IdFilter != 0)
        {
            TmcSprDto? dto = count as TmcSprDto;
            return dto!.Id == IdFilter;
        }
        return true;
    }
    #endregion

    #region Commands

    #region DoubleСlick

    private ICommand? _doubleСlickCommand;

    public ICommand DoubleСlickCommand => _doubleСlickCommand
        ??= new RelayCommand(OnDoubleСlickExecuted, DoubleСlickCan);

    private bool DoubleСlickCan(object arg)
    {
        return SelectedTmcSprDto != null!;
    }

    private async void OnDoubleСlickExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is PositionDecommissioningTmcViewModel position)
            {
                position.Position.Tmc = (await _tmcSprRepository.GetTmcByIdAsync(SelectedTmcSprDto.Id))!;
                position.TmcSprDto = SelectedTmcSprDto;
                position.Position.Price = SelectedTmcSprDto.Price;
                position.Position.UnitOkei = (await _tmcSprRepository.GetUnitByIdAsync(SelectedTmcSprDto.IdUnit))!;
                position.Position.AccountingPlan =
                    (await _tmcSprRepository.GetAccountingByIdAsync(SelectedTmcSprDto.IdAccountingPlan))!;
                position.Position.StorageLocation =
                    (Application.Current.Properties["StorageLocations"] as IEnumerable<StorageLocation>)!.FirstOrDefault(
                        l => l.Id == SelectedTmcSprDto.IdStorageLocation)!;

            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }


    #endregion

    #region Refresh

    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }

    #endregion


    #region Excel

    private ICommand? _excelCommand;

    public ICommand ExcelCommand => _excelCommand
        ??= new RelayCommand(OnExcelExecuted, ExcelCan);

    private bool ExcelCan(object arg)
    {
        return TmcSprDtoCollection != null! && TmcSprDtoCollection.Count > 0;
    }

    private void OnExcelExecuted(object obj)
    {
        IEnumerable<TmcSprDto> coll = CollectionView!.Cast<TmcSprDto>();

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.DefaultExt = "*.xlsx";
        saveFileDialog.FileName = $"Остатки ТМЦ";
        saveFileDialog.Filter = "Microsoft Excel (*.xlsx)|*.xlsx";
        if (saveFileDialog.ShowDialog() == true)
        {
            SprTmcToExcel.ToExcel(coll, saveFileDialog.FileName);
        }

    }

    #endregion

    #region MovementTmc


    private ICommand? _movementTmcCommand;

    public ICommand MovementTmcCommand => _movementTmcCommand
        ??= new RelayCommand(OnMovementTmcExecuted, MovementTmcCan);

    private bool MovementTmcCan(object arg)
    {
        return SelectedTmcSprDto != null!;
        }

    private void OnMovementTmcExecuted(object obj)
    {
        var view = new MovementTmcView();
        var model = view.DataContext as MovementTmcViewModel;
        model!.TmcSprDto = SelectedTmcSprDto;
        model.Title = "Движение ТМЦ";
        view.ShowDialog();
    }


    #endregion
    #endregion


}
