using Agro.DAL.Entities.Personnel;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using Agro.WPF.Views.Windows.Personnel;
using System.Windows;
using System;

namespace Agro.WPF.ViewModels.Personnel;

public class StaffListPositionViewModel : ViewModel
{
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private StaffListPosition _staffListPosition = new();
    public StaffListPosition StaffListPosition { get => _staffListPosition; set => Set(ref _staffListPosition, value); }

    public object SenderModel { get; set; }= null!;

    public bool IsEdit { get; set; }

    #region Commands

    private ICommand? _showDivisionCommand;

    public ICommand ShowDivisionCommand => _showDivisionCommand
        ??= new RelayCommand(OnShowDivisionCommandExecuted);

    private void OnShowDivisionCommandExecuted(object obj)
    {
        var view = new DivisionsView();
        var mod = view.DataContext as DivisionsViewModel;
        mod!.SenderModel = this;
        mod.Title = "Выбирите подразделение";
        view.DataContext = mod;
        view.ShowDialog();
    }


    private ICommand? _showPostsCommand;

    public ICommand ShowPostsCommand => _showPostsCommand
        ??= new RelayCommand(OnShowPostsCommandExecuted);

    private void OnShowPostsCommandExecuted(object obj)
    {
        var view = new PostsView();
        var mod = view.DataContext as PostsViewModel;
        mod!.SenderModel = this;
        mod.Title = "Выбирите должность";
        view.DataContext=mod;
        view.ShowDialog();
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


    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return StaffListPosition.Division!=null! && StaffListPosition.Post!=null! && StaffListPosition.Quantity!=0;
    }

    private void OnSaveExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is StaffListViewModel staffList)
            {
                if (!IsEdit)
                {
                    staffList.StaffList.Positions!.Add(StaffListPosition);
                }
                
            }
        }

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }
    #endregion

}
