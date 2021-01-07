using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarComparisonTool.Models
{
    public class YearAverage
    {
        public int Year { get; set; }
        public double Avg { get; set; }
    }
}
