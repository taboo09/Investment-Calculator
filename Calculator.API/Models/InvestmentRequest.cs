using System.ComponentModel.DataAnnotations;
using Calculator.API.Models.Enums;

namespace Calculator.API.Models
{
    public class InvestmentRequest : RequestBase
    {
        public ContributionPeriod ContributionPeriod { get; set; }
        
        public ContributionPlan ContributionPlan { get; set; }
    }
}