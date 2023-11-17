using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.Dto;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.Shared
{
    public class TransactionViewModel:ViewModel
    {
        /// <summary>
        /// Коллекция проводок
        /// </summary>
        private ObservableCollection<TransactionDto> _transactions = null!;
        public ObservableCollection<TransactionDto> Transactions { get => _transactions; set => Set(ref _transactions, value); }

        private TransactionDto _selectTransaction = null!;
        public TransactionDto SelecTransaction { get => _selectTransaction; set => Set(ref _selectTransaction, value); }
        /// <summary>
        /// Наименование документа к которому относятся проводки
        /// </summary>
        private string _nameDoc = null!;
        public string NameDoc { get => _nameDoc; set => Set(ref _nameDoc, value); } }
}
