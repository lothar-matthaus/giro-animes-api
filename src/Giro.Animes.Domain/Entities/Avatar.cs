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
        /// Construtor privado com parâmetros. Garante a construção do objeto através do método Create
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        private Avatar(string url, User user) : base(url)
        {
            User = user;
        }

        /// <summary>
        /// Método de criação do objeto Avatar. 
        /// </summary> 
        /// <param name="user"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Avatar Create(User user, string url) => new Avatar(url, user);
    }
}