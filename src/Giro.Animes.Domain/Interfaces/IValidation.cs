using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces
{
    public interface IValidation
    {
        bool IsValid { get; }
        IEnumerable<ValidationError> GetErrors();
        void Validate(bool isInvalidIf, Func<ValidationError> ifInvalid, Action? ifValid);
    }
}
