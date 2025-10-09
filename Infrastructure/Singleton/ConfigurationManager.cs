namespace Infrastructure.Singleton
{
    public sealed class ConfigurationManager
    {
        // Ensures a single instance of the class is created (thread-safe lazy initialization)
        private static readonly Lazy<ConfigurationManager> _instance =
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        // Provides access to the singleton instance of the class
        public static ConfigurationManager Instance => _instance.Value;

        // Exposes the connection string
        public string ConnectionString { get; }

        // Private constructor to restrict external instantiation
        private ConfigurationManager()
        {
            ConnectionString = "Get this from some where like config";
        }
    }
}
