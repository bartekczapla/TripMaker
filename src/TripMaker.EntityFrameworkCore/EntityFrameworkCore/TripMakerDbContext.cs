using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TripMaker.Authorization.Roles;
using TripMaker.Authorization.Users;
using TripMaker.MultiTenancy;

namespace TripMaker.EntityFrameworkCore
{
    public class TripMakerDbContext : AbpZeroDbContext<Tenant, Role, User, TripMakerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TripMakerDbContext(DbContextOptions<TripMakerDbContext> options)
            : base(options)
        {
        }
    }
}
