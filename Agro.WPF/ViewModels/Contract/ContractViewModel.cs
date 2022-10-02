using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Counter;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Views.Windows;
using Microsoft.Win32;
using System.IO;
using Agro.Interfaces.Base.Repositories;

namespace Agro.WPF.ViewModels.Contract;
public class ContractViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private readonly IContractRepository<DAL.Entities.Counter.Contract> _contractRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private IEnumerable<TypeDoc> _types = null!;
    public IEnumerable<TypeDoc> Types { get => _types; set => Set(ref _types, value); }


    private IEnumerable<GroupDoc> _groups = null!;
    public IEnumerable<GroupDoc> Groups { get => _groups; set => Set(ref _groups, value); }


    private SpecificationContract? _specification;
    public SpecificationContract? Specification { get => _specification; set => Set(ref _specification, value); }


    private DAL.Entities.Counter.Contract _contract = new();
    public DAL.Entities.Counter.Contract Contract { get => _contract; set => Set(ref _contract, value); }


    private ScanFile _selectedFile = null!;
    public ScanFile SelectedFile { get => _selectedFile; set => Set(ref _selectedFile, value); }

    public object SenderModel { get; set; } = null!;

    public ContractViewModel(IBaseRepository<TypeDoc> typeRepository,
        IBaseRepository<GroupDoc> groupRepository, IContractRepository<DAL.Entities.Counter.Contract> contractRepository)
    {
        _typeRepository = typeRepository;
        _groupRepository = groupRepository;
        _contractRepository = contractRepository;
        LoadData();

    }

    private async void LoadData()
    {
        var types = await _typeRepository.GetAllAsync();
        Types = types!.Where(t => t.TypeApplication == "Контракт").ToArray();

        var groups = await _groupRepository.GetAllAsync();
        Groups = groups!.Where(g => g.TypeApplication == "Контракт").ToArray();

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

    #region ShowSprCounterparty

    private ICommand? _showSprCounterpartyCommand;

    public ICommand ShowSprCounterpartyCommand => _showSprCounterpartyCommand
        ??= new RelayCommand(OnShowSprCounterpartyExecuted);

    private void OnShowSprCounterpartyExecuted(object obj)
    {
        CoynterpartiesView coynterpartiesView = new();
        ContractorsViewModel model = (ContractorsViewModel)coynterpartiesView.DataContext;
        model.ModelSender = this;
        coynterpartiesView.ShowDialog();
    }

    #endregion

    #region TreshCounterparty

    private ICommand? _treshCounterpartyCommand;

    public ICommand TreshCounterpartyCommand => _treshCounterpartyCommand
        ??= new RelayCommand(OnTreshCounterpartyExecuted, CanTreshCounterpartyExecuted);

    private bool CanTreshCounterpartyExecuted(object arg)
    {
        return Contract.Counterparty != null!;
    }

    private void OnTreshCounterpartyExecuted(object obj)
    {
        Contract.Counterparty = null!;
    }

    #endregion

    #region AddCounterparty

    private ICommand? _addCounterpartyCommand;

    public ICommand AddCounterpartyCommand => _addCounterpartyCommand
        ??= new RelayCommand(OnAddCounterpartyExecuted);

    private void OnAddCounterpartyExecuted(object obj)
    {
        CounterpartyView counterpartyView = new();
        var mod = counterpartyView.DataContext as CounterpartyViewModel;
        mod!.Counterparty = new();
        mod.Title = "Создание нового контрагента";
        mod.SenderModel = this;
        counterpartyView.DataContext = mod;
        counterpartyView.ShowDialog();
    }

    #endregion

    #region EditCounterparty

    private ICommand? _editCounterpartyCommand;

    public ICommand EditCounterpartyCommand => _editCounterpartyCommand
        ??= new RelayCommand(OnEditCounterpartyExecuted, CanEditCounterpartyExecuted);

    private bool CanEditCounterpartyExecuted(object arg)
    {
        return Contract.Counterparty != null!;
    }

    private void OnEditCounterpartyExecuted(object obj)
    {
        CounterpartyView counterpartyView = new();
        var mod = counterpartyView.DataContext as CounterpartyViewModel;
        mod!.Title = "Редактирование контрагента";
        mod.Counterparty = Contract.Counterparty;
        mod.SenderModel = this;
        counterpartyView.DataContext = mod;
        counterpartyView.ShowDialog();
    }

    #endregion

    #region AddFile

    private ICommand? _addFileCommand;

    public ICommand AddFileCommand => _addFileCommand
        ??= new RelayCommand(OnAddFileCommandExecuted);

    private void OnAddFileCommandExecuted(object obj)
    {
        string filePath;
        OpenFileDialog openFileDialog = new()
        {
            InitialDirectory = "c:\\",
            Filter = "PDF (*.PDF)|*.PDF|All files (*.*)|*.*",
            FilterIndex = 2,
            RestoreDirectory = false
        };
        if (openFileDialog.ShowDialog() == true)
        {
            //Get the path of specified file
            filePath = openFileDialog.FileName;
            FileInfo fileInfo = new FileInfo(filePath);
            double size = fileInfo.Length / 1048576.00;
            var file = new ScanFile();
            file.Name = openFileDialog.SafeFileName;
            file.BodyBytes = File.ReadAllBytes(filePath);
            file.TotalBytes = size;
            if (Contract.ScanFiles == null!) Contract.ScanFiles = new();
            Contract.ScanFiles!.Add(file);
        }

    }
    #endregion

    #region RemoveFile

    private ICommand? _removeFileCommand;

    public ICommand RemoveFileCommand => _removeFileCommand
        ??= new RelayCommand(OnRemoveFileCommandExecuted, RemoveFileCan);

    private bool RemoveFileCan(object arg)
    {
        return SelectedFile != null!;
    }

    private void OnRemoveFileCommandExecuted(object obj)
    {
        var rezalt = MessageBox.Show($"Вы действительно хотите удалить файл: {SelectedFile.Name}", "Редактор файлов", MessageBoxButton.YesNo);
        if (rezalt == MessageBoxResult.Yes)
        {
            if (SelectedFile.Id != 0)
                _contractRepository.RemoveFile(SelectedFile);
            Contract.ScanFiles!.Remove(SelectedFile);
        }
    }

    #endregion

    #region SaveFile

    private ICommand? _saveFileCommand;

    public ICommand SaveFileCommand => _saveFileCommand
        ??= new RelayCommand(OnSaveFileCommandExecuted, SaveFileCan);

    private void OnSaveFileCommandExecuted(object obj)
    {
        SaveFileDialog saveFileDialog = new()
        {
            InitialDirectory = "c:\\",
            FileName = SelectedFile.Name,
            DefaultExt = ".pdf",
            Filter = "PDF (*.PDF)|*.PDF|All files (*.*)|*.*",
            FilterIndex = 2,
            RestoreDirectory = false
        };


        if (saveFileDialog.ShowDialog() == true)
        {
            File.WriteAllBytes(saveFileDialog.FileName, SelectedFile.BodyBytes);
        }
    }

    private bool SaveFileCan(object arg)
    {
        return SelectedFile != null!;
    }

    #endregion

    #endregion
}
