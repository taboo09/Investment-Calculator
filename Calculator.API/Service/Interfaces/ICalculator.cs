using Calculator.API.Models;

namespace Calculator.API.Service.Interfaces
{
    public interface ICalculator
    {
        InterestResponse InterestResult(InterestRequest interestRequest);
        InvestmentResponse InvestmentMonthly(InvestmentRequest investmentRequest);
    }
}