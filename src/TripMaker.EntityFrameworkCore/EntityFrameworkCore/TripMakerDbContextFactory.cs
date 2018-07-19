using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TripMaker.Configuration;
using TripMaker.Web;

namespace TripMaker.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TripMakerDbContextFactory : IDesignTimeDbContextFactory<TripMakerDbContext>
    {
        public TripMakerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TripMakerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TripMakerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TripMakerConsts.ConnectionStringName));

            return new TripMakerDbContext(builder.Options);
        }
    }
}
