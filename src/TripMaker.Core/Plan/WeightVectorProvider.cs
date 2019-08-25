using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripMaker.Enums;
using TripMaker.Enums.PlanFormEnums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class WeightVectorProvider : IWeightVectorProvider
    {
        //0. Price //1. Rating //2. Distance //3. Popularity 
        //4.Entertainment //5. Relax //6. Activity //7. Culture //8. Sightseeing //9. Partying //10. Shopping

        public WeightVector Generate(PlanForm planForm)
        {
            var weightVector = new WeightVector();

            //-----------Dajemy na typy elementów planu 0.5m---------------
            var allPreferedStep= Math.Round(0.3m/(planForm.PreferedPlanElements.Count()),2);//max 0.3/14
            decimal totalSecondCategory = 0.5m;
            //PreferedPlanElements moze mieć po maks. 2 elementy nalezace do typów od 4 do 10 -> licz.el * allPreferedStep
            weightVector.AddValue(WeightVectorLabel.Entertainment, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Entertainment));
            weightVector.AddValue(WeightVectorLabel.Sightseeing, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Sightseeing));
            weightVector.AddValue(WeightVectorLabel.Activity, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Activity));
            weightVector.AddValue(WeightVectorLabel.Culture, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Culture));
            weightVector.AddValue(WeightVectorLabel.Relax, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Relax));
            weightVector.AddValue(WeightVectorLabel.Partying, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Partying));
            weightVector.AddValue(WeightVectorLabel.Shopping, allPreferedStep * planForm.PreferedPlanElements.Count(x => x == PlanElementType.Shopping));

            var allSortedStep = Math.Round((totalSecondCategory-weightVector.GetTotalSum())/9,2);
            var remainingRest = (totalSecondCategory - weightVector.GetTotalSum()) - 9 * allSortedStep;
            //SortedPlanElements - punkty za miejsca : 3,2,2,1,1,0,0
            for (int i = 0; i < planForm.SortedPlanElements.Count; i++)
            {
                decimal bonus = 0;
                switch (i)
                {
                    case 0:
                        bonus = allSortedStep * 3 + remainingRest;
                        break;
                    case 1:
                    case 2:
                        bonus = allSortedStep * 2;
                        break;
                    case 3:
                    case 4:
                        bonus = allSortedStep * 1;
                        break;
                    default:
                        break;
                }

                if (planForm.SortedPlanElements[i] == PlanElementType.Entertainment)
                    weightVector.AddValue(WeightVectorLabel.Entertainment, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Sightseeing)
                    weightVector.AddValue(WeightVectorLabel.Sightseeing, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Activity)
                    weightVector.AddValue(WeightVectorLabel.Activity, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Culture)
                    weightVector.AddValue(WeightVectorLabel.Culture, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Relax)
                    weightVector.AddValue(WeightVectorLabel.Relax, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Partying)
                    weightVector.AddValue(WeightVectorLabel.Partying, bonus);
                else if (planForm.SortedPlanElements[i] == PlanElementType.Shopping)
                    weightVector.AddValue(WeightVectorLabel.Shopping, bonus);
            }



            //-----------Dajemy na te 0.5---------------
            decimal totalFirstCategory = 0.5m;
            weightVector.SetPriority(WeightVectorLabel.Rating, 0.2m);
            totalFirstCategory -= 0.2m;
            var partsToDivide = 1;
            //Price
            if (planForm.PricePreference == PricePreference.Cheapest)
            {
                weightVector.AddValue(WeightVectorLabel.Price, 0.1m);
                totalFirstCategory -= 0.1m;
                partsToDivide += 2;
            } else if (planForm.PricePreference == PricePreference.MediumPrices)
            {
                weightVector.AddValue(WeightVectorLabel.Price, 0.05m);
                totalFirstCategory -= 0.05m;
                partsToDivide += 1;
            }

            //Popularity
            if (planForm.AtractionPopularityPreference == AtractionPopularityPreference.MostPopular)
            {
                weightVector.AddValue(WeightVectorLabel.Popularity, 0.1m);
                totalFirstCategory -= 0.1m;
                partsToDivide += 2;
            } else if (planForm.AtractionPopularityPreference == AtractionPopularityPreference.MixedPopular)
            {
                weightVector.AddValue(WeightVectorLabel.Popularity, 0.05m);
                totalFirstCategory -= 0.05m;
                partsToDivide += 1;
            } else if (planForm.AtractionPopularityPreference == AtractionPopularityPreference.NotWellKnown)
            {
                weightVector.AddValue(WeightVectorLabel.Popularity, 0m);
                totalFirstCategory -= 0.00m;
            }

            //Distance - im blizej tym bardziej wazne
            if (planForm.DistanceTypePreference == DistanceTypePreference.OnlyClosest)
            {
                weightVector.AddValue(WeightVectorLabel.Distance, 0.1m);
                totalFirstCategory -= 0.1m;
                partsToDivide += 2;
            } else if (planForm.DistanceTypePreference == DistanceTypePreference.MediumDistances)
            {
                weightVector.AddValue(WeightVectorLabel.Distance, 0.05m);
                totalFirstCategory -= 0.05m;
                partsToDivide += 1;
            } else if (planForm.DistanceTypePreference == DistanceTypePreference.LongDistances)
            {
                weightVector.AddValue(WeightVectorLabel.Distance, 0m);
                totalFirstCategory -= 0.00m;
            }

            if(totalFirstCategory>0)
            {
                var totalFirstCategoryStep = Math.Round(totalFirstCategory / partsToDivide, 2);

                if (planForm.PricePreference == PricePreference.Cheapest) weightVector.AddValue(WeightVectorLabel.Price, 2* totalFirstCategoryStep);
                else if (planForm.PricePreference == PricePreference.MediumPrices) weightVector.AddValue(WeightVectorLabel.Price, 1 * totalFirstCategoryStep);

                if (planForm.AtractionPopularityPreference == AtractionPopularityPreference.MostPopular) weightVector.AddValue(WeightVectorLabel.Popularity, 2 * totalFirstCategoryStep);
                else if (planForm.AtractionPopularityPreference == AtractionPopularityPreference.MixedPopular) weightVector.AddValue(WeightVectorLabel.Popularity, 1 * totalFirstCategoryStep);

                if (planForm.DistanceTypePreference == DistanceTypePreference.OnlyClosest) weightVector.AddValue(WeightVectorLabel.Distance, 2 * totalFirstCategoryStep);
                else if (planForm.DistanceTypePreference == DistanceTypePreference.MediumDistances) weightVector.AddValue(WeightVectorLabel.Distance, 1 * totalFirstCategoryStep);

                weightVector.AddValue(WeightVectorLabel.Rating, 1.0m - weightVector.GetTotalSum());
            }
            var test = weightVector.Total;
            
            return weightVector;
        }
    }
}