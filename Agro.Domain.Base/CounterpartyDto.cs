using Agro.Domain.Base.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Domain.Base;

/// <summary>
/// Контрагент
/// </summary>

public class CounterpartyDto : NotifyPropertyChanged
{
    public CounterpartyDto()
    {
        Status = new StatusDto();
        TypeDoc = new TypeDocDto();
        Group = new GroupDto();
    }

    private string _name;
    public string Name { get=>_name; set=>Set(ref _name, value); }

    private StatusDto _status;
    /// <summary>Статус контрагента</summary>
    public StatusDto Status { get=> _status; set=>Set(ref _status, value); }

    private TypeDocDto _type;

    /// <summary>Тип контрагента</summary>
    public TypeDocDto TypeDoc { get=>_type; set=>Set(ref _type, value); }

    private GroupDto? _group;
    /// <summary>Группа</summary>
    public GroupDto? Group { get=>_group; set=>Set(ref _group, value); }

    private string _payName;

    /// <summary>Платежное наименование контрагента</summary>
    [Required, MaxLength(255)]
    public string PayName { get=>_payName; set=>Set(ref _payName, value); }

    private string _inn;
    /// <summary>ИНН контрагента</summary>
    [Required, MinLength(10), MaxLength(12)]
    public string Inn { get=>_inn; set=>Set(ref _inn, value); }

    private string _kpp;
    /// <summary>КПП контрагента</summary>
    [Required, MaxLength(9)]
    public string Kpp { get=>_kpp; set=>Set(ref _kpp, value); }

    private string? _ogrn;
    /// <summary>ОГРН контрагента</summary>
    public string? Ogrn { get=>_ogrn; set=>Set(ref _ogrn, value); }

    private string? _okpo;
    /// <summary>ОКПО контрагента</summary>
    public string? Okpo { get=>_okpo; set=>Set(ref _okpo, value); }

    private string? _description;
    /// <summary>Примечание</summary>
    [MaxLength(225)]
    public string? Description { get=>_description; set=>Set(ref _description, value); }

    public ICollection<BankDetailsDto> BankDetails { get; set; } = new HashSet<BankDetailsDto>();


}

