namespace MapChallenge.Server.Models.GeographicData
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class State
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Capital { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
