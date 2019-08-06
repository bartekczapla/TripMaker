using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TripMaker.Plan.Interfaces;

namespace TripMaker.Plan
{
    public class PlanProvider : IPlanProvider
    {
        private readonly IWeightVectorProvider _weightVectorProvider;

        public PlanProvider(IWeightVectorProvider weightVectorProvider)
        {
            _weightVectorProvider = weightVectorProvider;
        }

        public async Task<Plan> GenerateAsync(PlanForm planForm)
        {
            // 1. Robimy wektor wagowy
            // 2. Zbieramy kandydatow
            // 3. Tworzymy macierz
            // 4. Normalizacja (3 typy)
            // 5. Funkcja celu
            // 6. Klasyfikacja uwzględniając ograniczenia
            // 7. Optymalizacja trasy

            return new Plan("test");
        }
    }
}
