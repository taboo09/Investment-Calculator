using System;
using Calculator.API.Models;
using Calculator.API.Service.Interfaces;
using Calculator.API.Models.Enums;

namespace Calculator.API.Service
{
    public class InterestCalculator : ICalculator
    {
        public InterestResponse InterestResult(InterestRequest request)
        {
            if (request.PeriodYears == 0) return null;

            var response = new InterestResponse();

            var startPrincipal = request.InvestmentPeriod == Period.End ?
                request.StartPrincipal :
                request.StartPrincipal + request.ContributionValue;

            var startBalance = startPrincipal;

            var endPrincipal = request.StartPrincipal + request.ContributionValue;

            var endBalance = endPrincipal;
            
            decimal interest = 0;
            decimal tax = 0;

            // calculate interest rate
            request.InterestRate = CalculateCompound(request.InterestRate, request.CompoundPeriod);

            for (int i = 0; i < request.PeriodYears; i++)
            {
                // interest
                interest = InterestValue(request.InterestRate, startBalance);
                response.TotalInterest += interest;

                // tax
                tax = InterestValue(request.TaxRate, interest);
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
                    tax                   
                );

                response.InterestSchedule.Add(interestSchedule);

                startBalance = request.InvestmentPeriod == Period.End ? endBalance :
                    endBalance + request.ContributionValue;
                startPrincipal +=  request.ContributionValue;
                endPrincipal +=  request.ContributionValue;                
            }

            // inflation adjustment
            response.InflationAdjustment = ValueAfterInflation(request.InflationRate, endBalance, request.PeriodYears);

            response.EndBalance = endBalance;
            response.TotalContribution = endPrincipal - request.ContributionValue;
            response.StartPrincipal = request.StartPrincipal;

            return response;
        }

        private decimal InterestValue(double interest, decimal value)
        {
            if (interest == 0 || value == 0) return 0;

            var result = (Convert.ToDecimal(interest) * value) / 100;

            return Decimal.Round(result, 2);
        }

        private decimal ValueAfterInflation(double inflation, decimal value, int years)
        {
            if (inflation == 0) return value;

            var inflationDecimal = Convert.ToDecimal(inflation);

            for (int i = 0; i < years; i++)
            {
                value = value / ((100 + inflationDecimal) / 100);
            }

            return Decimal.Round(value, 2);
        }

        private double CalculateCompound(double interest, CompoundPeriod period)
        {
            if (interest == 0) return 0;

            double compound;

            switch (period)
            {
                case CompoundPeriod.Annually:
                    compound = interest;
                    break;
                case CompoundPeriod.Semestrial:
                    // interest splitted in 2
                    compound = interest + 0.25;
                    break;
                case CompoundPeriod.Quarterly:
                    // interest splitted in 4
                    compound = interest + 0.381;
                    break;
                case CompoundPeriod.Monthly:
                    // interest splitted in 12
                    compound = interest + 0.471;
                    break;
                case CompoundPeriod.Semimonthly:
                    // interest splitted in 26
                    compound = interest + 0.494;
                    break;
                case CompoundPeriod.Weekly:
                    // interest splitted in 52
                    compound = interest + 0.506;
                    break;
                default:
                    return interest;
            }

            return compound;
        }

        public InvestmentResponse InvestmentResult(InvestmentRequest investmentRequest)
        {
            throw new NotImplementedException();
        }
    }
}