using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarComparisonTool.Models;
using CarComparisonTool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarComparisonTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAlphabetizedCarList/{isDecending:bool?}")]
        public ActionResult<IEnumerable<Car>> GetAlphabetizedCarList(bool isDecending=false)
        {
            if (isDecending)
            {
                var cars= _carService.GetAlphabetizedCarList()
                    .AsQueryable()
                    .OrderByDescending(c=> c.Make)
                    .ToList();
                return cars;
            }  

            return _carService.GetAlphabetizedCarList()
                .AsQueryable()
                .OrderBy(c => c.Make)
                .ToList();
        }

        [HttpGet("GetNewestVehicles/{year:int?}")]
        public ActionResult<IEnumerable<Car>> GetNewestVehicles(int year=0)
        {
            var cars = _carService.GetNewestVehicles(year).ToList();
            return cars;
        }

        [HttpGet("GetCarListOrderedByPrice/{isDecending:bool?}")]
        public ActionResult<IEnumerable<Car>> GetCarListOrderedByPrice(bool isDecending =false)
        {
            var cars = _carService.GetCarListOrderedByPrice(isDecending).ToList();
            return cars;
        }

        [HttpGet("GetAverageMPGByYear")]
        public ActionResult<IEnumerable<YearAverage>> GetAverageMPGByYear()
        {
            var avgByYear = _carService.GetAverageMPGByYear().ToList();
            return avgByYear;
        }

        [HttpGet("GetFuelConsumptionByDistance/{distance}")]
        public ActionResult<IEnumerable<CarDTO>> GetFuelConsumptionByDistance(float distance)
        {
            var carsWithFuelConsumption = _carService.GetFuelConsumptionByDistance(distance).ToList();
            return carsWithFuelConsumption;
        }        
        
        [HttpGet("GetBestValue/{numberOfYears:int?}")]
        public ActionResult<IEnumerable<CarDTO>> GetBestValue(int numberOfYears=0)
        {
            var carsWithBestValue = _carService.GetBestValue(numberOfYears).ToList();
            return carsWithBestValue;
        }        
        
        [HttpGet("GetRandomCar")]
        public ActionResult<Car> GetRandomCar()
        {
            var randomCar = _carService.GetRandomCar();
            return randomCar;
        }
    }
}
