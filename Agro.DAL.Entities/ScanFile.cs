using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class ScanFile : Entity
{
    /// <summary>Имя файла (с расширением)</summary>
    private string _name = null!;
    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    /// <summary>Описание файла</summary>
    private string? _description = null!;
    public string? Description { get=>_description; set=>Set(ref _description, value); }

    /// <summary>Тело файла</summary>
    private byte[] _bodyBytes = null!;
    [Required]
    public byte[] BodyBytes { get=>_bodyBytes; set=>Set(ref _bodyBytes, value); }

    /// <summary>Размер файла</summary>
    private double _totalBytes;
    public double TotalBytes { get=>_totalBytes; set=>Set(ref _totalBytes, value);}
}
