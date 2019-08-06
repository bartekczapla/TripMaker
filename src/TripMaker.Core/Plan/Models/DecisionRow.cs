using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class DecisionRow
    {
        private double[] Values;

        public DecisionRow()
        {
            Values = new double[10];
        }

        public void SetValue(WeightVectorLabel label, double value)
        {
            Values[(int)label] = ValidateValue(label, value);
        }

        private double ValidateValue(WeightVectorLabel label, double value)
        {
            switch (label)
            {
                case WeightVectorLabel.Price:
                    return GetInRange(0, 4, value);
                case WeightVectorLabel.Rating:
                    return GetInRange(1.0d, 5.0d, value);
                default:
                    return GetInRange(null, null, value);
            }
        }

        private double GetInRange(double? from, double? to, double value)
        {
            if (from.HasValue && value < from)
                return from.Value;
            else if (to.HasValue && value > to)
                return to.Value;
            else
                return value;
        }
    }
}
