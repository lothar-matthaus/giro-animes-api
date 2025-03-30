using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Interfaces
{
    public interface IValidation
    {
        bool IsValid { get; }
        IEnumerable<Notification> GetErrors();
        void Validate(bool isInvalidIf, Func<Notification> ifInvalid, Action? ifValid);
    }
}
