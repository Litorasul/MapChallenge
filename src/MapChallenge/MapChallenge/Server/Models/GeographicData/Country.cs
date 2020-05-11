namespace MapChallenge.Server.Models.GeographicData
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Capital { get; set; }

        [ForeignKey("Continent")]
        public int ContinentId { get; set; }

        public Continent Continent { get; set; }
    }
}
