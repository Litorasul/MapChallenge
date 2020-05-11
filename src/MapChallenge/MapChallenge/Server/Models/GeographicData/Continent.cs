namespace MapChallenge.Server.Models.GeographicData
{
    using System.ComponentModel.DataAnnotations;

    public class Continent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
