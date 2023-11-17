using System.Collections.Generic;
using Agro.DAL.Entities.Kassa;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Helpers;
using Agro.WPF.ViewModels.Base;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.Kassa
{
    public class AdvanceReportViewModel:ViewModel
    {
        private readonly IAdvanceReportRepository _advanceReportRepository;
        private readonly IHelperNavigation _helperNavigation;
        private readonly INotificationManager _notificationManager;
        private readonly IBaseRepository<Employee> _employeeRepository;

        private AdvanceReport _advanceReport = null!;
        public AdvanceReport AdvanceReport { get => _advanceReport; set => Set(ref _advanceReport, value); }


        private bool _isEdit;
        public bool IsEdit { get => _isEdit; set => Set(ref _isEdit, value); }

        private IEnumerable<Employee> _employees = null!;
        public IEnumerable<Employee> Employees { get => _employees; set => Set(ref _employees, value); }

        public AdvanceReportViewModel(
            IAdvanceReportRepository advanceReportRepository,
            IHelperNavigation helperNavigation,
            INotificationManager notificationManager, 
            IBaseRepository<Employee> employeeRepository)
        {
            _advanceReportRepository = advanceReportRepository;
            _helperNavigation = helperNavigation;
            _notificationManager = notificationManager;
            _employeeRepository = employeeRepository;
            LoadData();
        }

        private async void LoadData()
        {
            Employees = (await _employeeRepository.GetAllAsync())!;
        }
    }
}
