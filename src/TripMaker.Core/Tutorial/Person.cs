using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripMaker.Tutorial
{
    [Table("AppPerson")]
    public class Person: Entity //mozna dac Entity<Guid> albo AuditedEntity which has CreationTime, CreaterUserId, LastModificationTime and LastModifierUserId properties
    {
        [Required]
        [MaxLength(32)]
        public virtual string Name { get; set; }

        protected Person() { }

        public Person(string name)
        {
            Name = name;
        }
    }
}
