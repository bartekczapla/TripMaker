using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class WeightVector
    {
        //0. Price //1. Rating //2. Distance //3. Popularity //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping
        public decimal[] Values;
        public decimal Total => Values.Sum();

        private int NumberOfColumns => Enum.GetNames(typeof(WeightVectorLabel)).Length;

        public WeightVector()
        {
            Values = new decimal[NumberOfColumns];
        }

        public void SetPriority(WeightVectorLabel label, decimal value)
        {
            Values[(int)label] = GetInRange(value);
        }

        public void AddValue(WeightVectorLabel label, decimal value)
        {
            Values[(int)label] += GetInRange(value);
        }

        public decimal GetValue(int position)
        {
            if (position >= 0 && position < NumberOfColumns)
                return Values[position];
            else
                return 0.0m;
        }

        public decimal GetLabelValue(WeightVectorLabel label)
        {
            return Values[(int)label];
        }

        public decimal GetTotalSum()
        {
            return Values.Sum();
        }

        private decimal GetInRange(decimal value)
        {
            if (value < 0.00m)
                return 0.00m;
            else if (value > 1.00m)
                return 1.00m;
            else
                return value;
        }

        public static WeightVectorLabel TranslateLabel(PlanElementType type)
        {
            switch(type)
            {
                case PlanElementType.Activity:
                    return WeightVectorLabel.Activity;
                case PlanElementType.Culture:
                    return WeightVectorLabel.Culture;
                case PlanElementType.Entertainment:
                    return WeightVectorLabel.Entertainment;
                case PlanElementType.Partying:
                    return WeightVectorLabel.Partying;
                case PlanElementType.Relax:
                    return WeightVectorLabel.Relax;
                case PlanElementType.Shopping:
                    return WeightVectorLabel.Shopping;
                case PlanElementType.Sightseeing:
                default:
                    return WeightVectorLabel.Sightseeing;

            }
        }


    }
}
