using System.ComponentModel.DataAnnotations;
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;
public class ScanFile : Entity
{
    /// <summary>Имя файла (с расширением)</summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>Описание файла</summary>
    public string? Description { get; set; }

    /// <summary>Тело файла</summary>с
    [Required]
    public byte[] BodyBytes { get; set; } = null!;
}
