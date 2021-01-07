using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Models
{
    public class CarDTO
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public double TCCRating { get; set; }
        public int HwyMPG { get; set; }
        public double BestValue { get; set; }
        public float DistanceInMile { get; set; }
        public float FuelConsumption => DistanceInMile / (HwyMPG);
    }
}
