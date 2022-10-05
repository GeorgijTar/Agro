using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Auxiliary_windows;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Auxiliary_windows;

namespace Agro.WPF.ViewModels.Contract;
public class SpecificationContractViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private SpecificationContract _specificationContract = null!;
    public SpecificationContract SpecificationContract { get => _specificationContract; set => Set(ref _specificationContract, value); }

    private IEnumerable<TypeDoc> _types = null!;
    public IEnumerable<TypeDoc> Types { get => _types; set => Set(ref _types, value); }

    public object SenderModel { get; set; } = null!;

    public bool IsEdet { get; set; }

    public SpecificationContractViewModel(IBaseRepository<TypeDoc> typeRepository)
    {
        _typeRepository = typeRepository;
        Title = "Спецификация (доп.соглашение) к договору";
        LoadData();
    }

    private async void LoadData()
    {
        var types = await _typeRepository.GetAllAsync();
        Types = types!.Where(t => t.TypeApplication == "Спецификация").OrderBy(t=>t.Name).ToArray();
    }

    #region Commands

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return SpecificationContract != null! && SpecificationContract.Number != null! &&
               !string.IsNullOrEmpty(SpecificationContract.Number) && SpecificationContract.Type != null!;
    }

    private void OnSaveExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is ContractViewModel contractViewModel)
            {
                if (!IsEdet)
                {
                    if (contractViewModel.Contract.Specification == null!)
                        contractViewModel.Contract.Specification = new();
                    contractViewModel.Contract.Specification!.Add(SpecificationContract);
                }
            }

            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
        }
    }

    #endregion

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

    #region AddNewType

    private ICommand? _addTypeeCommand;

    public ICommand AddTypeCommand => _addTypeeCommand
        ??= new RelayCommand(OnAddTypeExecuted);

    private void OnAddTypeExecuted(object obj)
    {
        var view = new TypeView();
        var model = view.DataContext as TypeViewModel;
        model!.SenderModel = this;
        model.Title = "Добовление нового типа для спецификации";
        model.Type = new();
        model.Type.TypeApplication = "Спецификация";
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

    #region EdetType

    private ICommand? _edetTypeCommand;

    public ICommand EdetTypeCommand => _edetTypeCommand
        ??= new RelayCommand(OnEdetTypeExecuted, CanEdetTypeExecuted);

    private bool CanEdetTypeExecuted(object arg)
    {
        return SpecificationContract!=null! && SpecificationContract.Type != null!;
    }

    private void OnEdetTypeExecuted(object obj)
    {
        var view = new TypeView();
        var model = view.DataContext as TypeViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование типа для спецификации";
        model.Type = SpecificationContract.Type;
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

    #endregion

}
