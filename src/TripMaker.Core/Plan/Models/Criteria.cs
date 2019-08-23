using System;
using System.Collections.Generic;
using System.Text;

namespace TripMaker.Plan.Models
{
    public struct Criteria
    {
        public int Position { get; set; }
        public string Label { get; set; }
        public decimal AspirationLevel { get; set; }
        public decimal ReserveLevel { get; set; }
        public bool IsProfit
        {
            get
            {
                return AspirationLevel >= ReserveLevel;
            }
        }
    }
}
