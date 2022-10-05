
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Warehouse;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Accounting;

namespace Agro.WPF.ViewModels.TMC;
public class TmcViewModel : ViewModel
{
    private readonly IBaseRepository<Tmc> _tmcRepository;
    private readonly IBaseRepository<UnitOkei> _unitRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private Tmc _tmc = new();
    public Tmc Tmc { get => _tmc; set => Set(ref _tmc, value); }

    public object SenderModel { get; set; } = null!;

    private IEnumerable<UnitOkei>? _units;
    public IEnumerable<UnitOkei>? Units { get => _units; set => Set(ref _units, value); }

    
    private IEnumerable<GroupDoc>? _groups;
    public IEnumerable<GroupDoc>? Groups { get => _groups; set => Set(ref _groups, value); }


    private RulesAccounting _rulesAccounting = null!;
    public RulesAccounting RulesAccounting { get => _rulesAccounting; set => Set(ref _rulesAccounting, value); } 


    public TmcViewModel(
        IBaseRepository<Tmc> tmcRepository, 
        IBaseRepository<UnitOkei> unitRepository, 
        IBaseRepository<Status> statusRepository,
        IBaseRepository<GroupDoc> groupRepository)
    {
        _tmcRepository = tmcRepository;
        _unitRepository = unitRepository;
        _statusRepository = statusRepository;
        _groupRepository = groupRepository;
        LoadData();
    }

    private async void LoadData()
    {
        Units = await _unitRepository.GetAllAsync();

        var groups= await _groupRepository.GetAllAsync();
        Groups = groups!.Where(g=>g.TypeApplication=="МПЗ").OrderBy(g=>g.Name).ToArray();
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
       return Tmc.Name != null! && Tmc.Name.Trim().Length>2 && Tmc.Group != null! && Tmc.Unit !=null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        Tmc.Status = await _statusRepository.GetByIdAsync(5);
        var tmc = await _tmcRepository.SaveAsync(Tmc);
        if (SenderModel != null!)
        {
            if (SenderModel is TmCsViewModel tmcsViewModel)
            {
                var st = tmcsViewModel.Tmcs.FirstOrDefault(t => t.Id == tmc.Id);
                if (st is null)
                {
                    tmcsViewModel.Tmcs.Add(tmc);
                }
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);
    

    private void OnAddExecuted(object obj)
    {
        var view = new RulesAccountingView();
        var mod = view.DataContext as RulesAccountingViewModel;
        mod!.Title = "Добавление нового правила определения счета";
        mod.SenderModel = this;
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

    private ICommand? _removeRulesCommand;

    public ICommand RemoveRulesCommand => _removeRulesCommand
        ??= new RelayCommand(OnRemoveRulesExecuted, CanRemoveRulesExecuted);

    private bool CanRemoveRulesExecuted(object arg)
    {
        return RulesAccounting != null!;
    }

    private void OnRemoveRulesExecuted(object obj)
    {
        var result = MessageBox.Show("Вы действительно хотите удалить выбранное правило определения счета учета",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Tmc.RulesAccountings!.Remove(RulesAccounting);
        }
    }

    #endregion
}
