namespace MapChallenge.Server.Data
{
    using IdentityServer4.EntityFramework.Options;

    using MapChallenge.Server.Models;
    using MapChallenge.Server.Models.GameData;
    using MapChallenge.Server.Models.GeographicData;

    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Result> Results { get; set; }
    }
}
