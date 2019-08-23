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

        //0. Price //1. Rating //2. Distance //3. Popularity //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping
        public Criteria[] DecisionCriterias = new Criteria[]
        {
            new Criteria{Position=(int)WeightVectorLabel.Price, Label=WeightVectorLabel.Price.ToString(), AspirationLevel=0.0m, ReserveLevel=4.0m},
            new Criteria{Position=(int)WeightVectorLabel.Rating, Label=WeightVectorLabel.Rating.ToString(), AspirationLevel=5.0m, ReserveLevel=1.0m},
            new Criteria{Position=(int)WeightVectorLabel.Distance, Label=WeightVectorLabel.Distance.ToString(), AspirationLevel=0.0m, ReserveLevel=200.0m},
            new Criteria{Position=(int)WeightVectorLabel.Popularity, Label=WeightVectorLabel.Popularity.ToString(), AspirationLevel=20000.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Entertainment, Label=WeightVectorLabel.Entertainment.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Relax, Label=WeightVectorLabel.Relax.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Activity, Label=WeightVectorLabel.Activity.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Culture, Label=WeightVectorLabel.Culture.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Sightseeing, Label=WeightVectorLabel.Sightseeing.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Partying, Label=WeightVectorLabel.Partying.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
            new Criteria{Position=(int)WeightVectorLabel.Shopping, Label=WeightVectorLabel.Shopping.ToString(), AspirationLevel=1.0m, ReserveLevel=0.0m},
        };

        public decimal[] GetMinVector()
        {
            var minVector =new decimal[NumberOfColumns];

            for(int i=0;i< NumberOfColumns;i++)
            {
                minVector[i] = DecisionRows.Min(row => row.DecisionValues[i]);
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
    }
}
