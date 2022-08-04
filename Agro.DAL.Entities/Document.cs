using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Документ
/// </summary>
public class Document:Entity
{
    /// <summary>Статус</summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); } 
    
    private TypeDoc _typeDoc = null!;
    public TypeDoc TypeDoc { get => _typeDoc; set => Set(ref _typeDoc, value); } 



    /// <summary>Серия</summary>
    private string? _series = null!;
    public string? Series { get => _series; set => Set(ref _series, value); }

    /// <summary>Номер</summary>
    private string _number = null!;
    public string Number { get => _number; set => Set(ref _number, value); }

    /// <summary>Дата выдачи</summary>
    private DateTime _dateIssue;
    public DateTime DateIssue { get => _dateIssue; set => Set(ref _dateIssue, value); }

    /// <summary>Выдавщий орган</summary>
    private string? _issuing = null!;
    public string? Issuing { get => _issuing; set => Set(ref _issuing, value); }

    /// <summary>код подразделения</summary>
    private string _codeIssuing = null!;
    public string CodeIssuing { get => _codeIssuing; set => Set(ref _codeIssuing, value); } 
    

}