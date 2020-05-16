namespace MapChallenge.Server.ViewModels
{
    using MapChallenge.Server.Models.GeographicData;
    using MapChallenge.Shared.Mapping;

    public class StateViewModel : IMapFrom<State>
    {
        public string Name { get; set; }

        public string Capital { get; set; }
    }
}