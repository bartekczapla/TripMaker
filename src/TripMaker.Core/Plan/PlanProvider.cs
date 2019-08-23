using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TripMaker.Enums;
using TripMaker.Plan.Interfaces;
using TripMaker.Plan.Models;

namespace TripMaker.Plan
{
    public class PlanProvider : IPlanProvider
    {
        private readonly IWeightVectorProvider _weightVectorProvider;
        private readonly IPlanElementCandidateFactory _planElementCandidateFactory;
        private readonly ISawNormalization _sawNormalization;



        public PlanProvider(IWeightVectorProvider weightVectorProvider, IPlanElementCandidateFactory planElementCandidateFactory, ISawNormalization sawNormalization)
        {
            _weightVectorProvider = weightVectorProvider;
            _planElementCandidateFactory = planElementCandidateFactory;
            _sawNormalization = sawNormalization;
        }

        public async Task<Plan> GenerateAsync(PlanForm planForm)
        {
            // 1. Generate weight vector based on user preferences
            var weightVector = _weightVectorProvider.Generate(planForm);
            weightVector.Values[0] = 0.3m;
            weightVector.Values[1] = 0.2m;
            weightVector.Values[2] = 0.1m;
            weightVector.Values[3] = 0.1m;
            weightVector.Values[4] = 0.1m;
            weightVector.Values[5] = 0.1m;
            weightVector.Values[6] = 0.1m;

            // 2. Get candidates to be plan element
            var candidates = await _planElementCandidateFactory.GetCandidates(planForm, weightVector);

            // 3. Create decision array with list of candidates
            var DecisionArray = new DecisionArray();
            DecisionArray.WeightVector = weightVector;


            //TEST
            var test = new DecisionRow { InitialPosition = 1 };
            test.SetValue(WeightVectorLabel.Price, 2.0m);
            test.SetValue(WeightVectorLabel.Popularity, 222.0m);
            test.SetValue(WeightVectorLabel.Sightseeing, 1.0m);
            test.SetValue(WeightVectorLabel.Distance, 32.0m);
            test.SetValue(WeightVectorLabel.Rating, 4.0m);

            DecisionArray.DecisionRows.Add(test);


            var test2 = new DecisionRow { InitialPosition = 2 };
            test2.SetValue(WeightVectorLabel.Price, 4.0m);
            test2.SetValue(WeightVectorLabel.Popularity, 1112.0m);
            test2.SetValue(WeightVectorLabel.Relax, 1.0m);
            test2.SetValue(WeightVectorLabel.Distance, 2.0m);
            test2.SetValue(WeightVectorLabel.Rating, 2.0m);

            DecisionArray.DecisionRows.Add(test2);

            var test3 = new DecisionRow { InitialPosition = 3 };
            test3.SetValue(WeightVectorLabel.Price, 1.0m);
            test3.SetValue(WeightVectorLabel.Popularity, 312.0m);
            test3.SetValue(WeightVectorLabel.Partying, 1.0m);
            test3.SetValue(WeightVectorLabel.Distance, 12.0m);
            test3.SetValue(WeightVectorLabel.Rating, 1.0m);

            DecisionArray.DecisionRows.Add(test3);

            //foreach (var candidate in candidates)
            //{

            //}

            // 4. Normalizacja (3 typy) i 5. funkcja celu
            var minVector = DecisionArray.GetMinVector();
            var maxVector = DecisionArray.GetMaxVector();
            foreach(var decisionRow in DecisionArray.DecisionRows)
            {
                decisionRow.NormalizedScore = _sawNormalization.Normalize(SawNormalizationMethod.LinearFirstType, DecisionArray.WeightVector, decisionRow.DecisionValues, minVector, maxVector);
            }
            // 6. Klasyfikacja wg oceny punktowej
            DecisionArray.DecisionRows = DecisionArray.DecisionRows.OrderByDescending(x => x.NormalizedScore).ToList();
            int newPos = 1;
            foreach(var row in DecisionArray.DecisionRows)
            {
                row.ScorePosition = newPos;
                ++newPos;
            }
            // 7. Optymalizacja trasy

            return new Plan("test");
        }
    }
}

