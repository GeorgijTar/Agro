
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary> Записи реестра недобросовестных поставщиков </summary>
public class UnscrupulousSupplierRecord:Entity
{
    /// <summary> Реестровый номер </summary>
    private string _RegistrationNumber = null!;
    public string RegistrationNumber { get => _RegistrationNumber; set => Set(ref _RegistrationNumber, value); }

    /// <summary> Дата публикации </summary>
    private DateTime _datePublication ;
    public DateTime DatePublication { get => _datePublication; set => Set(ref _datePublication, value); }

    /// <summary> Дата утверждения </summary>
    private DateTime _dateApproval;
    public DateTime DateApproval { get => _dateApproval; set => Set(ref _dateApproval, value); }

    ///<summary>Сокращенное наименование заказчика</summary>
    private string _shortName = null!;
    public string ShortName { get => _shortName; set => Set(ref _shortName, value); }

    ///<summary>Полное наименование заказчика</summary>
    private string _fullName = null!;
    public string FullName { get => _fullName; set => Set(ref _fullName, value); }

    /// <summary>ИНН заказчика</summary>
    private string _inn = null!;
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    ///<summary>КПП заказчика</summary>
    private string _kpp = null!;
    public string Kpp { get => _kpp; set => Set(ref _kpp, value); }

    /// <summary> Номер закупки </summary>
    private string _purchaseNumber = null!;
    public string PurchaseNumber { get => _purchaseNumber; set => Set(ref _purchaseNumber, value); }


    /// <summary> Описание закупки </summary>
    private string _purchaseDescription = null!;
    public string PurchaseDescription { get => _purchaseDescription; set => Set(ref _purchaseDescription, value); }

    /// <summary> Цена контракта </summary>
    private int _ContractPrice;
    public int ContractPrice { get => _ContractPrice; set => Set(ref _ContractPrice, value); }

}
