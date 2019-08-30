using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan.Models
{
    public class PlanElementReview
    {
        public int? Rating { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }

        public PlanElementReview()
        {

        }

    }
}
