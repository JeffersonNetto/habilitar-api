namespace Habilitar.Core.Helpers
{
    public record JwtSettings
    {
        public string Secret { get; init; }
        public string Audience { get; init; }
        public string Issuer { get; init; }
        public short Expires { get; init; }
    }
}
