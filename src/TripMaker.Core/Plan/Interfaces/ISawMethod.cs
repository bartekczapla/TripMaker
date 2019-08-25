using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public interface ISawMethod : IDomainService
    {
        decimal CalculateNormalizedScore(SawNormalizationMethod method, WeightVector weightVector, decimal[] rowValues, decimal[] minVector, decimal[] maxVector);
    }
}
