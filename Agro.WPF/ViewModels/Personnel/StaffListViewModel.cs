

using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;
public class StaffListViewModel : ViewModel
{
    private readonly IBaseRepository<StaffList> _staffRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private StaffList _staffList = new();
    public StaffList StaffList { get => _staffList; set => Set(ref _staffList, value); }

    public object SenderModel { get; set; } = null!;

    
    private StaffListPosition _position = null!;
    public StaffListPosition Position { get => _position; set => Set(ref _position, value); }


    public StaffListViewModel(IBaseRepository<StaffList> staffRepository, IBaseRepository<Status> statusRepository)
    {
        _staffRepository = staffRepository;
        _statusRepository = statusRepository;
    }

    #region Commands


    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return StaffList.Number!=null! && StaffList.OrderNamber!=null! && StaffList.Positions!.Count>0;
    }

    private async void OnSaveExecuted(object obj)
    {
        StaffList.Status = await _statusRepository.GetByIdAsync(5);
        var sl=await _staffRepository.SaveAsync(StaffList);
        if (SenderModel != null!)
        {
            if (SenderModel is StaffListsViewModel staffList)
            {
                var staff = staffList.StaffLists.FirstOrDefault(s => s.Id == sl.Id);
                if (staff != null!)
                {
                    staff = sl;
                }
                else
                {
                    staffList.StaffLists.Add(sl);
                }
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    
    private ICommand? _addPositionCommand;

    public ICommand AddPositionCommand => _addPositionCommand
        ??= new RelayCommand(OnAddPositionExecuted);

    private void OnAddPositionExecuted(object obj)
    {
        var view = new StaffListPositionView();
        var mod = view.DataContext as StaffListPositionViewModel;
        mod!.Title = "Добавление новой позиции штатного расписания";
        mod.StaffListPosition = new();
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }

    private ICommand? _editPositionCommand;

    public ICommand EditPositionCommand => _editPositionCommand
        ??= new RelayCommand(OnEditPositionExecuted, CanEditPositionExecuted);

    private bool CanEditPositionExecuted(object arg)
    {
        return Position != null!;
    }

    private void OnEditPositionExecuted(object obj)
    {
        var view = new StaffListPositionView();
        var mod = view.DataContext as StaffListPositionViewModel;
        mod!.Title = "Редактирование позиции штатного расписания";
        mod.StaffListPosition = Position;
        mod.SenderModel = this;
        mod.IsEdit= true;
        view.DataContext = mod;
        view.ShowDialog();
    }

    private ICommand? _deletePositionCommand;

    public ICommand DeletePositionCommand => _deletePositionCommand
        ??= new RelayCommand(OnDeletePositionExecuted, CanEditPositionExecuted);

    private void OnDeletePositionExecuted(object obj)
    {
        var result = MessageBox.Show("Вы действительно хотите удалить выбранную позицию шататного расписания?",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            StaffList.Positions!.Remove(Position);
        }
    }

    #endregion
}
