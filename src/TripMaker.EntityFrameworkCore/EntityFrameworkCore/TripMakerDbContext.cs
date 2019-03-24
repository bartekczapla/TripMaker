using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TripMaker.Authorization.Roles;
using TripMaker.Authorization.Users;
using TripMaker.MultiTenancy;
using TripMaker.Tutorial;
using TripMaker.Plan;
using TripMaker.Configuration.Models;
using TripMaker.Home.Models;
using TripMaker.ExternalServices.Entities.Models;
using TripMaker.Plan.Models;
using System.Linq;

namespace TripMaker.EntityFrameworkCore
{
    public class TripMakerDbContext : AbpZeroDbContext<Tenant, Role, User, TripMakerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<SimpleTask> Tasks { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
        public virtual DbSet<Plan.Plan> Plans { get; set; }
        public virtual DbSet<PlanForm> PlanForms { get; set; }
        public virtual DbSet<PlanAccomodation> PlanAccomodations { get; set; }
        public virtual DbSet<PlanElement> PlanElements { get; set; }
        public virtual DbSet<PlanRoute> PlanRoutes { get; set; }
        public virtual DbSet<PlanRouteStep> PlanRouteSteps { get; set; }
        public virtual DbSet<SearchedPlace> SearchedPlaces { get; set; }
        public virtual DbSet<ExternalServicesJSON> ExternalServicesJSON { get; set; }

        public virtual DbSet<TripMakerConfiguration> TripMakerConfigurations { get; set; }

        public TripMakerDbContext(DbContextOptions<TripMakerDbContext> options)
            : base(options)
        {
          
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{

        //    base.OnModelCreating(modelBuilder);

        //}
    }
}
