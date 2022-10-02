
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Agro.DAL.Entities.Warehouse;

public class Tmc : Entity
{
    /// <summary>Статус</summary>
    private Status? _status = new();
    public Status? Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Артикул</summary>
    private string? _articleNumber;
    public string? ArticleNumber { get => _articleNumber; set => Set(ref _articleNumber, value); }

    /// <summary>Наименование</summary>
    private string _name = null!;
    [Required]
    public string Name { get => _name; set => Set(ref _name, value); }

    /// <summary>Единица измерения</summary>
    private UnitOkei _unit = new();
    public UnitOkei Unit { get => _unit; set => Set(ref _unit, value); }

    /// <summary>Группа готовой продукции</summary>
    private GroupDoc _group = new();
    public GroupDoc Group { get => _group; set => Set(ref _group, value); }

    /// <summary>Счет учета по умолчанию</summary>
    private ObservableCollection<RulesAccounting>? _rulesAccountings;
    public ObservableCollection<RulesAccounting>? RulesAccountings { get => _rulesAccountings; set => Set(ref _rulesAccountings, value); } 
    

    /// <summary>Процент действующего вещества удобрений СЗР</summary>
    private double _percentageActiveSubstance;

    public double PercentageActiveSubstance
    {
        get => _percentageActiveSubstance; set => Set(ref _percentageActiveSubstance, value);
    } 
    
    /// <summary>Примечание</summary>
    private string? _description;
    [MaxLength(225)]
    public string? Description { get => _description; set => Set(ref _description, value); }
}
