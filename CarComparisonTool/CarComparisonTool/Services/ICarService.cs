using CarComparisonTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetNewestVehicles(int yearLimit);
        IEnumerable<Car> GetAlphabetizedCarList(bool isDecending = false);
        IEnumerable<Car> GetCarListOrderedByPrice(bool isDecending = false);
        IEnumerable<CarDTO> GetBestValue(int numberOfYears);
        IEnumerable<CarDTO> GetFuelConsumptionByDistance(float distance);
        Car GetRandomCar();
        IEnumerable<YearAverage> GetAverageMPGByYear();
    }
}
