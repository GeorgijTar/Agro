using Agro.DAL.Entities.Organization;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Personnel;

public class DivisionViewModel : ViewModel
{
    private readonly IBaseRepository<Division> _divisionRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private Division _division = new();
    public Division Division { get => _division; set => Set(ref _division, value); }


    public object SenderModel { get; set; } = null!;

    public DivisionViewModel(IBaseRepository<Division> divisionRepository, IBaseRepository<Status> statusRepository)
    {
        _divisionRepository = divisionRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Division.Name!=null! && Division.Name.Trim().Length>2;
    }

    private async void OnSaveExecuted(object obj)
    {
        Division.Status = await _statusRepository.GetByIdAsync(5);
        var cult = await _divisionRepository.SaveAsync(Division);
        if (SenderModel is DivisionsViewModel divisionsViewModel)
        {
            var cl = divisionsViewModel.Divisions.FirstOrDefault(x => x.Id == cult.Id);
            if (cl != null!)
            {
                cl = cult;
            }
            else
            {
                divisionsViewModel.Divisions.Add(cult);
            }
        }

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
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



    #endregion
}