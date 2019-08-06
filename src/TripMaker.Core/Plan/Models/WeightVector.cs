using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;

namespace TripMaker.Plan.Models
{
    public class WeightVector
    {
        //0. Price //1. Rating //2. Distance //3. Popularity //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping
        private double[] Values;

        public WeightVector()
        {
            var column= Enum.GetNames(typeof(WeightVectorLabel)).Length;
            Values = new double[column];
        }


    }
}
