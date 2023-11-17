
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Warehouse;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Agronomy;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Coming;
using Agro.WPF.ViewModels.Weight;
using Agro.WPF.Views.Windows.Agronomy;
using Agro.WPF.Views.Windows.TMC;

namespace Agro.WPF.ViewModels.TMC;
public class TmCsViewModel : ViewModel
{
    private readonly IBaseRepository<Tmc> _tmcRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private string _title = "Номенклатура. Материально производственные запасы (МПЗ)";
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Tmc> _tmcs = new();
    public ObservableCollection<Tmc> Tmcs { get => _tmcs; set => Set(ref _tmcs, value); }

    private Tmc _tmc = null!;
    public Tmc Tmc { get => _tmc; set => Set(ref _tmc, value); }


    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }


    private int _idFilter;
    public int IdFilter { get => _idFilter; set => Set(ref _idFilter, value); }


    private string _articleFilter = null!;
    public string ArticleFilter { get => _articleFilter; set => Set(ref _articleFilter, value); }


    private GroupDoc _groupFilter = null!;
    public GroupDoc GroupFilter { get => _groupFilter; set => Set(ref _groupFilter, value); }


    private IEnumerable<GroupDoc> _groups = null!;
    public IEnumerable<GroupDoc> Groups { get => _groups; set => Set(ref _groups, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    public object SenderModel { get; set; } = null!;


    public TmCsViewModel(IBaseRepository<Tmc> tmcRepository,
        IBaseRepository<Status> statusRepository,
        IBaseRepository<GroupDoc> groupRepository)
    {
        _tmcRepository = tmcRepository;
        _statusRepository = statusRepository;
        _groupRepository = groupRepository;
        LoadData();
        CollectionView = CollectionViewSource.GetDefaultView(Tmcs);
        this.PropertyChanged += ViewChanged;
    }

    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            default:
                break;
            case "NameFilter":
                CollectionView.Filter = FilterByName;
                break;
            case "IdFilter":
                CollectionView.Filter = FilterById;
                break;
            case "ArticleFilter":
                CollectionView.Filter = FilterByArticle;
                break;
            case "GroupFilter":
                CollectionView.Filter = FilterByGroup;
                break;
        }
    }

    #region Filteres

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            Tmc? dto = obj as Tmc;
            return dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private bool FilterById(object obj)
    {
        if (IdFilter != 0)
        {
            Tmc? dto = obj as Tmc;
            return dto!.Id == IdFilter;
        }
        return true;
    }
    private bool FilterByArticle(object obj)
    {
        if (!string.IsNullOrEmpty(ArticleFilter))
        {
            Tmc? dto = obj as Tmc;
            return dto!.ArticleNumber!.ToUpper().Contains(ArticleFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByGroup(object obj)
    {
        if (GroupFilter != null!)
        {
            Tmc? dto = obj as Tmc;
            return dto!.Group.Name.ToUpper().Contains(GroupFilter.Name.ToUpper());
        }
        return true;
    }

    #endregion

    private async void LoadData()
    {
        Tmcs.Clear();
        var tmcs = await _tmcRepository.GetAllAsync();
        tmcs = tmcs!.Where(t => t.Status!.Id != 6).ToArray();
        foreach (var tmc in tmcs)
        {
            Tmcs.Add(tmc);
        }
        var groups = await _groupRepository.GetAllAsync();
        Groups = groups!.Where(g => g.TypeApplication == "МПЗ").OrderBy(g => g.Name).ToArray();
    }


    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new TmcView();
        var model = view.DataContext as TmcViewModel;
        model!.Title = "Создание нового МПЗ";
        model.SenderModel = this;
        model.Tmc = new();
        view.DataContext = model;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Tmc != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new TmcView();
        var model = view.DataContext as TmcViewModel;
        model!.Title = "Редактирование МПЗ";
        model.SenderModel = this;
        model.Tmc = Tmc;
        view.DataContext = model;
        view.Show();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanEditExecuted);

    private async void OnDeleteExecuted(object obj)
    {
        var result =
            MessageBox.Show(
                $"Вы действительно хотите удалит МПЗ:{Environment.NewLine} " +
                $"{Tmc.Name}",
                "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Tmc.Status = await _statusRepository.GetByIdAsync(6);
            await _tmcRepository.UpdateAsync(Tmc);
            Tmcs.Remove(Tmc);
            Tmc = null!;
        }
    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }


    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, CanEditExecuted);

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is DriverViewModel driverViewModel)
            {

            }
            if (SenderModel is ComingTmcPositionViewModel positionViewModel)
            {
                positionViewModel.ComingTmcPosition.Tmc = Tmc;
                positionViewModel.ComingTmcPosition.UnitOkei = Tmc.Unit;
                if (Tmc.RulesAccountings!.Count == 1)
                {
                    var rulesAccounting = Tmc.RulesAccountings[0];
                    positionViewModel.ComingTmcPosition.AccountingAccount = rulesAccounting.AccountingPlan;
                    positionViewModel.ComingTmcPosition.AccountingAccountNds = rulesAccounting.AccountingPlanNds!;
                    positionViewModel.ComingTmcPosition.AccountingMethodNds = rulesAccounting.AccountingMethodNds;
                }
            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }


    }

    private ICommand? _showFieldsCommand;

    public ICommand ShowFieldsCommand => _showFieldsCommand
        ??= new RelayCommand(OnShowFieldsExecuted);

    private void OnShowFieldsExecuted(object obj)
    {
        var view = new FieldsView();
        var mod = view.DataContext as FieldsViewModel;
        mod!.Title = "Выбирите поле";
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }


    #endregion
}
