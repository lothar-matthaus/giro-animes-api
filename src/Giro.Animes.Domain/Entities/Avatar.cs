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
        /// <param name="extension">Extensão do arquivo </param>
        private Avatar(string extension, byte[] file = null) : base(string.Empty, Guid.NewGuid().ToString(), extension, file)
        {
        }

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Avatar Create(string extension, byte[] file = null) => new Avatar(extension, file);
    }
}