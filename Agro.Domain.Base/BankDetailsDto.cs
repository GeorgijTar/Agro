﻿using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;

namespace Agro.Domain.Base;

/// <summary>
/// Банковские реквизиты
/// </summary>
public class BankDetailsDto : EntityDto
{
    public string Name { get; set; } = null!;

    /// <summary>Статус реквизитов</summary>
    public StatusDto Status { get; set; } = null!;

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

   public override string ToString() => $"{Bs} в {NameBank}";
}
