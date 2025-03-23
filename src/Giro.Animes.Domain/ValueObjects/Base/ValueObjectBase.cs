using Giro.Animes.Domain.Interfaces;

namespace Giro.Animes.Domain.ValueObjects.Base
{
    public abstract record ValueObjectBase : IValidation
    {
        /// <summary>
        /// Lista de erros de validação do objeto de valor e suas propriedades
        /// </summary>
        public IList<ValidationError> _errors { get; private set; }

        /// <summary>
        /// Propriedade que indica se o objeto de valor é válido ou não
        /// </summary>
        public bool IsValid => !_errors.Any();

        /// <summary>
        /// Construtor padrão do objeto de valor
        /// </summary>
        protected ValueObjectBase()
        {

        }

        /// <summary>
        /// Pega todos os erros de validação do objeto de valor e suas propriedades 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ValidationError> GetErrors()
        {
            return _errors.AsReadOnly();
        }

        /// <summary>
        /// Valida o objeto de valor e executa ações de acordo com o resultado da validação 
        /// </summary>
        /// <param name="isInvalidIf"></param>
        /// <param name="ifInvalid"></param>
        /// <param name="ifValid"></param>
        public void Validate(bool isInvalidIf, Func<ValidationError> ifInvalid, Action? ifValid)
        {
            if (isInvalidIf)
            {
                _errors ??= [];
                _errors.Add(ifInvalid.Invoke());
            }
            else
            {
                ifValid?.Invoke();
            }
        }
    }
}
