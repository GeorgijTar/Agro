using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.Counter
{
    public class Contract : Entity
    {
        /// <summary>Статус договора</summary>
        private Status _status = null!;
        [Required]
        public Status Status { get => _status; set => Set(ref _status, value); }

        /// <summary>Тип договора</summary>
        private TypeDoc _type = null!;
        [Required]
        public TypeDoc Type { get => _type; set => Set(ref _type, value); }

        /// <summary>Группа договора</summary>
        private GroupDoc _group = null!;
        [Required]
        public GroupDoc Group { get => _group; set => Set(ref _group, value); }


        /// <summary>Номер договора</summary>
        private string _number = null!;
        public string Number { get => _number; set => Set(ref _number, value); }

        /// <summary>Дата договора</summary>

        private DateTime _date;
        public DateTime Date { get => _date; set => Set(ref _date, value); }


        /// <summary>Контрагент по договору</summary>

        private Counterparty _counterparty = null!;
        [Required]
        public Counterparty Counterparty { get => _counterparty; set => Set(ref _counterparty, value); }


        /// <summary>Платежные реквизиты контрагента договора</summary>
        private BankDetails _bankDetails = null!;
        [Required]
        public BankDetails BankDetails { get => _bankDetails; set => Set(ref _bankDetails, value); }

        /// <summary>Платежные реквизиты организации</summary>
        private BankDetails _bankDetailsOrg = null!;
        public BankDetails BankDetailsOrg { get => _bankDetailsOrg; set => Set(ref _bankDetailsOrg, value); }


        /// <summary>Предмет договора</summary>
        private string _subject = null!;
        public string Subject { get => _subject; set => Set(ref _subject, value); }


        /// <summary>Сумма договора</summary>

        private decimal _amount;
        public decimal Amount { get => _amount; set => Set(ref _amount, value); }


        /// <summary>Примечание к договору</summary>

        private string? _description;

        public string? Description { get => _description; set => Set(ref _description, value); }


        /// <summary>Прикрепленные файлы</summary>

        private ObservableCollection<ScanFile>? _scanFiles;

        public ObservableCollection<ScanFile>? ScanFiles { get => _scanFiles; set => Set(ref _scanFiles, value); }

        private ObservableCollection<SpecificationContract>? _specification;

        public ObservableCollection<SpecificationContract>? Specification { get => _specification; set => Set(ref _specification, value); } 



    }
}
