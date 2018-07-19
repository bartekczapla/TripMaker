using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TripMaker.EntityFrameworkCore
{
    public static class TripMakerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TripMakerDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TripMakerDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
