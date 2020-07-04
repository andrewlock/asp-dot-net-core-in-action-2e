namespace LamarExample
{
    public interface ILeaderboard<T>
    {
        int GetPosition(object user);
    }
}
