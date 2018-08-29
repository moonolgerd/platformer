namespace Platformer
{
    public interface IPlatform
    {
        string Name { get; }
    }

    public class Platform : IPlatform
    {
        public string Name { get; set; }
    }
}