using Giro.Animes.Domain.Entities.Base;
using Giro.Animes.Domain.ValueObjects.Base;

namespace Giro.Animes.Domain.Entities
{
    public class Avatar : EntityBase
    {
        /// <summary>
        /// Url da foto de perfil
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Formato da foto de perfil
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// Identificador da conta atrelada a foto de perfil
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Conta atrelada a foto de perfil 
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Construtor padrão da classe ProfilePicture
        /// </summary>
        public Avatar()
        {
        }

        /// <summary>
        /// Construtor da classe ProfilePicture a partir do valor da foto e do formato
        /// </summary>
        /// <param name="value"></param>
        /// <param name="extension"></param>
        private Avatar(string value, string extension)
        {
            Url = value;
            Extension = extension;
        }

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Avatar Create(string value, string extension) => new Avatar(value, extension);
    }
}