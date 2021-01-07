using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarComparisonTool.Models;

namespace CarComparisonTool.HelperClasses
{
    public class AutoMappperHelper: Profile
    {
        public AutoMappperHelper()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }
}
