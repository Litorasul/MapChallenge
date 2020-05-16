namespace MapChallenge.Server.ViewModels
{
    using MapChallenge.Server.Models.GeographicData;
    using MapChallenge.Shared.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }

        public string Capital { get; set; }
    }
}
