using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

    /// <summary>
    /// Держатель реестра акционеров
    /// </summary>
    public class HolderRegister : Entity
    {
        /// <summary>Признак ограничения доступа к сведениям от ФНС</summary>
        private bool _ogrDostup;
        public bool OgrDostup { get => _ogrDostup; set => Set(ref _ogrDostup, value); }

        /// <summary> ОГРН </summary>
        private string _Ogrn = null!;
        public string Ogrn { get => _Ogrn; set => Set(ref _Ogrn, value); }

        /// <summary> ИНН </summary>
        private string _inn = null!;
        public string Inn { get => _inn; set => Set(ref _inn, value); }

        ///<summary>Полное наименование</summary>
        private string _fullName = null!;
        public string FullName { get => _fullName; set => Set(ref _fullName, value); }
}

