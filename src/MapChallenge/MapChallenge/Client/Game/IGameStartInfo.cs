namespace MapChallenge.Client.Game
{
    using System;

    using MapChallenge.Client.Game.Enums;

    public interface IGameStartInfo
    {
        event Action OnChange;

        GameContinentType Continent { get; set; }

        GameSubjectType Subject { get; set; }

        bool IsShortGame { get; set; }
    }
}
