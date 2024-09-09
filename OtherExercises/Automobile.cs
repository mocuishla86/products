using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherExercises
{
    public class Automobile : Vehicle
    {
        public FuelType FuelType { get; set; }

        public double TraveledDistanceInKm {  get; set; }

        public double ConsumedFuelInLiters { get; set; }

        public double CalculateEficienty()
        {
            return TraveledDistanceInKm / ConsumedFuelInLiters;
        }
    }

    public enum FuelType { Diesel, Gasoline }

}
