using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TripMaker.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GreaterThanCurrentDateAttribute : ValidationAttribute
    {
        public GreaterThanCurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            if (date >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
   
    }
}
