
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Kassa;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;

public class PeoplsViewModel : ViewModel
{
    private readonly IBaseRepository<People> _peopleRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    public PeoplsViewModel(IBaseRepository<People> peopleRepository, IBaseRepository<Status> statusRepository)
    {
        _peopleRepository = peopleRepository;
        _statusRepository = statusRepository;

        Title = "Физические лица";
        LoadData();
        CollectionView = CollectionViewSource.GetDefaultView(Peoples);
        this.PropertyChanged += Filter;
    }

   

    private async void LoadData()
    {
        Peoples.Clear();
        var peoples = await _peopleRepository.GetAllAsync();
        peoples = peoples!.Where(x => x.Status!.Id == 5);
        foreach (var people in peoples)
        {
            Peoples.Add(people);
        }
    }

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<People> _peoples = new();
    public ObservableCollection<People> Peoples { get => _peoples; set => Set(ref _peoples, value); }


    private People _people = null!;
    public People People { get => _people; set => Set(ref _people, value); }


    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); } 

    public object? SenderModel { get; set; }


    #region Filter

    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }


    private string _innFilter = null!;
    public string InnFilter { get => _innFilter; set => Set(ref _innFilter, value); }


    private string _snilsFilter = null!;
    public string SnilsFilter { get => _snilsFilter; set => Set(ref _snilsFilter, value); }

    private void Filter(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "NameFilter")
        {
            CollectionView.Filter = FilterByName;
        }

        if (e.PropertyName == "InnFilter")
        {
            CollectionView.Filter = FilterByInn;
        }

        if (e.PropertyName == "SnilsFilter")
        {
            CollectionView.Filter = FilterBySnils;
        }
    }

    private bool FilterBySnils(object obj)
    {
        if (!String.IsNullOrEmpty(SnilsFilter))
        {
            People? dto = obj as People;
            return dto!.Snils!.ToUpper().Contains(SnilsFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByInn(object obj)
    {
        if (!String.IsNullOrEmpty(InnFilter))
        {
            People? dto = obj as People;
            return dto!.Inn!.ToUpper().Contains(InnFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!String.IsNullOrEmpty(NameFilter))
        {
            People? dto = obj as People;
            return dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    #endregion

    #region Commands

    private ICommand? _addPeoples;

    public ICommand AddCommand => _addPeoples
        ??= new RelayCommand(OnAddPeoplesCommandExecuted);

    private void OnAddPeoplesCommandExecuted(object obj)
    {
        PeopleView view = new();
        var mod = view.DataContext as PeopleViewModel;
        mod!.Title = "Добавление нового физического лица";
        mod.SenderModel = this;
        view.DataContext=mod;
        view.Show();
    }

    private ICommand? _editPeoples;

    public ICommand EditCommand => _editPeoples
        ??= new RelayCommand(OnEditCommandExecuted, CanEditCommandExecuted);

    private bool CanEditCommandExecuted(object arg)
    {
        return People != null!;
    }

    private void OnEditCommandExecuted(object obj)
    {
        PeopleView view = new();
        var mod = view.DataContext as PeopleViewModel;
        mod!.Title = "Редактирование физического лица";
        mod.SenderModel = this;
        mod.People= People;
        view.DataContext = mod;
        view.Show();
    }

    
    private ICommand? _deletePeoples;

    public ICommand DeleteCommand => _deletePeoples
        ??= new RelayCommand(OnDeleteCommandExecuted, CanEditCommandExecuted);

    private async void OnDeleteCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить: " +
                                     $"{People.Surname} {People.Name[0]}. {People.Patronymic[0]}.", 
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            People.Status = await _statusRepository.GetByIdAsync(6);
            var pl= await _peopleRepository.UpdateAsync(People);
            Peoples.Remove(People);
        }
    }

    private ICommand? _refreshPeoples;

    public ICommand RefreshCommand => _refreshPeoples
        ??= new RelayCommand(OnRefreshCommandExecuted);

    private void OnRefreshCommandExecuted(object obj)
    {
        LoadData();
    }


    

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowCommandExecuted, CanEditCommandExecuted);

    private void OnSelectRowCommandExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is EmployeeViewModel employeeViewModel)
            {
                employeeViewModel.Employee.People = People;
            }

            if (SenderModel is DocCashViewModel docCashViewModel)
            {
                docCashViewModel.DocCash.People = People;
            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion
}