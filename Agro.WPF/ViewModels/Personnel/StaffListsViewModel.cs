
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;
public class StaffListsViewModel : ViewModel
{
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<StaffList> _stafListRepository;
    private string _title = "Реестр штатных расписаний";
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private ObservableCollection<StaffList> _staffLists = new();
    public ObservableCollection<StaffList> StaffLists { get => _staffLists; set => Set(ref _staffLists, value); }


    private StaffList _staffList = null!;
    public StaffList StaffList { get => _staffList; set => Set(ref _staffList, value); }


    public StaffListsViewModel(IBaseRepository<Status> statusRepository, IBaseRepository<StaffList> stafListRepository)
    {
        _statusRepository = statusRepository;
        _stafListRepository = stafListRepository;
        LoadData();
    }

    private async void LoadData()
    {
        StaffLists.Clear();
        var sls = await _stafListRepository.GetAllAsync();
        sls = sls!.Where(s => s.Status.Id != 6).ToArray();
        foreach (var sl in sls)
        {
            StaffLists.Add(sl);
        }
    }


    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        StaffListView view = new();
        var mod = view.DataContext as StaffListViewModel;
        mod!.Title = "Добавление нового штатного расписания";
        mod.StaffList = new();
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, CanEditCommandExecuted);

    private bool CanEditCommandExecuted(object arg)
    {
        return StaffList != null! && StaffList.Status.Id==1;
    }

    private void OnEditCommandExecuted(object obj)
    {
        StaffListView view = new();
        var mod = view.DataContext as StaffListViewModel;
        mod!.Title = "Редактирование штатного расписания";
        mod.StaffList = StaffList;
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteCommandExecuted, CanEditCommandExecuted);

    private async void OnDeleteCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить штатное расписание: {Environment.NewLine}" +
                                     $"№ {StaffList.Number} от {StaffList.Date.ToShortDateString()}",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            StaffList.Status = await _statusRepository.GetByIdAsync(6);
            await _stafListRepository.UpdateAsync(StaffList);
            StaffLists.Remove(StaffList);
        }
    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshCommandExecuted);

    private void OnRefreshCommandExecuted(object obj)
    {
        LoadData();
    }
    #endregion
}