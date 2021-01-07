using CarComparisonTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Data
{
    public class CarData: ICarData
    {
        private static readonly IEnumerable<Car> Cars = new Car[]
        {           
            new Car { Make="Honda", Model ="CRV", Color="Green", Year=2016, Price=23845, TCCRating= 8, HwyMPG = 33},
            new Car { Make="Ford", Model ="Escape", Color="Red", Year=2017, Price=23590, TCCRating= 7.8, HwyMPG = 32},
            new Car { Make="Hyundai", Model ="Sante Fe", Color="Grey", Year=2016, Price=24950, TCCRating= 8, HwyMPG = 27},
            new Car { Make="Mazda", Model ="CX-5", Color="Red", Year=2017, Price=21795, TCCRating= 8, HwyMPG = 35},
            new Car { Make="Subaru", Model ="Forester", Color="Blue", Year=2016, Price=22395, TCCRating= 8.4, HwyMPG = 32}
        };

        private static readonly float MilesPerYear = 10000.00f;
        private static readonly float AverageFuelPricePerGalon = 2.15f;

        public IEnumerable<Car> GetCarData()
        {
            return Cars.ToList();
        }

        public float GetAverageFuelPrice()
        {
            return AverageFuelPricePerGalon;
        }

        public float GetMilesPerYear()
        {
            return MilesPerYear;
        }
    }
}
