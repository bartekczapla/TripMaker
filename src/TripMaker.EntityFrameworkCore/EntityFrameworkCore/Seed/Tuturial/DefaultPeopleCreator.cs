using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Tutorial;

namespace TripMaker.EntityFrameworkCore.Seed.Tuturial
{
    public class DefaultPeopleCreator
    {
        private readonly TripMakerDbContext _context;
        public DefaultPeopleCreator(TripMakerDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            AddDefaultPerson(new Person("Jasio"));
            AddDefaultPerson(new Person("Stasiu"));
        }

        public void AddDefaultPerson(Person person)
        {
            if (_context.People.Any(p => p.Id == person.Id))
            {
                return;
            }
            _context.People.Add(person);
            _context.SaveChanges();
        }
    }
}
