using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace TripMaker.Tutorial
{
    [Table("AppTasks")]
    public class SimpleTask : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 256;
        public const int MaxDescriptionLength = 64 * 1024; //64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual TaskState State { get; set; }

        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }


        public virtual int? AssignedPersonId { get; set; }

        public SimpleTask()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        public SimpleTask(string title, string description = null, int? assignedPersonId=null)
            : this()
        {
            Title = title;
            Description = description;
            AssignedPersonId = assignedPersonId;
        }
    }

    public enum TaskState : byte
    {
        Open = 0,
        Completed = 1
    }
}
