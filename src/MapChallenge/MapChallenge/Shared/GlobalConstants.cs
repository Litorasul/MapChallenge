namespace MapChallenge.Shared
{
    public static class GlobalConstants
    {
        public const string ApplicationName = "MapChallenge";

        public const string AdministratorRoleName = "Administrator";

        public const string JsonContentType = "application/json";

        public const string CountriesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/country-capital-continent.json";

        public const string UsStatesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/us_state_capitals.json";

        public const string CanadaStatesAndCapitalsJsonPath = @"../Server/Data/Seeding/JsonData/canadian-provinces.json";

        public static readonly string[] Continents =
        {
            "Africa",
            "Asia",
            "Europe",
            "North America",
            "South America",
        };

        public const int ElementsAmountInShortGame = 20;
    }
}
