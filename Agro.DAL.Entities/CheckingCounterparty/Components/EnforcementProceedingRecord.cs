using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities.CheckingCounterparty.Components;

/// <summary>
/// Запись об исполнительном производстве
/// </summary>
public class EnforcementProceedingRecord : Entity
{
    /// <summary> Наименование организации-должника </summary>
    private string _nameDebtor = null!;
    public string NameDebtor { get => _nameDebtor;set => Set(ref _nameDebtor, value);}

    /// <summary> Адрес организации-должника </summary>
    private string _addressDebtor = null!;
    public string AddressDebtor { get => _addressDebtor; set => Set(ref _addressDebtor, value); }

    /// <summary> Номер исполнительного производства </summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary> Дата возбуждения </summary>
    private DateTime _dateInitiation;
    public DateTime DateInitiation { get => _dateInitiation; set => Set(ref _dateInitiation, value); }

    /// <summary> Номер исполнительного документа </summary>
    private string _numberDoc = null!;
    public string NumberDoc { get => _numberDoc; set => Set(ref _numberDoc, value); }

    /// <summary> Тип исполнительного документа </summary>
    private string _typeDoc = null!;
    public string TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }
    
    // <summary> Дата исполнительного документа</summary>
    private DateTime _dateDoc;
    public DateTime DateDoc { get => _dateDoc; set => Set(ref _dateDoc, value); }

    /// <summary> Предмет исполнения </summary>
    private string _subject = null!;
    public string Subject { get => _subject; set => Set(ref _subject, value); }

    /// <summary> Наименование отдела судебных приставов </summary>
    private string _bailiff = null!;
    public string Bailiff { get => _bailiff; set => Set(ref _bailiff, value); }

    /// <summary> Адрес отдела судебных приставов </summary>
    private string _addressBailiff = null!;
    public string AddressBailiff { get => _addressBailiff; set => Set(ref _addressBailiff, value); }

    /// <summary> Сумма долга, руб. </summary>
    private float _amountDebt;
    public float AmountDebt { get => _amountDebt; set => Set(ref _amountDebt, value); }

    /// <summary> Остаток непогашенной задолженности, руб. </summary>
    private float _remainingDebt;
    public float RemainingDebt { get => _remainingDebt; set => Set(ref _remainingDebt, value); } 

}
