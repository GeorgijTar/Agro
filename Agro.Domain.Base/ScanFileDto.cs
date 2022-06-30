
using System.ComponentModel.DataAnnotations;
using Agro.Domain.Base.Base;


namespace Agro.Domain.Base;
public class ScanFileDto : EntityDto
{
    /// <summary>Имя файла (с расширением)</summary>
    private string _name = null!;
    [Required]
    public string Name { get=>_name; set=>Set(ref _name, value); }

    /// <summary>Описание файла</summary>
    private string? _description;
    public string? Description { get=>_description; set=>Set(ref _description, value); }

    /// <summary>Тело файла</summary>с
    private byte[] _bodyBytes = null!;
    [Required]
    public byte[] BodyBytes { get=>_bodyBytes; set=>Set(ref _bodyBytes, value); }
}

