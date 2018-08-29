namespace Platformer
{
    public interface IConfiguration
    {
        string MySetting { get; }

        IPlatform Platform { get; }
    }

    public class Configuration : IConfiguration
    {
        public string MySetting { get; set; }
        public IPlatform Platform { get; set; }
    }
}