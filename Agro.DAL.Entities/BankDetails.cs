using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Банковские реквизиты
/// </summary>
public class BankDetails : Entity
{
    public string Name { get; set; } = null!;

    /// <summary>Статус реквизитов</summary>
    public Status Status { get; set; } = null!;

    /// <summary>Наименование банка</summary>
    [Required]
    public string NameBank { get; set; } = null!;

    /// <summary>Расчетный счет</summary>
    [Required, MaxLength(20)]
    public string Bs { get; set; } = null!;

    /// <summary>БИК банка</summary>
    [Required, MaxLength(9)]
    public string Bik { get; set; } = null!;

    /// <summary>Кор. счет</summary>
    [Required, MaxLength(20)]
    public string Ks { get; set; } = null!;

    public BankDetails() { }

    public BankDetails(string name, string nameBank, string bs, string bik, string ks)
    {
        NameBank = nameBank;
        Bs = bs;
        Bik = bik;
        Ks = ks;
        Name = name;
    }

    public override string ToString() => $"{Bs} в {NameBank}";
}

