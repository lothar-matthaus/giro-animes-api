﻿using Giro.Animes.Domain.Interfaces;
using Giro.Animes.Domain.ValueObjects;

namespace Giro.Animes.Domain.Entities.Base
{
    public abstract class EntityBase : IValidation
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreationDate { get; protected set; }

        /// <summary>
        /// Data de atualização do registro
        /// </summary>
        public DateTime UpdateDate { get; protected set; }

        /// <summary>
        /// Data de exclusão do registro
        /// </summary>
        public DateTime? DeletionDate { get; private set; }

        /// <summary>
        /// Indica se a entidade é válida ou não 
        /// </summary>
        public bool IsValid => !_errors.Any();

        /// <summary>
        /// Lista de erros de validação da entidade 
        /// </summary>
        private IList<ValidationError> _errors;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        protected EntityBase()
        {

        }

        /// <summary>
        /// Atualiza a data de exclusão do registro para a data e hora atuais
        /// </summary>
        public void Delete()
        {
            DeletionDate = DateTime.Now;
        }

        #region Métodos de validação de entidade
        /// <summary>
        /// Retorna a lista de erros de validação da entidade como uma coleção somente leitura
        /// </summary>
        /// <returns>Uma coleção somente leitura de erros de validação</returns>
        public IEnumerable<ValidationError> GetErrors()
        {
            return _errors.AsReadOnly();
        }

        /// <summary>
        /// Valida a entidade com base em uma condição especificada
        /// </summary>
        /// <param name="isInvalidIf">Condição que determina se a entidade é inválida</param>
        /// <param name="ifInvalid">Função que retorna um erro de validação se a condição for verdadeira</param>
        /// <param name="ifValid">Ação a ser executada se a condição for falsa</param>
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
        #endregion
    }
}
