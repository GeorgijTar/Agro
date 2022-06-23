using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Банковские реквизиты
/// </summary>
public class BankDetailsDto: NotifyPropertyChanged
{
  
    private string? _title;
    public string? Title { get=>_title; set=>Set(ref _title,value); }

    private StatusDto _status;
    /// <summary>Статус реквизитов</summary>
    [Required]
    public StatusDto Status { get=>_status; set=>Set(ref _status, value); }

    private CounterpartyDto _counterparty;
    /// <summary>Владелец реквизитов</summary>
    [Required]
    public CounterpartyDto Counterparty { get=>_counterparty; set=>Set(ref _counterparty, value); }

    private string _nameBank;
    /// <summary>Наименование банка</summary>
    [Required]
    public string NameBank { get=>_nameBank; set=>Set(ref _nameBank, value); }

    private string _city;
    /// <summary>Город банка</summary>
    public string City { get=>_city; set=>Set(ref _city, value); }


    private string _bs;
    /// <summary>Расчетный счет</summary>
    [Required, MaxLength(20)]
    public string Bs { get=>_bs; set=>Set(ref _bs, value); }

    private string _bik;
    /// <summary>БИК банка</summary>
    [Required, MaxLength(9)]
    public string Bik { get=>_bik; set=>Set(ref _bik, value); }

    private string _ks;
    /// <summary>Кор. счет</summary>
    [Required, MaxLength(20)]
    public string Ks { get=>_ks; set=>Set(ref _ks, value); }

    private string _description;
    /// <summary>Примечание</summary>
    [MaxLength(225)]
    public string Description { get=>_description; set=>Set(ref _description, value); }

    public override string ToString() => $"{Bs} в {NameBank}";
}

