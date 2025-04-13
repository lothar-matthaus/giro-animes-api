namespace Giro.Animes.Application.Requests.Account
{
    public class AccountSettingsUpdateRequest
    {
        public bool EnableApplicationNotifications { get; set; }
        public bool EnableEmailNotifications { get; set; }
        public short Theme { get; set; }
        public long InterfaceLanguage { get; set; }
        public IEnumerable<long> AudioLanguages { get; set; }
        public IEnumerable<long> SubtitleLanguages { get; set; }
    }
}
