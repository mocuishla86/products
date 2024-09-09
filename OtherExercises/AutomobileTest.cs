using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherExercises
{
    public class AutomobileTest
    {
        [Fact]
        public void ItCalculatesEficiency ()
        {
            Automobile automobile = new()
            {
                Brand = "Opel",
                Model = "Corsa",
                Year = 1996,
                FuelType = FuelType.Diesel,
            };
            automobile.ConsumedFuelInLiters = 25;
            automobile.TraveledDistanceInKm = 250;

            double actualEficiency = automobile.CalculateEficienty();

            actualEficiency.Should().Be(10);
        }
    }
}
