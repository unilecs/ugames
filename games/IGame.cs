namespace UGames.games
{
    internal interface IGame
    {
        string Name { get; }
        string Description { get; }
        void Play();
    }
}
