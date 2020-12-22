namespace Calculator.API.Models
{
    public class InterestSchedule
    {
        public InterestSchedule(
            decimal startBalance,
            decimal endBalance,
            decimal startPrincipal,
            decimal endPrincipal,
            decimal interest,
            decimal tax)
        {
            StartBalance = startBalance;
            EndBalance = endBalance;
            StartPrincipal = startPrincipal;
            EndPrincipal = endPrincipal;
            Interest = interest;
            Tax = tax;
        }
        
        public decimal StartBalance { get; set; }
        public decimal EndBalance { get; set; }
        public decimal StartPrincipal { get; set; }
        public decimal EndPrincipal { get; set; }
        public decimal Interest { get; set; }
        public decimal Tax { get; set; }
    }
}