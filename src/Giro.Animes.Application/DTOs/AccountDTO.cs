using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class AccountDTO : BaseDTO
    {
        /// <summary>
        /// E-mail da conta
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public SettingsDTO Settings { get; private set; }
        /// <summary>
        /// Lista de favoritos para assistir.
        /// </summary>
        public IEnumerable<AnimeDTO> Watchlist { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public UserDTO User { get; private set; }

        private AccountDTO(UserDTO user, string email, SettingsDTO settings, IEnumerable<AnimeDTO> watchlist, long? id, DateTime creationDate, DateTime updateDate)
            : base(id, creationDate, updateDate)
        {
            Email = email;
            Settings = settings;
            Watchlist = watchlist;
            User = user;
        }

        public static AccountDTO Create(UserDTO user, string email, SettingsDTO settings, IEnumerable<AnimeDTO> watchlist, long? id, DateTime creationDate, DateTime updateDate)
        {
            return new AccountDTO(user, email, settings, watchlist, id, creationDate, updateDate);
        }
    }
}
