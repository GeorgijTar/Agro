using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Kassa;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.Commands;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Pages.Kassa;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Kassa;
public class AdvanceReportsViewModel : ViewModel
{
    private readonly IAdvanceReportRepository _advanceReportRepository;
    private readonly IHelperNavigation _helperNavigation;
    private readonly INotificationManager _notificationManager;

    private ObservableCollection<AdvanceReport> _advanceReports = null!;
    public ObservableCollection<AdvanceReport> AdvanceReports
    {
        get => _advanceReports;
        set => Set(ref _advanceReports, value);
    }

    private AdvanceReport _selectedAdvanceReport = null!;
    public AdvanceReport SelectedAdvanceReport
    {
        get => _selectedAdvanceReport;
        set => Set(ref _selectedAdvanceReport, value);
    }

    private ObservableCollection<Status> _statusList = null!;

    public ObservableCollection<Status> StatusList
    {
        get => _statusList;
        set => Set(ref _statusList, value);
    }

    private ICollectionView? _collectionView;
    public ICollectionView? CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }
   
    private DateTime? _dateOnFilter;
    public DateTime? DateOnFilter { get => _dateOnFilter; set => Set(ref _dateOnFilter, value); }


    private DateTime? _dateOffFilter;
    public DateTime? DateOffFilter { get => _dateOffFilter; set => Set(ref _dateOffFilter, value); }

    private decimal _amountIn;
    public decimal AmountIn { get => _amountIn; set => Set(ref _amountIn, value); }

    private decimal _avountOff;
    public decimal AmountOff { get => _avountOff; set => Set(ref _avountOff, value); }

    private string _fioFilter = null!;
    public string FioFilter { get => _fioFilter; set => Set(ref _fioFilter, value); }

    private Status _statusFilter = null!;
    public Status StatusFilter { get => _statusFilter; set => Set(ref _statusFilter, value); }




    public AdvanceReportsViewModel(
        IAdvanceReportRepository advanceReportRepository,
        IHelperNavigation helperNavigation,
        INotificationManager notificationManager)
    {
        _advanceReportRepository = advanceReportRepository;
        _helperNavigation = helperNavigation;
        _notificationManager = notificationManager;

        LoadData();
        PropertyChanged += ViewChanged;
    }

    private async void LoadData()
    {
        var adr = await _advanceReportRepository.GetAllAsync();
        foreach (var advanceReport in adr!)
        {
            AdvanceReports.Add(advanceReport);
        }

        CollectionView = CollectionViewSource.GetDefaultView(AdvanceReports);
    }


    private void ViewChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (CollectionView != null)
        {
            switch (e.PropertyName)
            {
                case "DateOnFilter":
                    CollectionView.Filter = FilterByDate;
                    break;
                case "DateOffFilter":
                    CollectionView.Filter = FilterByDate;
                    break;
                case "AmountIn":
                    CollectionView.Filter = FilterByAmount;
                    break;
                case "AmountOff":
                    CollectionView.Filter = FilterByAmount;
                    break;
                case "StatusFilter":
                    CollectionView.Filter = FilterByFio;
                    break;
            }
        }
    }

    private bool FilterByFio(object obj)
    {
        if (!string.IsNullOrEmpty(FioFilter))
        {
            var dto = obj as AdvanceReport;
            return dto!.Person.People.Surname.ToUpper().Contains(FioFilter) | 
                   dto.Person.People.Name.ToUpper().Contains(FioFilter) | 
                   dto.Person.People.Patronymic.ToUpper().Contains(FioFilter);
        }
        return true;
    }

    private bool FilterByAmount(object obj)
    {
        if (AmountIn <= AmountOff)
        {
            var dto = obj as AdvanceReport;
            return dto!.Amount>=AmountIn & dto.Amount<=AmountOff;
        }
        return true;
    }

    private bool FilterByDate(object obj)
    {
        if (DateOnFilter <= DateOffFilter)
        {
            var dto = obj as AdvanceReport;
            return dto!.Date.Date >= DateOnFilter!.Value.Date & dto.Date.Date <= DateOffFilter!.Value.Date;
        }
        return true;
    }

    #region Команды

    #region Добавление документа

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddExecuted);

    private void OnAddExecuted(object obj)
    {
        var page = new AdvanceReportPage();
        var model = page.DataContext as AdvanceReportViewModel;
        model!.TabItem = _helperNavigation.OpenPage(page, "Создание нового Авансового отчета");
    }

    #endregion

    #region Просмотр документа

    private ICommand? _lookCommand;

    public ICommand LookCommand => _lookCommand
        ??= new RelayCommand(OnLookExecuted, LookCan);

    private bool LookCan(object arg)
    {
        return SelectedAdvanceReport!=null!;
    }

    private void OnLookExecuted(object obj)
    {
        var page = new AdvanceReportPage();
        var model = page.DataContext as AdvanceReportViewModel;
        model!.AdvanceReport = SelectedAdvanceReport;
        model.IsEdit = false;
        model.TabItem = _helperNavigation.OpenPage(page,
            $"Просмотр Авансового отчета № {SelectedAdvanceReport.Number} от " +
            $"{SelectedAdvanceReport.Date.ToShortDateString()}");
    }

    #endregion

    #region Редактирование документа

    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditExecuted, EditCan);

    private bool EditCan(object arg)
    {
        return SelectedAdvanceReport != null! && SelectedAdvanceReport.Status.Id == 1;
    }

    private void OnEditExecuted(object obj)
    {
        var page = new AdvanceReportPage();
        var model = page.DataContext as AdvanceReportViewModel;
        model!.AdvanceReport = SelectedAdvanceReport;
        model.IsEdit = true;
        model.TabItem = _helperNavigation.OpenPage(page, 
            $"Редактирование АО № {SelectedAdvanceReport.Number} от " +
            $"{SelectedAdvanceReport.Date.ToShortDateString()}");
    }

    #endregion

    #region Удаление документа

    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        //return SelectedAdvanceReport != null! && SelectedAdvanceReport.Status.Id == 1;
        return true;
    }

    private void OnDeleteExecuted(object obj)
    {
        
            _notificationManager.ShowButtonWindow($"Вы действительно хотите удалить документ", 
                "Редактор документов", async () => await DeleteAoAsync(), 
                "Удалить",
                () => Cencel(), 
                "Отмена", TimeSpan.FromSeconds(10), String.Empty,null, null, true);
    }

    private bool Cencel()
    {
        return true;
    }

    private async Task<bool> DeleteAoAsync()
    {
        if (await _advanceReportRepository.DeleteAsync(SelectedAdvanceReport))
        {
            AdvanceReports.Remove(SelectedAdvanceReport);
            _notificationManager.Show("Редактор документов", "Авансовый отчет удален", NotificationType.Information);
            return true;
           
        }

        return false;
    }





    #endregion

    #endregion
}
