using System.Collections.Generic;

namespace Calculator.API.Models
{

    public class InterestResponse : ResponseBase
    {
        public InterestResponse()
        {
            InterestSchedule = new List<InterestSchedule>();
        }

        public decimal InflationAdjustment { get; set; }
        public decimal TotalTax { get; set; }
    }
}