using AutoMapper;
using CarComparisonTool.Data;
using CarComparisonTool.HelperClasses;
using CarComparisonTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Services
{
    public class CarService: ICarService
    {
        private readonly ICarData _carDataRepo;
        private readonly IMapper _mapper;
        private IEnumerable<Car> _cars;
        public CarService(ICarData carDataRepo, IMapper mapper)
        {
            _carDataRepo = carDataRepo;
            _mapper = mapper;
        }
        public IEnumerable<Car> GetAlphabetizedCarList(bool isDecending = false)
        {
            _cars = _carDataRepo.GetCarData();
            return _cars;
        }

        public IEnumerable<YearAverage> GetAverageMPGByYear()
        {

            var avgByYear = _carDataRepo.GetCarData().GroupBy(s => s.Year)
                     .Select(g => new YearAverage { Year = g.Key, Avg = g.Average(s => s.HwyMPG) });

            return avgByYear;
        }

        public IEnumerable<CarDTO> GetBestValue(int numberOfYears)
        {
            var cars = _carDataRepo.GetCarData().ToList();
            var carsWithValue = _mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);

            var averageFuelPrice = _carDataRepo.GetAverageFuelPrice();
            var milesPerYear = _carDataRepo.GetMilesPerYear();

            foreach (var car in carsWithValue)
            {
                if (numberOfYears > 0)
                {
                    car.BestValue = (float)car.Price + (float)((milesPerYear * numberOfYears / car.HwyMPG) * averageFuelPrice);
                }
                else
                {
                    car.BestValue = car.Price + ((milesPerYear  / car.HwyMPG) * averageFuelPrice);
                }
            }

            var minBestValue = carsWithValue.AsQueryable().Min(c => c.BestValue);
            return carsWithValue.Where(c=>c.BestValue == minBestValue).ToList();
        }

        public IEnumerable<Car> GetCarListOrderedByPrice(bool isDecending)
        {
            if (isDecending)
            {
                var cars = _carDataRepo.GetCarData()
                    .AsQueryable()
                    .OrderByDescending(c => c.Price)
                    .ToList();
                return cars;
            }

            return _carDataRepo.GetCarData()
                .AsQueryable()
                .OrderBy(c => c.Price)
                .ToList();
        }

        public IEnumerable<CarDTO> GetFuelConsumptionByDistance(float distance)
        {
            var cars = _carDataRepo.GetCarData().ToList();
            var carsWithFuelConsumption = _mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(cars);

            foreach (var car in carsWithFuelConsumption)
            {
                car.DistanceInMile = distance;
            }
             
            return carsWithFuelConsumption;
        }

        public IEnumerable<Car> GetNewestVehicles(int yearLimit)
        {
            if (yearLimit > 0)
            {
                var cars = _carDataRepo.GetCarData()
                    .AsQueryable()
                    .Where(c => c.Year >= yearLimit)
                    .OrderBy(c => c.Year)
                    .ThenBy(c => c.Make)
                    .ToList();
                return cars;
            }


            var maxYear = _carDataRepo.GetCarData().AsQueryable().Max(c => c.Year);

            return _carDataRepo.GetCarData()
                .AsQueryable()
                .Where(c => c.Year == maxYear)
                .OrderBy(c=>c.Make)
                .ToList();
        }

        public Car GetRandomCar()
        {
            var cars = _carDataRepo.GetCarData().ToArray();
            Random rnd = new Random();
            int index = rnd.Next(cars.Count());
            return cars[index];
        }
    }
}
