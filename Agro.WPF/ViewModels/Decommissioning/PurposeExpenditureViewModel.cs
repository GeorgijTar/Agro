

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Accounting;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Decommissioning;
public class PurposeExpenditureViewModel : ViewModel
{
    private readonly IBaseRepository<PurposeExpenditure> _purposeRepository;
    private readonly INotificationManager _notificationManager;


    private PurposeExpenditure _purposeExpenditure = null!;

    public PurposeExpenditure PurposeExpenditure
    {
        get => _purposeExpenditure;
        set => Set(ref _purposeExpenditure, value);
    }

    public PurposeExpenditureViewModel(
        IBaseRepository<PurposeExpenditure> purposeRepository,
        INotificationManager notificationManager)
    {
        _purposeRepository = purposeRepository;
        _notificationManager = notificationManager;
        PurposeExpenditure = new PurposeExpenditure()
        {
            Status = (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 1)!
        };
    }

    #region Commands

    #region ShowAccountingPlane

    private ICommand? _showAccountingCommand;

    public ICommand ShowAccountingCommand => _showAccountingCommand
        ??= new RelayCommand(OnShowAccountingExecuted);

    private void OnShowAccountingExecuted(object obj)
    {
        var view = new AccountingPlansView();
        var model = view.DataContext as AccountingPlansViewModel;
        model!.SenderModel = this;
        model.Title = "Выберите счет учета затрат";
        view.ShowDialog();
    }

    #endregion

    #region Trash

    private ICommand? _trashCommand;

    public ICommand TrashCommand => _trashCommand
        ??= new RelayCommand(OnTrashExecuted, TrashCan);

    private bool TrashCan(object arg)
    {
        return PurposeExpenditure.AccountingPlan != null!;
    }

    private void OnTrashExecuted(object obj)
    {
        PurposeExpenditure.AccountingPlan = null!;
    }

    #endregion

    #region Save

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, SaveCan);

    private bool SaveCan(object arg)
    {
        return PurposeExpenditure.Name != null! && PurposeExpenditure.AccountingPlan != null!;
    }

    private async void OnSaveExecuted(object obj)
    {
        try
        {
            PurposeExpenditure.Status =
            (Application.Current.Properties["Status"] as IEnumerable<Status>)!.FirstOrDefault(s => s.Id == 5)!;
            var purpose = await _purposeRepository.SaveAsync(PurposeExpenditure);

            if (SenderModel != null!)
            {
                if (SenderModel is PurposeExpendituresViewModel wmModel)
                {
                    var woo = wmModel.PurposeExpenditures.FirstOrDefault(t => t.Id == purpose.Id);
                    if (woo != null!)
                    {
                        var ind = wmModel.PurposeExpenditures.IndexOf(woo);
                        wmModel.PurposeExpenditures[ind] = purpose;
                    }
                    else
                    {
                        wmModel.PurposeExpenditures.Add(purpose);
                    }
                }
            }
            var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
            if (window != null!)
                window.Close();
            _notificationManager.Show("Редактор документов",
                "Объект успешно сохранен", NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Редактор документов",
                $"При сохранении документа в БД произошла ошибка: {e.Message}", NotificationType.Error);
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


    #endregion
}