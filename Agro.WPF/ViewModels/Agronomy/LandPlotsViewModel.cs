using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Agronomy;
using Microsoft.Win32;
using ReportExcelLib;
using System;

namespace Agro.WPF.ViewModels.Agronomy;

public class LandPlotsViewModel : ViewModel
{
    private readonly IBaseRepository<LandPlot> _landPlotRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<LandPlot> _landPlots = new();
    public ObservableCollection<LandPlot> LandPlots { get => _landPlots; set => Set(ref _landPlots, value); }


    private LandPlot _landPlot = null!;
    public LandPlot LandPlot { get => _landPlot; set => Set(ref _landPlot, value); }


    private object _senderModel = null!;
    public object SenderModel { get => _senderModel; set => Set(ref _senderModel, value); } 


    public LandPlotsViewModel(
        IBaseRepository<LandPlot> landPlotRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<TypeDoc> typeRepository)
    {
        _landPlotRepository = landPlotRepository;
        _statusRepository = statusRepository;
        _typeRepository = typeRepository;
        Title = "Реестр земельных участков";
        LoadLandPlots();
    }

    private async void LoadLandPlots()
    {
        LandPlots.Clear();
        var lps = await _landPlotRepository.GetAllAsync();
        lps = lps!.Where(l => l.Status.Id != 6).ToArray();
        foreach (var lp in lps)
        {
            LandPlots.Add(lp);
        }
    }

    #region Command

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        LandPlotView view = new();
        var model = view.DataContext as LandPlotViewModel;
        model!.SenderModel = this;
        model.LandPlot = new();
        model.Title = "Добавление нового земельного участка";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return LandPlot != null!;
    }

    private void OnEditExecuted(object obj)
    {
        LandPlotView view = new();
        var model = view.DataContext as LandPlotViewModel;
        model!.SenderModel = this;
        model.LandPlot = LandPlot;
        model.Title = "Редактирование земельного участка";
        view.DataContext = model;
        view.ShowDialog();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanDeleteExecuted);

    private bool CanDeleteExecuted(object arg)
    {
        return LandPlot != null!;
    }

    private async void OnDeleteExecuted(object obj)
    {
        var rezalt = MessageBox.Show($"Вы действительно хотите удалить: {LandPlot.Number} {LandPlot.Area} кв.м.",
            "Редактор", MessageBoxButton.YesNo);
        if (rezalt == MessageBoxResult.Yes)
        {
            LandPlot.Status = await _statusRepository.GetByIdAsync(7);
            await _landPlotRepository.UpdateAsync(LandPlot);
            LandPlot = null!;
        }

    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadLandPlots();
    }


    private ICommand? _loadCommand;

    public ICommand LoadCommand => _loadCommand
        ??= new RelayCommand(OnLoadExecuted);

    private async void OnLoadExecuted(object obj)
    {
       List<LandPlot> landPlots = new List<LandPlot>();
       var filePath = string.Empty;
       OpenFileDialog openFileDialog = new()
       {
           InitialDirectory = "c:\\",
           Filter = "Excel (*.exlx)|*.xlsx|Excel(*.exl)|*.xls|All files (*.*)|*.*",
           FilterIndex = 0,
           RestoreDirectory = false
       };
       if (openFileDialog.ShowDialog() == true)
       {
           landPlots = LoadLandPlot.Get(openFileDialog.FileName);
           foreach (var lp in landPlots)
           {
               var lens = await _landPlotRepository.GetAllAsync();
               var len = lens.Where(l=>l.Number==lp.Number);
               if (len.Any()) continue;
               lp.Status = await _statusRepository.GetByIdAsync(5);
               lp.Type = await _typeRepository.GetByIdAsync(13);
               var landP = await _landPlotRepository.SaveAsync(lp);
               LandPlots.Add(landP);
           }
       }

    }

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted);

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is FieldViewModel model)
            {
                model.Field.LandPlots!.Add(LandPlot);

                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    
    #endregion
}
