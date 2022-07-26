using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Банковские реквизиты
/// </summary>
public class BankDetails : Entity
{
    private Guid _guid;
    public Guid Guid { get => _guid; set => Set(ref _guid, value); }

    private string? _title;
    public string? Title { get=>_title; set=>Set(ref _title, value); }

    /// <summary>Статус реквизитов</summary>
    private  Status _status=null!;
    [Required]
    public virtual Status Status { get=>_status; set=>Set(ref _status, value); }


    private Counterparty? _counterparty;
    public virtual Counterparty? Counterparty { get=> _counterparty; set=>Set(ref _counterparty, value); }
     
    private Organization ? _organization;
    public virtual Organization ? Organization { get=> _organization; set=>Set(ref _organization, value); }

    /// <summary>Наименование банка</summary>
    
    private string _nameBank=null!;
    [Required]
    public string NameBank { get=>_nameBank; set=>Set(ref _nameBank, value); }

    /// <summary>Город банка</summary>
    private string _city=null!;
    public string City { get=>_city; set=>Set(ref _city, value); }

    /// <summary>Расчетный счет</summary>
    private string _bs =null!;
    [Required, MaxLength(20)]
    public string Bs { get=>_bs; set=>Set(ref _bs, value); }

    /// <summary>БИК банка</summary>
    private string _bik =null!;
    [Required, MaxLength(9)]
    public string Bik { get=>_bik; set=>Set(ref _bik, value); }

    /// <summary>Кор. счет</summary>
    private string _ks = null!;
    [Required, MaxLength(20)]
    public string Ks { get=>_ks; set=>Set(ref _ks, value); }

    /// <summary>Примечание</summary>
    private string? _description;
    [MaxLength(225)]
    public string? Description { get=>_description; set=>Set(ref _description, value); }
    
   public override string ToString() => $"{Bs} в {NameBank}";
}

