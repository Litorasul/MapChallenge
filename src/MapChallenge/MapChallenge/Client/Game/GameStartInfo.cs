namespace MapChallenge.Client.Game
{
    using MapChallenge.Client.Game.Enums;

    public class GameStartInfo : IGameStartInfo
    {
        public GameContinentType Continent { get; set; }

        public GameSubjectType Subject { get; set; }

        public bool IsShortGame { get; set; }
    }
}