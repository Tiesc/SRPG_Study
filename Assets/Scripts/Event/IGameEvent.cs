namespace ELGame
{
    public interface IGameEvent
    {
        string Name { get; }

        object Body { get; }

        string ToString();
    }
}