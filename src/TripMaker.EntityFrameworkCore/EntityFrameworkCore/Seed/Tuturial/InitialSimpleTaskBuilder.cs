
namespace TripMaker.EntityFrameworkCore.Seed.Tuturial
{
    public class InitialSimpleTaskBuilder
    {
        private readonly TripMakerDbContext _context;

        public InitialSimpleTaskBuilder(TripMakerDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultSimpleTaskCreator(_context).Create();
           // new DefaultPeopleCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
