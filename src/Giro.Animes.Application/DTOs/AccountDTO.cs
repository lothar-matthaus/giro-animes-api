using Giro.Animes.Application.DTOs.Base;

namespace Giro.Animes.Application.DTOs
{
    public class AccountDTO : BaseDTO
    {
        /// <summary>
        /// E-mail da conta
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Identificador do plano do usuário 
        /// </summary>
        public EnumDTO<int> Plan { get; set; }
        /// <summary>
        /// Identificador da imagem de perfil
        /// </summary>
        public AvatarDTO Avatar { get; set; }
        /// <summary>
        /// Configurações da conta do usuário
        /// </summary>
        public SettingsDTO Settings { get; set; }
        /// <summary>
        /// Lista de favoritos para assistir.
        /// </summary>
        public IEnumerable<AnimeDTO> Watchlist { get; set; }
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public long UserId { get; set; }

        private AccountDTO(string email, EnumDTO<int> plan, AvatarDTO avatar, SettingsDTO settings, IEnumerable<AnimeDTO> watchlist, long userId, long? id, DateTime creationDate, DateTime updateDate)
            : base(id, creationDate, updateDate)
        {
            Email = email;
            Plan = plan;
            Avatar = avatar;
            Settings = settings;
            Watchlist = watchlist;
            UserId = userId;
        }

        public static AccountDTO Create(string email, EnumDTO<int> plan, AvatarDTO avatar, SettingsDTO settings, IEnumerable<AnimeDTO> watchlist, long userId, long? id, DateTime creationDate, DateTime updateDate)
        {
            return new AccountDTO(email, plan, avatar, settings, watchlist, userId, id, creationDate, updateDate);
        }
    }
}
