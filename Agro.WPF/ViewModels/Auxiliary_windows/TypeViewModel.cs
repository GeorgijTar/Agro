using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using Agro.WPF.ViewModels.Contract;
using System.Linq;

namespace Agro.WPF.ViewModels.Auxiliary_windows;

public class TypeViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    public object SenderModel { get; set; } = null!;

    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    
    private TypeDoc _type = null!;
    public TypeDoc Type { get => _type; set => Set(ref _type, value); }

    public TypeViewModel(IBaseRepository<TypeDoc> typeRepository)
    {
        _typeRepository = typeRepository;
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
       return Type!=null! && Type.Name!=null! && Type.Name.Trim().Length>0 && Type.TypeApplication!=null! && Type.TypeApplication.Trim().Length>0;
    }

    private async void OnSaveExecuted(object obj)
    {
        var type = await _typeRepository.SaveAsync(Type);
        if (SenderModel != null!)
        {
            var types = await _typeRepository.GetAllAsync();
            types= types!.Where(t => t.TypeApplication == Type.TypeApplication).OrderBy(t => t.Name).ToArray();
            if (SenderModel is ContractViewModel contract)
            {
                contract.Types = types;
                contract.Contract.Type = type;
            }

            if (SenderModel is SpecificationContractViewModel specificationContract)
            {
                specificationContract.Types = types;
                specificationContract.SpecificationContract.Type = type;
            }


        }

        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    #endregion

    #endregion

}
