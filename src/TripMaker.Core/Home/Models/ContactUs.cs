using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace TripMaker.Home.Models
{
    [Table("ContactUs")]
    public class ContactUs : Entity, IHasCreationTime
    {
        public const int MaxNameLength = 50;
        public const int MaxMessageLength = 500; 

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; protected set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Email { get; protected set; }

        [Required]
        [MaxLength(MaxMessageLength)]
        public virtual string Message { get; protected set; }


        public virtual DateTime CreationTime { get; set; }

        protected ContactUs()
        {
            CreationTime = Clock.Now;
        }

        public ContactUs(string name, string email, string message) : this()
        {
            Name = name;
            Email = email;
            Message = message;
        }



    }
}
