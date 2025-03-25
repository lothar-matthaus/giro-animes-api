using Giro.Animes.Domain.Entities.Base;

namespace Giro.Animes.Domain.Entities
{
    public class Avatar : Media
    {
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
        private Avatar(string url, string fileName, string extension) : base(url, fileName, extension)
        {
        }

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="extension"></param>
        /// <param name="fileName"
        /// <returns></returns>
        public static Avatar Create(string url, string fileName, string extension) => new Avatar(url, fileName, extension);
    }
}