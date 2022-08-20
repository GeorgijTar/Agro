

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Organization;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;
public class DivisionsViewModel : ViewModel
{
    private readonly IBaseRepository<Division> _divisionRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private ObservableCollection<Division> _divisions = new();
    public ObservableCollection<Division> Divisions { get => _divisions; set => Set(ref _divisions, value); }


    private Division _division = null!;
    public Division Division { get => _division; set => Set(ref _division, value); }

    public DivisionsViewModel(IBaseRepository<Division> divisionRepository , IBaseRepository<Status> statusRepository)
    {
        _divisionRepository = divisionRepository;
        _statusRepository = statusRepository;
        LoadData();
    }

    private async void LoadData()
    {
        Divisions.Clear();
        var divisions = await _divisionRepository.GetAllAsync();
        divisions = divisions!.Where(d => d.Status!.Id != 6);
        foreach (var division in divisions)
        {
            Divisions.Add(division);
        }
    }

    public object SenderModel { get; set; } = null!;

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var view = new DivisionView();
        var mod = view.DataContext as DivisionViewModel;
        mod!.Title = "Добавление нового подразделения";
        mod.SenderModel = this;
        view.DataContext=mod;
        view.ShowDialog();
    }

  
    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, CanEditExecuted);

    private bool CanEditExecuted(object arg)
    {
        return Division != null!;
    }

    private void OnEditExecuted(object obj)
    {
        var view = new DivisionView();
        var mod = view.DataContext as DivisionViewModel;
        mod!.Title = "Редактирование подразделения";
        mod.Division = Division;
        mod.SenderModel = this;
        view.DataContext = mod;
        view.ShowDialog();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, CanEditExecuted);

    private async void OnDeleteExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительтно хотите удалить подразделение: " +
                                     $"{Division.Name}", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Division.Status = await _statusRepository.GetByIdAsync(6);
            await _divisionRepository.UpdateAsync(Division);
            Divisions.Remove(Division);
        }
    }

    
    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted, CanEditExecuted);

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is StaffListPositionViewModel position)
            {
                position.StaffListPosition.Division = Division;
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    #endregion
}
