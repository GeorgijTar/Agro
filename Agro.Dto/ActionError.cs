

using System.ComponentModel.DataAnnotations;

namespace Agro.Dto;
public class ActionError
{
    private readonly ValidationResult _validationResult ;

    public readonly bool IsCriticalError;

    public ActionError(ValidationResult validationResult, bool isCriticalError)
    {
        _validationResult = validationResult;
        IsCriticalError = isCriticalError;
    }
}
