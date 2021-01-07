using Calculator.API.Models;
using Calculator.API.Service.Interfaces;
using Calculator.API.Models.Enums;
using Calculator.API.Helper;

namespace Calculator.API.Service
{
    public class InterestCalculator : ICalculator
    {
        public InterestResponse InterestResult(InterestRequest request)
        {
            var response = new InterestResponse();

            if (request.PeriodYears == 0) return response;

            var startPrincipal = request.InvestmentPeriod == Period.End ?
                request.StartPrincipal :
                request.StartPrincipal + request.ContributionValue;

            var startBalance = startPrincipal;

            var endPrincipal = request.StartPrincipal + request.ContributionValue;

            decimal endBalance = 0;
            decimal interest = 0;
            decimal tax = 0;

            // calculate interest rate
            request.InterestRate = HelperMethods.CalculateCompound(request.InterestRate, request.CompoundPeriod);

            for (int i = 0; i < request.PeriodYears; i++)
            {
                // interest
                interest = HelperMethods.InterestValue(request.InterestRate, startBalance);
                response.TotalInterest += interest;

                // tax
                tax = HelperMethods.InterestValue(request.TaxRate, interest);
                response.TotalTax += tax;

                // end balance
                endBalance = request.InvestmentPeriod == Period.End ?
                    startBalance + request.ContributionValue + interest - tax :
                    startBalance + interest - tax;

                var interestSchedule = new InterestSchedule(
                    startBalance,
                    endBalance,
                    startPrincipal,
                    endPrincipal,
                    interest,
                    response.TotalInterest,
                    tax                   
                );

                response.InterestSchedule.Add(interestSchedule);

                startBalance = request.InvestmentPeriod == Period.End ? endBalance :
                    endBalance + request.ContributionValue;
                startPrincipal +=  request.ContributionValue;
                endPrincipal +=  request.ContributionValue;                
            }

            // inflation adjustment
            response.InflationAdjustment = HelperMethods.ValueAfterInflation(request.InflationRate, endBalance, request.PeriodYears);

            response.EndBalance = endBalance;
            response.TotalContribution = endPrincipal - request.ContributionValue;
            response.StartPrincipal = request.StartPrincipal;

            return response;
        }

        public InvestmentResponse InvestmentMonthly(InvestmentRequest request)
        {
            var response = new InvestmentResponse();

            if (request.PeriodYears == 0) return response;

            var interestRate = request.InterestRate == 0 ? 0 : request.InterestRate / 12;
            decimal interest = 0;

            var startPrincipal = request.StartPrincipal;
            var startBalance = startPrincipal;
            var endPrincipal = startPrincipal + request.ContributionValue;
            decimal endBalance = 0;
            
            for (int i = 0; i < request.PeriodYears * 12; i++)
            {
                // interest
                interest = HelperMethods.InterestValue(interestRate, startBalance);
                response.TotalInterest += interest;

                endBalance = startBalance + request.ContributionValue + interest;

                var interestSchedule = new InterestSchedule(
                    startBalance,
                    endBalance,
                    startPrincipal,
                    endPrincipal,
                    interest,
                    response.TotalInterest,
                    0                   
                );

                response.InterestSchedule.Add(interestSchedule);

                startBalance = endBalance;
                startPrincipal += request.ContributionValue;
                endPrincipal += request.ContributionValue;
            }

            response.EndBalance = endBalance;
            response.TotalContribution = request.ContributionValue * request.PeriodYears * 12;
            response.StartPrincipal = request.StartPrincipal;

            return response;
        }
    }
}