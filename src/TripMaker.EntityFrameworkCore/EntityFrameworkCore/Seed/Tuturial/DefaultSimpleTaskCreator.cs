using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TripMaker.Tutorial;

namespace TripMaker.EntityFrameworkCore.Seed.Tuturial
{
    public class DefaultSimpleTaskCreator
    {
        private readonly TripMakerDbContext _context;
        public DefaultSimpleTaskCreator(TripMakerDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateSimpleTasks();
        }

        private void CreateSimpleTasks()
        {
            var pan = new Person("PanCoWszystkoRObi");
            if (_context.People.IgnoreQueryFilters().Any(p=>p.Id==pan.Id))
            {
                return;
            }
            _context.People.Add(pan);
            _context.SaveChanges();

            AddSimpleTaskIfNotExists(new SimpleTask("Odpoczac","niedlugo",pan.Id));
        }

        private void AddSimpleTaskIfNotExists(SimpleTask simpleTask)
        {


            if (_context.Tasks.IgnoreQueryFilters().Any(task=>task.Id==simpleTask.Id && task.Title == simpleTask.Title))
            {
                return;
            }
            _context.Tasks.Add(simpleTask);
            _context.SaveChanges();
        }
    }
}
