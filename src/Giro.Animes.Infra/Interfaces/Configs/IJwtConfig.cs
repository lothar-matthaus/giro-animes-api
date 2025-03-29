namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IJwtConfig
    {
        public string Issuer { get; }
        public string Audience { get; }
        public string SecretKey { get; }
        public bool ValidateIssuer { get; }
        public bool ValidateAudience { get; }
        public bool ValidateLifetime { get; }
        public bool ValidateIssuerSigningKey { get; }
    }
}
