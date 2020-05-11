namespace MapChallenge.Server.Models.GameData
{
    using System.ComponentModel.DataAnnotations;

    public class Result
    {
        public int Id { get; set; }

        public int Points { get; set; }

        [Required]
        [MaxLength(100)]
        public string PlayerName { get; set; }

        [Required]
        public GameType GameType { get; set; }
    }
}