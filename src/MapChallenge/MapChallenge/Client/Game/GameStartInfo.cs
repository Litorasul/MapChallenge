namespace MapChallenge.Client.Game
{
    using System;

    using MapChallenge.Client.Game.Enums;

    public class GameStartInfo : IGameStartInfo
    {
        private GameContinentType continent;
        private GameSubjectType subject;
        private bool isShortGame;

        public event Action OnChange;

        public GameContinentType Continent
        {
            get => this.continent;
            set
            {
                this.continent = value;
                this.NotifyDataChanged();
            }
        }

        public GameSubjectType Subject
        {
            get => this.subject;
            set
            {
                this.subject = value;
                this.NotifyDataChanged();
            }
        }

        public bool IsShortGame
        {
            get => this.isShortGame;
            set
            {
                this.isShortGame = value;
                this.NotifyDataChanged();
            }
        }

        public int Points { get; set; }

        private void NotifyDataChanged() => this.OnChange?.Invoke();
    }
}