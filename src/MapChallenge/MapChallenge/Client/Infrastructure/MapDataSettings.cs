namespace MapChallenge.Client.Infrastructure
{
    /// <summary>
    /// Configuration class for the maps component. Naming the properties according to what the Syncfusion Maps are looking for.
    /// </summary>
    public class MapDataSettings
    {
        /// <summary>
        /// Is the map async.
        /// </summary>
        public bool async { get; set; }

        /// <summary>
        /// The path to the GeoJSON file.
        /// </summary>
        public string dataOptions { get; set; }

        /// <summary>
        /// HTTP Method.
        /// </summary>
        public string type { get; set; }
    }
}