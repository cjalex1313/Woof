namespace Woof.Server.Settings
{
    public class AppSettings
    {
        public required JWTConfig JWTConfig { get; set; }
        public required AdminConfig AdminConfig { get; set; }
    }
}
