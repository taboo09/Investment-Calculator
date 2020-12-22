using System.Collections.Generic;

namespace Calculator.API.Models
{
    public class ResponseBase
    {
        public decimal EndBalance { get; set; }
        public decimal StartPrincipal { get; set; }
        public decimal TotalContribution { get; set; }
        public decimal TotalInterest { get; set; }
        public List<InterestSchedule> InterestSchedule { get; set; }
    }
}