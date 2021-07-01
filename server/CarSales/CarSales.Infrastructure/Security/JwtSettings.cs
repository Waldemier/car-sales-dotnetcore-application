namespace CarSales.Infrastructure.Security
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secure { get; set; }
        public uint Expires { get; set; }
    }
}