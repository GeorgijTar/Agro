
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Contract;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;

namespace Agro.WPF.ViewModels.Auxiliary_windows;
public class GroupViewModel : ViewModel
{
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    public object SenderModel { get; set; } = null!;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private GroupDoc _group = null!;
    public GroupDoc Group { get => _group; set => Set(ref _group, value); }

    public GroupViewModel(IBaseRepository<GroupDoc> groupRepository)
    {
        _groupRepository = groupRepository;
    }


    #region Commands

    #region Close

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Group != null! && Group.Name != null! && Group.Name.Trim().Length > 0 && Group.TypeApplication != null! && Group.TypeApplication.Trim().Length > 0;
    }

    private async void OnSaveExecuted(object obj)
    {
        var group = await _groupRepository.SaveAsync(Group);
        if (SenderModel != null!)
        {
            if (SenderModel is ContractViewModel contract)
            {
                var groups = await _groupRepository.GetAllAsync();
                contract.Groups = groups!.Where(g => g.TypeApplication == Group.TypeApplication).OrderBy(g => g.Name)
                    .ToArray();
                contract.Contract.Group = Group;
            }
        }

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion

    #endregion
}