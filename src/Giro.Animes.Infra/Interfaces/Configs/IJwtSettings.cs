namespace Giro.Animes.Infra.Interfaces.Configs
{
    public interface IJwtSettings
    {
        public string Issuer { get; }
        public string Audience { get; }
        public string SecretKey { get; }
        public bool RequireHttpsMetadata { get; }
        public bool SaveToken { get; }
        public bool ValidateIssuer { get; }
        public bool ValidateAudience { get; }
        public bool ValidateLifetime { get; }
        public bool ValidateIssuerSigningKey { get; }
        public int ClockSkewSeconds { get; }
        public int TokenExpirationMinutes { get; }
    }
}
