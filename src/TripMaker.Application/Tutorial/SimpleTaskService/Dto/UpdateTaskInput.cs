using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TripMaker.Tutorial.Dto
{
    public class UpdateTaskInput : ICustomValidate
    {
        [Range(1,long.MaxValue)]
        public int SimplaTaskId { get; set; }
        
      //  [Required]
      // // [MaxLength(SimpleTask.MaxTitleLength)]
      //  public string Title { get; set; }

      ////  [MaxLength(SimpleTask.MaxDescriptionLength)]
      //  public string Description { get; set; }

        public int? AssignedPersonId { get; set; }

        public TaskState? State { get; set; }


        public void AddValidationErrors(CustomValidationContext context)
        {
            if(AssignedPersonId==null && State == null)
            {
                context.Results.Add(new ValidationResult("Simple Task not updated"));
            }
        }

        public override string ToString()
        {
            return string.Format("[UpdateTaskInput > AssignedPersonId = {0}, SimplaTaskId = {1}]", AssignedPersonId, SimplaTaskId);
        }
    }
}
