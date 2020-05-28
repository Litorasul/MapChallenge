namespace MapChallenge.Client.Game
{
    using MapChallenge.Client.Game.Enums;

    public class GameElement
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public GameState State { get; set; }
    }
}
