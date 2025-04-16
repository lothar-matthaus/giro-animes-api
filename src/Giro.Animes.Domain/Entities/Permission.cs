using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.Enums;

namespace Giro.Animes.Domain.Entities
{
    public class Permission : EntityBase
    {
        /// <summary>
        /// Recurso da permissão
        /// </summary>
        public string Resource { get; private set; }

        /// <summary>
        /// Ação da permissão a realizar
        /// </summary>
        public string Action { get; private set; }

        /// <summary>
        /// Se a permissão é padrão para criação de usuário
        /// </summary>
        public bool IsDefault { get; private set; }

        /// <summary>
        /// Se a permissão é para um usuário convidado
        /// </summary>
        public bool IsGuest { get; private set; }

        /// <summary>
        /// Default constructor for EF Core
        /// </summary>
        public Permission() { }

        /// <summary>
        /// Constutor privado para garantir que o objeto só pode ser criado através do método Create
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="action"></param>
        /// <param name="role"></param>
        private Permission(string resource, string action, bool isDefault, bool isGuest)
        {
            Resource = resource;
            Action = action;
            IsDefault = isDefault;
            IsGuest = isGuest;
        }

        /// <summary>
        /// Cria uma nova instancia de Permission.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="action"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public static Permission Create(string resource, string action, bool isDefault, bool isGuest)
        {
            return new Permission(resource, action, isDefault, isGuest);
        }
    }
}
