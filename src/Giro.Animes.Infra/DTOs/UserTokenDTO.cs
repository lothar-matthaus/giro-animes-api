namespace Giro.Animes.Infra.DTOs
{
    public class UserTokenDTO
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Token de autenticação do usuário
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Tempo de expiração do token
        /// </summary>
        public double ExpirationTime { get; }

        /// <summary>
        /// Role do usuário
        /// </summary>
        public string UserRole { get; }

        /// <summary>
        /// Construtor privado para criação de novas instâncias de UserToken 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="expirationTime"></param>
        /// <param name="userRole"></param>
        private UserTokenDTO(string userName, string token, double expirationTime, string userRole)
        {
            UserName = userName;
            ExpirationTime = expirationTime;
            Token = token;
            UserRole = userRole;
        }

        /// <summary>
        /// Cria uma nova instância de UserTokenDTO 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="expirationTime"></param>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public static UserTokenDTO Create(string userName, string token, double expirationTime, string userRole)
        {
            return new UserTokenDTO(userName, token, expirationTime, userRole);
        }
    }
}
