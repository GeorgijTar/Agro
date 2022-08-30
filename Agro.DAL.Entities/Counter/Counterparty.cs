using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Agro.DAL.Entities.Counter;

/// <summary>
/// Контрагент
/// </summary>
[Index(nameof(Inn), IsUnique = true, Name = "NameIndex")]
public class Counterparty : Entity
{
    public Counterparty()
    {
        Status = new();
        TypeDoc = new();
        Group = new();
        ActualAddress = new();
    }

    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Статус контрагента</summary>
    private Status _status = null!;
    public virtual Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Тип контрагента</summary>
    private TypeDoc? _typeDoc;
    public virtual TypeDoc? TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); }

    /// <summary>Группа</summary>
    private GroupDoc? _group;
    public virtual GroupDoc? Group { get => _group; set => Set(ref _group, value); }

    /// <summary>Платежное наименование контрагента</summary>
    private string _payName = null!;
    [Required, MaxLength(255)]
    public string PayName { get => _payName; set => Set(ref _payName, value); }

    /// <summary>ИНН контрагента</summary>
    private string _inn = null!;
    [Required, MinLength(10), MaxLength(12)]
    public string Inn { get => _inn; set => Set(ref _inn, value); }

    /// <summary>КПП контрагента</summary>
    private string _kpp = null!;
    [Required, MaxLength(9)]
    public string Kpp { get => _kpp; set => Set(ref _kpp, value); }

    /// <summary>ОГРН контрагента</summary>
    private string? _ogrn;
    public string? Ogrn { get => _ogrn; set => Set(ref _ogrn, value); }

    /// <summary>ОКПО контрагента</summary>
    private string? _okpo;
    public string? Okpo { get => _okpo; set => Set(ref _okpo, value); }

    /// <summary>Фактический адрес контрагента</summary>
    private Address? _actualAddress;
    public virtual Address? ActualAddress { get => _actualAddress; set => Set(ref _actualAddress, value); }

    /// <summary>Примечание</summary>
    private string? _description;
    [MaxLength(225)]
    public string? Description { get => _description; set => Set(ref _description, value); }

    private ObservableCollection<BankDetails>? _bankDetails = new();
    public virtual ObservableCollection<BankDetails>? BankDetails { get => _bankDetails; set => Set(ref _bankDetails, value); }

}

