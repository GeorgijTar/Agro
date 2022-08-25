
using System.Collections.ObjectModel;
using Agro.DAL.Entities.Base;
using Agro.DAL.Entities.Storage;

namespace Agro.DAL.Entities.Organization
{
    public class OfficialPerson : Entity
    {
        /// <summary>Статус</summary>
        private Status? _status = null!;
        public Status? Status { get => _status; set => Set(ref _status, value); } 


        /// <summary>Сотрудник</summary>
        private Employee _employee = null!;
        public Employee Employee { get => _employee; set => Set(ref _employee, value); }

        /// <summary>Дата начала деятельности</summary>
        private DateTime _starDate;
        public DateTime StartDate { get => _starDate; set => Set(ref _starDate, value); }

    }
}
