using Calculator.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Calculator.API.Models
{

    public class InterestRequest : RequestBase
    {
        public Period InvestmentPeriod { get; set; }
        public CompoundPeriod CompoundPeriod { get; set; }
        
        [Range(0, 100, ErrorMessage = "Please enter a positive value")]
        public double TaxRate { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter a positive value")]
        public double InflationRate { get; set; }
    }
}