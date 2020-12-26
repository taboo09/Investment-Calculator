using System.ComponentModel.DataAnnotations;

namespace Calculator.API.Models
{
    public class RequestBase
    {
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal StartPrincipal { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal ContributionValue { get; set; }

        [Range(0, 100_000, ErrorMessage = "Please enter a positive value")]
        public double InterestRate { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter a positive value")]
        public int PeriodYears { get; set; }
    }
}