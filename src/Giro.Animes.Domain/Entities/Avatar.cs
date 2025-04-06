namespace Giro.Animes.Domain.Entities
{
    public class Avatar : Media
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// Usuário atrelado a imagem de perfil
        /// </summary>
        public User User { get; private set; }

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
        private Avatar(User user, string extension, byte[] file = null) : base(string.Empty, Guid.NewGuid().ToString(), extension, file)
        {
            User = user;
        }

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Avatar Create(User user, string extension, byte[] file = null) => new Avatar(user, extension, file);
    }
}