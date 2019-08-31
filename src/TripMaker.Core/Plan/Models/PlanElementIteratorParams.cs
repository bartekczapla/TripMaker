using System;
using System.Collections.Generic;
using System.Text;
using TripMaker.Enums;
using TripMaker.ExternalServices.Entities.Common;
using TripMaker.Plan.Models;

namespace TripMaker.Plan.Interfaces
{
    public class PlanElementIteratorParams
    {

        public PlanElementIteratorParams(Location startLocation, DateTime startDateTime, PlanAssumptions assumptions)
        {
            OrderNo = 1;
            CurrentLocation = Location.Create(startLocation.lat, startLocation.lng);
            CurrentDateTime = startDateTime;
            Assumptions = assumptions;
            CurrentDecisionRowIndex = 0;
            LeftRows = new List<DecisionRow>();
            if (TimeSpan.Compare(startDateTime.TimeOfDay, assumptions.LunchTime.Subtract(new TimeSpan(2, 0, 0))) >= 0) WasBreakfast = true;

            if (TimeSpan.Compare(startDateTime.TimeOfDay, assumptions.DinnerTime.Subtract(new TimeSpan(2, 0, 0))) >= 0)
            {
                WasLunch = true;
            }

            if (TimeSpan.Compare(startDateTime.TimeOfDay, assumptions.SleepingTime.Subtract(new TimeSpan(2, 0, 0))) >= 0)
            {
                WasDinner = true;
            }
        }

        public int OrderNo { get; set; }
        public Location CurrentLocation { get; set; }
        public Location NextLocation { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public bool WasBreakfast { get; set; }
        public bool WasLunch { get; set; }
        public bool WasDinner { get; set; }
        public bool IsSleep { get; set; }
        public PlanAssumptions Assumptions { get; set; }

        public GoogleTravelMode travelMode { get; set; }

        public IList<DecisionRow> LeftRows { get; set; } // temporary left rows because closed object
        public int CurrentDecisionRowIndex { get; set; }


        public bool IsTimeForMeal()
        {
            var timeOfDay = CurrentDateTime.TimeOfDay;
            if (!WasBreakfast)
                return true;
            else if (!WasLunch && TimeSpan.Compare(timeOfDay, Assumptions.LunchTime) >= 0)
                return true;
            else if (!WasDinner && TimeSpan.Compare(timeOfDay, Assumptions.DinnerTime) >= 0)
                return true;

            return false;
        }

        public bool IsTimeForSleep()
        {
            var timeOfDay = CurrentDateTime.TimeOfDay;
            if(Assumptions.IsSleepAfterMidnight)
            {
                return TimeSpan.Compare(timeOfDay, Assumptions.SleepingTime) >= 0 && TimeSpan.Compare(timeOfDay, new TimeSpan(4, 0, 0)) <= 0;
            } else
            {
                return TimeSpan.Compare(timeOfDay, Assumptions.SleepingTime) >= 0 || TimeSpan.Compare(timeOfDay, new TimeSpan(0, 0, 0)) >=0;
            }
        }

        public void SetNextLocation(double lat, double lng)
        {
            NextLocation = Location.Create(lat, lng);
        }

        public void SetCurrentLocation(double lat, double lng)
        {
            CurrentLocation = Location.Create(lat, lng);
        }

        public void ClearIfEndOfCurrentDay()
        {
            if(IsSleep)
            {
                WasBreakfast = false;
                WasLunch = false;
                WasDinner = false;
                IsSleep = false;
            }
        }

        public DateTime CreateEndDateTime(TimeSpan duration)
        {
            return CurrentDateTime.Add(duration);
        }

        public void CheckNextMeal()
        {
            if (!WasBreakfast)
            {
                WasBreakfast = true;
                return;
            } else if (!WasLunch)
            {
                WasLunch = true;
                return;
            } else if(!WasDinner)
            {
                WasDinner = true;
                return;
            }
                
        }

        public int WhichMeal
        {
            get
            {
                if (!WasBreakfast)
                    return 1;
                else if (WasBreakfast && !WasLunch)
                    return 2;
                else
                    return 3;
            }
        }
    }
}
