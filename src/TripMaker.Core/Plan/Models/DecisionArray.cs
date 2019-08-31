using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class DecisionArray
    {
        private int NumberOfColumns => Enum.GetNames(typeof(WeightVectorLabel)).Length;

        public DecisionArray()
        {
            DecisionRows = new List<DecisionRow>();
        }

        public List<DecisionRow> DecisionRows { get; set; }

        public WeightVector WeightVector { get; set; }

        public decimal[] GetMinVector()
        {
            var minVector =new decimal[NumberOfColumns];

            for(int i=0;i< NumberOfColumns;i++)
            {
                minVector[i] = DecisionRows.Min(row => row.DecisionValues[i]);
            }

            return minVector;
        }

        public static decimal[] GetMinVector(IList<DecisionRow> rows)
        {
            int NumberOfColumns = Enum.GetNames(typeof(WeightVectorLabel)).Length;
            var minVector = new decimal[NumberOfColumns];

            for (int i = 0; i < NumberOfColumns; i++)
            {
                minVector[i] = rows.Min(row => row.DecisionValues[i]);
            }

            return minVector;
        }

        public decimal[] GetMaxVector()
        {
            var maxVector = new decimal[NumberOfColumns];

            for (int i = 0; i < NumberOfColumns; i++)
            {
                maxVector[i] = DecisionRows.Max(row => row.DecisionValues[i]);
            }

            return maxVector;
        }

        public static decimal[] GetMaxVector(IList<DecisionRow> rows)
        {
            int NumberOfColumns = Enum.GetNames(typeof(WeightVectorLabel)).Length;
            var maxVector = new decimal[NumberOfColumns];

            for (int i = 0; i < NumberOfColumns; i++)
            {
                maxVector[i] = rows.Max(row => row.DecisionValues[i]);
            }

            return maxVector;
        }

    }
}
