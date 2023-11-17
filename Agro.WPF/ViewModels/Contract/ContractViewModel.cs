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
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Auxiliary_windows;
using Agro.WPF.Views.Auxiliary_windows;
using Agro.WPF.Views.Windows.Contract;
using Notification.Wpf;
using Agro.DAL.Entities.Base;

namespace Agro.WPF.ViewModels.Contract;
public class ContractViewModel : ViewModel
{
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private readonly IContractRepository<DAL.Entities.Counter.Contract> _contractRepository;
    private readonly IBaseRepository<DAL.Entities.Organization.Organization> _organizationRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;

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


    private IEnumerable<BankDetails> _bankDetailsOrg = null!;
    public IEnumerable<BankDetails> BankDetailsOrg { get => _bankDetailsOrg; set => Set(ref _bankDetailsOrg, value); }

    public bool IsEdete { get; set; }
    public ContractViewModel(IBaseRepository<TypeDoc> typeRepository,
      IBaseRepository<GroupDoc> groupRepository,
      IContractRepository<DAL.Entities.Counter.Contract> contractRepository,
      IBaseRepository<DAL.Entities.Organization.Organization> organizationRepository,
      IBaseRepository<Status> statusRepository,
      IHelperNavigation helperNavigation,
      INotificationManager notificationManager)
    {
        _typeRepository = typeRepository;
        _groupRepository = groupRepository;
        _contractRepository = contractRepository;
        _organizationRepository = organizationRepository;
        _statusRepository = statusRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        LoadData();

    }

    private async void LoadData()
    {
        var types = await _typeRepository.GetAllAsync();
        Types = types!.Where(t => t.TypeApplication == "Контракт").OrderBy(t => t.Name).ToArray();

        var groups = await _groupRepository.GetAllAsync();
        Groups = groups!.Where(g => g.TypeApplication == "Контракт").ToArray();

        var orgs = await _organizationRepository.GetAllAsync();
        var org = orgs!.FirstOrDefault(o => o.Id == 1);
        BankDetailsOrg = org!.BankDetails;
    }


    #region Commands

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Contract.Type != null! && Contract.Group != null! && Contract.Number != null! &&
               Contract.Counterparty != null! && Contract.BankDetails != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            Contract.Status = await _statusRepository.GetByIdAsync(5);
            var contract = await _contractRepository.SaveAsync(Contract).ConfigureAwait(true);
            Contract = contract;

            if (SenderModel != null!)
            {
                if (SenderModel is ContractsViewModel contracts)
                {
                    if (!IsEdete)
                    {
                        contracts.Contracts.Add(Contract);
                    }
                }
            }
            _notificationManager.Show("Логер", "Договор успешног сохранен!", NotificationType.Information);
            _helperNavigation.ClosePage(TabItem);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", 
                $"Во время сохранения договора возникла ошибка: {e.Message}", NotificationType.Error);
        }




    }

    #endregion

    #region Close

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        _helperNavigation.ClosePage(TabItem);
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
        model.SenderModel = this;
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

    #region AddSpecification

    private ICommand? _addSpecificationCommand;

    public ICommand AddSpecificationCommand => _addSpecificationCommand
        ??= new RelayCommand(OnAddSpecificationExecuted, CanAddSpecificationExecuted);

    private bool CanAddSpecificationExecuted(object arg)
    {
        return Contract.Type != null! && Contract.Number != null!;
    }

    private void OnAddSpecificationExecuted(object obj)
    {
        var view = new SpecificationContractView();
        var model = view.DataContext as SpecificationContractViewModel;
        model!.Title = $"Добавление новой спецификации(соглашения) к {Contract.Type.Name} № {Contract.Number} от {Contract.Date.ToShortDateString()}";
        model.SpecificationContract = new();
        model.SenderModel = this;
        view.DataContext = model;
        view.Show();
    }

    #endregion

    #region EdetSpecification

    private ICommand? _edeteSpecificationCommand;

    public ICommand EdetSpecificationCommand => _edeteSpecificationCommand
        ??= new RelayCommand(OnEdetSpecificationExecuted, CanEdetSpecificationExecuted);

    private bool CanEdetSpecificationExecuted(object arg)
    {
        return Specification != null! && Contract.Type != null! && Contract.Number != null!;
    }

    private void OnEdetSpecificationExecuted(object obj)
    {
        var view = new SpecificationContractView();
        var model = view.DataContext as SpecificationContractViewModel;
        model!.Title = $"Редактирование {Specification!.Type.Name} № {Specification.Number} от {Specification.Date.ToShortDateString()}";
        model.SpecificationContract = Specification;
        model.SenderModel = this;
        model.IsEdet = true;
        view.DataContext = model;
        view.Show();
    }

    #endregion

    #region DeleteSpecification

    private ICommand? _deleteSpecificationCommand;

    public ICommand DeleteSpecificationCommand => _deleteSpecificationCommand
        ??= new RelayCommand(OnDeleteSpecificationExecuted, CanDeleteSpecificationExecuted);

    private bool CanDeleteSpecificationExecuted(object arg)
    {
        return Specification != null! && Contract.Type != null! && Contract.Number != null!;
    }

    private async void OnDeleteSpecificationExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить {Specification!.Type.Name} № " +
                                     $"{Specification.Number} от {Specification.Date.ToShortDateString()}", "Редактор документов", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            if (Specification.Id != 0)
            {
                await _contractRepository.RemoveSpecification(Specification);
            }

            Contract.Specification!.Remove(Specification);
        }
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
        model.Title = "Добовление нового типа для договора";
        model.Type = new();
        model.Type.TypeApplication = "Контракт";
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
        return Contract.Type != null!;
    }

    private void OnEdetTypeExecuted(object obj)
    {
        var view = new TypeView();
        var model = view.DataContext as TypeViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование типа для договора";
        model.Type = Contract.Type;
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

    #region AddNewGroup

    private ICommand? _addGroupCommand;

    public ICommand AddGroupCommand => _addGroupCommand
        ??= new RelayCommand(OnAddGroupExecuted);

    private void OnAddGroupExecuted(object obj)
    {
        var view = new GroupView();
        var model = view.DataContext as GroupViewModel;
        model!.SenderModel = this;
        model.Title = "Добовление новой группы для договоров";
        model.Group = new();
        model.Group.TypeApplication = "Контракт";
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion

    #region EdetGroup

    private ICommand? _edetGroupCommand;

    public ICommand EdetGroupCommand => _edetGroupCommand
        ??= new RelayCommand(OnEdetGroupExecuted, CanEdetGroupExecuted);

    private bool CanEdetGroupExecuted(object arg)
    {
        return Contract.Group != null!;
    }

    private void OnEdetGroupExecuted(object obj)
    {
        var view = new GroupView();
        var model = view.DataContext as GroupViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование группы для договоров";
        model.Group = Contract.Group;
        view.DataContext = model;
        view.ShowDialog();
    }

    #endregion
    #endregion
}
