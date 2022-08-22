

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Weight;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.ViewModels.Personnel;
using Agro.WPF.Views.Windows.Personnel;
using Agro.WPF.Views.Windows.Weight;

namespace Agro.WPF.ViewModels.Weight;
public class WeightsViewModel : ViewModel
{
    private readonly IBaseRepository<DAL.Entities.Weight.Weight> _weightRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<DAL.Entities.Weight.Weight> _weights = new();
    public ObservableCollection<DAL.Entities.Weight.Weight> Weights { get => _weights; set => Set(ref _weights, value); }


    private DAL.Entities.Weight.Weight _weight = null!;
    public DAL.Entities.Weight.Weight Weight { get => _weight; set => Set(ref _weight, value); }

    public WeightsViewModel(IBaseRepository<DAL.Entities.Weight.Weight> weightRepository, IBaseRepository<Status> statusRepository)
    {
        _weightRepository = weightRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        var weights = await _weightRepository.GetAllAsync();
        weights = weights!.Where(w => w.Status!.Id == 5).ToArray();
        foreach (var weight in weights)
        {
            Weights.Add(weight);
        }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        WeightView view = new();
        var mod = view.DataContext as WeightViewModel;
        mod!.Title = "Добавление новой весовой";
        mod.Weight = new();
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, CanEditCommandExecuted);

    private bool CanEditCommandExecuted(object arg)
    {
        return Weight != null!;
    }

    private void OnEditCommandExecuted(object obj)
    {
        WeightView view = new();
        var mod = view.DataContext as WeightViewModel;
        mod!.Title = "Редактирование весовой";
        mod.Weight = Weight;
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteCommandExecuted, CanEditCommandExecuted);

    private async void OnDeleteCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить весовую: {Environment.NewLine}" +
                                     $"{Weight.Name}",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Weight.Status = await _statusRepository.GetByIdAsync(6);
            await _weightRepository.UpdateAsync(Weight);
            Weights.Remove(Weight);
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
