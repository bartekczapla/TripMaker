

using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace TripMaker.Tutorial.Dto
{
    [AutoMapTo(typeof(SimpleTask))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(SimpleTask.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(SimpleTask.MaxDescriptionLength)]
        public string Description { get; set; }

        public int? AssignedPersonId { get; set; }

        public override string ToString()
        {
            return string.Format("[CreateTaskInput > AssignedPersonId = {0}, Description = {1}]", AssignedPersonId, Description);
        }
    }
}
