
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Agro.WPF.Views.Windows.Coming;
using Microsoft.Win32;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Coming;
public class ComingTmcViewModel : ViewModel
{
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;
    private readonly IComingTmcRepository<ComingTmc> _comingTmcRepository;
    private ComingTmc _comingTmc = new();

    private ScanFile _selectedFile = null!;
    public ScanFile SelectedFile { get => _selectedFile; set => Set(ref _selectedFile, value); }

    public ComingTmc ComingTmc
    {
        get => _comingTmc;
        set
        {
            Set(ref _comingTmc, value);
            ComingTmc.Positions.ItemPropertyChanged += CalcItem;
            ComingTmc.Positions.CollectionChanged += CalcCollection;
            ComingTmc.ComingTmcCalculations.PropertyChanged += CalcChanged;
        }

    }

    private string _calculationMethod = null!;
    public string CalculationMethod { get => _calculationMethod; set => Set(ref _calculationMethod, value); }

    private ComingTmcPosition _selectedTmcPosition = null!;
    public ComingTmcPosition SelectedTmcPosition { get => _selectedTmcPosition; set => Set(ref _selectedTmcPosition, value); }

    private bool _isLock;
    public bool IsLock
    {
        get => _isLock;
        set
        {
            Set(ref _isLock, value);
            IsEnabled = false;
        }
    }

    private bool _isEnabled = true;

    public bool IsEnabled
    {
        get => _isEnabled;
        set => Set(ref _isEnabled, value);
    }

    private string _numberInvoiceFactur = null!;
    public string NumberInvoiceFactur
    {
        get => _numberInvoiceFactur;
        set
        {
            Set(ref _numberInvoiceFactur, value);
            if (value == null!)
            {
                ComingTmc.InvoiceFactur = null!;
            }
            else
            {
                if (ComingTmc.InvoiceFactur! == null!)
                    ComingTmc.InvoiceFactur = new()
                    {
                        Status =
                            (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1)
                    };
                ComingTmc.InvoiceFactur.Number = value;
                DateInvoiceFactur = ComingTmc.DateDoc;
            }

        }
    }

    private DateTime? _dateInvoiceFactur;

    public DateTime? DateInvoiceFactur
    {
        get => _dateInvoiceFactur;
        set
        {
            Set(ref _dateInvoiceFactur, value);
            if (ComingTmc.InvoiceFactur! == null!)
                ComingTmc.InvoiceFactur = new()
                {
                    Status =
                        (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1)
                };
            ComingTmc.InvoiceFactur.Date = value;
        }
    }

    private bool _isUpd;
    public bool IsUpd
    {
        get => _isUpd;
        set
        {
            Set(ref _isUpd, value);
            if (value)
            {
                NumberInvoiceFactur = ComingTmc.NumberDoc;
                DateInvoiceFactur = ComingTmc.DateDoc;
            }
            ComingTmc.IsUpd = value;
        }
    }

    private bool _isEdit;
    public bool IsEdit { get => _isEdit; set => Set(ref _isEdit, value); }

    public ComingTmcViewModel(
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager,
        IComingTmcRepository<ComingTmc> comingTmcRepository)
    {
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;
        _comingTmcRepository = comingTmcRepository;
        ComingTmc.Status =
            (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1);
        ComingTmc.ComingTmcCalculations = new()
        {
            AccountingPlan = (Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(s => s.Id == 79)!,
            AccountingPlanPrepayment = (Application.Current.Properties["AccountingPlans"] as IEnumerable<AccountingPlan>)!.FirstOrDefault(s => s.Id == 80)!
        };
        ComingTmc.ComingTmcCalculations.PropertyChanged += CalcChanged;
        ComingTmc.ComingTmcCalculations.AutoCalculation = true;
        ComingTmc.Positions.ItemPropertyChanged += CalcItem;
        ComingTmc.Positions.CollectionChanged += CalcCollection;
    }

    private void CalcChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "AutoCalculation":
                if (ComingTmc.ComingTmcCalculations.AutoCalculation)
                {
                    CalculationMethod = "Автоматически";
                }
                break;
            case "ManualCalculation":
                if (ComingTmc.ComingTmcCalculations.ManualCalculation)
                {
                    CalculationMethod = "По документу";
                }
                break;
            case "NoCalculation":
                if (ComingTmc.ComingTmcCalculations.NoCalculation)
                {
                    CalculationMethod = "Не зачитывать";
                }
                break;

        }
    }

    private void CalcCollection(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Calc();
    }

    private void CalcItem(object? sender, ItemPropertyChangedEventArgs e)
    {
        Calc();
    }

    private void Calc()
    {
        decimal amount = 0;
        decimal amountNds = 0;
        decimal total = 0;

        foreach (var comingTmcPosition in ComingTmc.Positions)
        {
            amount += comingTmcPosition.Amount;
            amountNds += comingTmcPosition.AmountNds;
            total += comingTmcPosition.TotalAmount;
        }

        ComingTmc.Amount = amount;
        ComingTmc.AmountNds = amountNds;
        ComingTmc.TotalAmount = total;
    }

    #region Commands

    private ICommand? _showCounterpartyCommand;

    public ICommand ShowCounterpartyCommand => _showCounterpartyCommand
        ??= new RelayCommand(OnShowCounterpartyExecuted);

    private void OnShowCounterpartyExecuted(object obj)
    {
        var view = new CoynterpartiesView();
        var model = view.DataContext as ContractorsViewModel;
        model!.SenderModel = this;
        model.Title = "Выберите контрагента";
        view.ShowDialog();
    }

    private ICommand? _clearCounterpartyCommand;

    public ICommand ClearCounterpartyCommand => _clearCounterpartyCommand
        ??= new RelayCommand(OnClearCounterpartyExecuted, ClearCounterpartyCan);

    private bool ClearCounterpartyCan(object arg)
    {
        return ComingTmc != null! && ComingTmc.Counterparty != null!;
    }

    private void OnClearCounterpartyExecuted(object obj)
    {
        ComingTmc.Counterparty = null!;
    }

    private ICommand? _addPositionCommand;

    public ICommand AddPositionCommand => _addPositionCommand
        ??= new RelayCommand(OnAddPositionExecuted);

    private void OnAddPositionExecuted(object obj)
    {
        var view = new ComingTmcPositionView();
        var model = view.DataContext as ComingTmcPositionViewModel;
        model!.SenderModel = this;
        model.Title = "Добавление новой позиции поступления";
        view.ShowDialog();
    }

    private ICommand? _editPositionCommand;

    public ICommand EditPositionCommand => _editPositionCommand
        ??= new RelayCommand(OnEditPositionExecuted, EditPositionCan);

    private bool EditPositionCan(object arg)
    {
        return SelectedTmcPosition != null!;
    }

    private void OnEditPositionExecuted(object obj)
    {
        var view = new ComingTmcPositionView();
        var model = view.DataContext as ComingTmcPositionViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование позиции поступления";
        model.IsEdit = true;
        model.ComingTmcPosition = SelectedTmcPosition;
        view.ShowDialog();
    }

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return SelectedTmcPosition != null!;
    }

    private void OnDeleteExecuted(object obj)
    {
        var result = MessageBox.Show("Вы действительно хотите удалить выделенную позицию прихода?", "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            ComingTmc.Positions.Remove(SelectedTmcPosition);
        }
    }

    private ICommand? _showCalcCommand;

    public ICommand ShowCalcCommand => _showCalcCommand
        ??= new RelayCommand(OnShowCalcExecuted);

    private void OnShowCalcExecuted(object obj)
    {
        var view = new ComingTmcCalculationsView();
        var model = view.DataContext as ComingTmcCalculationsViewModel;
        model!.SenderModel = this;
        model.Title = "Редактирование порядока расчетов с контрагентом";
        model.ComingTmcCalculations = new ComingTmcCalculations()
        {
            AccountingPlan = ComingTmc.ComingTmcCalculations.AccountingPlan,
            AccountingPlanPrepayment = ComingTmc.ComingTmcCalculations.AccountingPlanPrepayment,
            AutoCalculation = ComingTmc.ComingTmcCalculations.AutoCalculation,
            ManualCalculation = ComingTmc.ComingTmcCalculations.ManualCalculation,
            NoCalculation = ComingTmc.ComingTmcCalculations.NoCalculation,
            DebitingAccounts = ComingTmc.ComingTmcCalculations.DebitingAccounts,
            Id = ComingTmc.ComingTmcCalculations.Id
        };
        model.Counterparty = ComingTmc.Counterparty;
        view.ShowDialog();
    }

    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        _helperNavigation.ClosePage(TabItem);
    }

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return ComingTmc.Counterparty != null!
               && ComingTmc.Positions != null!
               && ComingTmc.Positions.Any()
               && !string.IsNullOrEmpty(ComingTmc.NumberDoc)
               && ComingTmc.TotalAmount > 0;

    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            var closePeriod = await _comingTmcRepository.GetClosedPeriodAsync();
            if (ComingTmc.RegDate <= closePeriod)
            {
                MessageBox.Show("Дата регистрации документа попадает в закрытый период, измените дату регистрации");
                return;
            }

            var validComingTMC = Validation(ComingTmc);
            if (HasCriticalErrors)
            {

            }
            else {
                
                if (validComingTMC.RegNumber == 0)
                {
                    validComingTMC.RegNumber = await _comingTmcRepository.GetRegNumberAsync();
                }

                if (validComingTMC.History != null) ComingTmc.History = new();
                string action;
                if (IsEdit)
                {
                    action = "Изменение документа";
                }
                else
                {
                    action = "Создание документа";
                }

                validComingTMC.History!.Add(new History()
                {
                    EventDate = DateTime.Now,
                    EventHistory = action,
                    User = (Application.Current.Properties["CurrentUser"] as User)!
                });

                var coming = await _comingTmcRepository.SaveAsync(validComingTMC);
                if (SenderModel != null!)
                {
                    if (SenderModel is ComingsTmcViewModel comingsTmcModel)
                    {
                        var ind = comingsTmcModel.ComingsTmc.FirstOrDefault(c => c.Id == coming.Id);
                        if (ind! == null!)
                        {
                            comingsTmcModel.ComingsTmc.Add(coming);
                        }
                        else
                        {
                            int i = comingsTmcModel.ComingsTmc.IndexOf(ind);
                            comingsTmcModel.ComingsTmc[i] = coming;
                        }
                    }
                }

                _helperNavigation.ClosePage(TabItem);
                _notificationManager.Show("Логер", "Документ успешно сохранен", NotificationType.Information);
            }
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При сохранении документа возникла ошибка: {e.Message}", NotificationType.Error);
        }
    }


    #region AddFile

    private ICommand? _addFileCommand;

    public ICommand AddFileCommand => _addFileCommand
        ??= new RelayCommand(OnAddFileCommandExecuted);

    private void OnAddFileCommandExecuted(object obj)
    {

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
            var filePath = openFileDialog.FileName;
            FileInfo fileInfo = new FileInfo(filePath);
            double size = fileInfo.Length / 1048576.00;
            var file = new ScanFile();
            file.Name = openFileDialog.SafeFileName;
            file.BodyBytes = File.ReadAllBytes(filePath);
            file.TotalBytes = size;
            ComingTmc.ScanFiles!.Add(file);
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
        var result = MessageBox.Show($"Вы действительно хотите удалить файл: {SelectedFile.Name}",
            "Редактор файлов", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            if (SelectedFile.Id != 0)
                ComingTmc.ScanFiles!.Remove(SelectedFile);
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

    #region Валидация данных

    /// <summary>
    /// Метод проверки введенных пользователем данных
    /// </summary>
    /// <param name="comingTmc">Документ поступления</param>
    /// <returns>Возвращается переланный документ</returns>
    private ComingTmc Validation(ComingTmc comingTmc)
    {
        if (!comingTmc.Positions.Any())
        {
            AddError("Документ поступления не содержит ни обной позиции поступления!", true);
        }
        if (comingTmc.RegDate.Date.Month > DateTime.Now.Date.Month)
        {
            AddError("Вы пытаетесь зарегистрировать документ, месяцем, который еще не наступил, " +
                     "возможно вы ввели не верную дату регистрации!", false);
        }

        if (string.IsNullOrEmpty(comingTmc.NumberDoc.Trim()))
        {
            AddError("Не указан номер документа поступления, " +
                     "если в оригинальном документе не указан номер, введите в поле № документа \"б/н\"", true);
        }
        else
        {
            comingTmc.NumberDoc = comingTmc.NumberDoc.Trim();
        }

        if (comingTmc.Counterparty == null!)
        {
            AddError("В документе поступления не указан Контрагент", true);
        }

        if (comingTmc.TotalAmount == 0)
        {
            AddError("Сумма документе поступления не ножет быть равна нулю", true);
        }

        if (comingTmc.Note != null!)
        {
            comingTmc.Note = comingTmc.Note.Trim();
        }

      return comingTmc;
    }


    #endregion
}