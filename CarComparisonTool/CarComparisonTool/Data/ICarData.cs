using CarComparisonTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Data
{
    public interface ICarData
    {
        IEnumerable<Car> GetCarData();
        float GetAverageFuelPrice();
        float GetMilesPerYear();
    }
}
