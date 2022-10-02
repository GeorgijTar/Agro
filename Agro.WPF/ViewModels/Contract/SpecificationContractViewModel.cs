using Agro.DAL.Entities.Counter;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.Contract
{
    public class SpecificationContractViewModel : ViewModel
    {
        private string _title = null!;
        public string Title { get => _title; set => Set(ref _title, value); }

        private SpecificationContract _specificationContract = null!;
        public SpecificationContract SpecificationContract { get => _specificationContract; set => Set(ref _specificationContract, value); }

        #region Commands

        

        #endregion

    }
}
