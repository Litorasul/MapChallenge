namespace MapChallenge.Shared
{
    public static class GlobalConstants
    {
        public const string ApplicationName = "MapChallenge";

        public const string AdministratorRoleName = "Administrator";

        public const string JsonContentType = "application/json";

        // For Seeding Data.
        public const string CountriesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/country-capital-continent.json";

        public const string UsStatesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/us_state_capitals.json";

        public const string CanadaStatesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/canadian-provinces.json";

        // Game Elements
        public const int ElementsAmountInShortGame = 20;

        // Client GeoJSON paths
        public const string UsaMapPath = ".../MapsGeoJson/usa.json";

        public const string CanadaMapPath = ".../MapsGeoJson/canada.geo.json";

        public const string AfricaMapPath = ".../MapsGeoJson/AfricaLow.json";

        public const string AsiaMapPath = ".../MapsGeoJson/asia.geo.json";

        public const string EuropeMapPath = ".../MapsGeoJson/europe.geo.json";

        public const string SouthAmericaMapPath = ".../MapsGeoJson/SouthAmericaLow.json";

        // List of all continent names
        public static readonly string[] Continents =
        {
            "Africa",
            "Asia",
            "Europe",
            "North America",
            "South America",
        };
    }
}
