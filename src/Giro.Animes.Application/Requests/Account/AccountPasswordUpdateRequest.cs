namespace Giro.Animes.Application.Requests.Account
{
    public class AccountPasswordUpdateRequest
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
