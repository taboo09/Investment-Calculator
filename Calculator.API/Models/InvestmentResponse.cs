using System.Collections.Generic;

namespace Calculator.API.Models
{
    public class InvestmentResponse : ResponseBase
    {
        public InvestmentResponse()
        {
            InterestSchedule = new List<InterestSchedule>();
        }
    }
}