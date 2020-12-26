using Calculator.API.Models;
using Calculator.API.Service;
using Calculator.API.Service.Interfaces;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class Service_Calculator_InvestmentMonthlyTests
    {
        private readonly ICalculator _calculator;
        public Service_Calculator_InvestmentMonthlyTests()
        {
            _calculator = new InterestCalculator();
        }

        [Fact]
        public void InvestmentMonthly_returns_empty_response_when_years_0()
        {
            var request = new InvestmentRequest
            {
                StartPrincipal = 1000,
                ContributionValue = 1000,
                InterestRate = 10,
                PeriodYears = 0
            };

            var result = _calculator.InvestmentMonthly(request);

            result.Should().BeOfType<InvestmentResponse>();
            result.EndBalance.Should().Be(0);
            result.TotalInterest.Should().Be(0);
            result.TotalContribution.Should().Be(0);
            result.StartPrincipal.Should().Be(0);
            result.InterestSchedule.Should().HaveCount(0);
        }

        [Theory]
        [InlineData(0, 10, 100, 2, 244.68, 2644.68)]
        [InlineData(1000, 0, 100, 2, 0, 3400.00)]
        [InlineData(1000, 10, 0, 2, 220.40, 1220.40)]
        [InlineData(1000, 10, 100, 2, 465.08, 3865.08)]
        [InlineData(100, 2.5, 50, 10, 836.88, 6936.88)]
        public void InvestmentMonthly_returns_investment_response(
            decimal start, 
            double interest, 
            decimal contribution,
            int years,
            decimal totalInterest,
            decimal endBalance)
        {
            var request = new InvestmentRequest
            {
                StartPrincipal = start,
                ContributionValue = contribution,
                InterestRate = interest,
                PeriodYears = years
            };

            var result = _calculator.InvestmentMonthly(request);

            result.Should().BeOfType<InvestmentResponse>();
            result.EndBalance.Should().Be(endBalance);
            result.TotalInterest.Should().Be(totalInterest);
            result.TotalContribution.Should().Be(contribution * years * 12);
            result.StartPrincipal.Should().Be(start);
            result.InterestSchedule.Should().HaveCount(years * 12);
        }
    }
}