using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace Agro.Dto;
/// <summary>
/// Абстрактный класс, обеспечивающий обработку ошибок для бизнес-логики
/// </summary>
public abstract class BizActionErrors
{
    /// <summary>Поле для Хранения списока ошибок валидации в частном порядке </summary>
    private readonly List<ActionError> _errors = new();

    /// <summary>Свойство для предоставления доступа к неизменяемому списку ошибок </summary>
    public IImmutableList<ActionError> Errors => _errors.ToImmutableList();

    /// <summary> Логическое свойство на наличие ошибок  </summary>
    public bool HasErrors => _errors.Any(e => e.IsCriticalError == false);

    public bool HasCriticalErrors=> _errors.Any(e => e.IsCriticalError);

    /// <summary>
    /// Метод добавления  простого сообщения об ошибке (или сообщение об ошибке со связанными  с ним совйствами) 
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    /// <param name="isCriticalError">Логическое свойство определяющее является ли ошибка критической</param>
    /// <param name="propertyNames">Массив имен свойств связанных с ошибкой</param>
    protected void AddError(string errorMessage, bool isCriticalError,
        params string[] propertyNames)
    {
        _errors.Add( new(new ValidationResult
            (errorMessage, propertyNames), isCriticalError));
    }
}
