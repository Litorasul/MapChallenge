namespace MapChallenge.Client.Game
{
    using MapChallenge.Client.Game.Enums;

    public interface IGameStartInfo
    {
        GameContinentType Continent { get; set; }

        GameSubjectType Subject { get; set; }

        bool IsShortGame { get; set; }
    }
}
