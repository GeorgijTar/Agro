
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;

namespace Agro.WPF.ViewModels.Weight;

public class WeightViewModel : ViewModel
{
    private readonly IBaseRepository<DAL.Entities.Weight.Weight> _weightRepository;
    private readonly IBaseRepository<Status> _statusRepository;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private DAL.Entities.Weight.Weight _weight = new();
    public DAL.Entities.Weight.Weight Weight { get => _weight; set => Set(ref _weight, value); }

    public object SenderModel { get; set; } = null!;

    public WeightViewModel(IBaseRepository<DAL.Entities.Weight.Weight> weightRepository, IBaseRepository<Status> statusRepository)
    {
        _weightRepository = weightRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSavePeoplesExecuted, CanSavePeoplesExecuted);

    private bool CanSavePeoplesExecuted(object arg)
    {
        return Weight.Name != null! && Weight.Name.Trim().Length > 3;
    }

    private async void OnSavePeoplesExecuted(object obj)
    {
        Weight.Status = await _statusRepository.GetByIdAsync(5);
        var pl = await _weightRepository.SaveAsync(Weight);
        if (SenderModel is WeightsViewModel weightsViewModel)
        {
            var pld = weightsViewModel.Weights.FirstOrDefault(x => x.Id == pl.Id);
            if (pld! == null!)
            {
                weightsViewModel.Weights.Add(pl);
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
