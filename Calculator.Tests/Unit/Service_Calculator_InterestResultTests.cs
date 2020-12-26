using Calculator.API.Models;
using Calculator.API.Models.Enums;
using Calculator.API.Service;
using Calculator.API.Service.Interfaces;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class Service_Calculator_InterestResultTests
    {
        private readonly int _yearsPeriod = 5;
        private readonly double _inflation = 2.5;
        private readonly double _tax = 1.5;
        private readonly ICalculator _calculator;

        public Service_Calculator_InterestResultTests()
        {
            _calculator = new InterestCalculator();
        }

        [Fact]
        public void InterestResult_returns_empty_response_when_years_0()
        {
            var request = new InterestRequest
            {
                StartPrincipal = 1000,
                InterestRate = 10,
                ContributionValue = 1000,
                PeriodYears = 0,
                InvestmentPeriod = Period.Beginning,
                CompoundPeriod = CompoundPeriod.Weekly
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(0);
            result.TotalInterest.Should().Be(0);
            result.TotalContribution.Should().Be(0);
            result.InterestSchedule.Should().HaveCount(0);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6715.61, 1715.61)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1610.51, 610.51)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 8326.12, 2326.12)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 8393.33, 2393.33)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 8428.76, 2428.76)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 8453.17, 2453.17)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 8459.41, 2459.41)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 8462.69, 2462.69)]
        public void InterestResult_tax_0_inflation_0_beginning_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.Beginning,
                CompoundPeriod = compoundPeriod
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6105.10, 1105.10)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1610.51, 610.51)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 7715.61, 1715.61)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 7764.47, 1764.47)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 7790.18, 1790.18)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 7807.89, 1807.89)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 7812.42, 1812.42)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 7814.79, 1814.79)]
        public void InterestResult_tax_0_inflation_0_end_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.End,
                CompoundPeriod = compoundPeriod
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6715.61, 1715.61, 5935.62)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1610.51, 610.51, 1423.46)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 5303.13)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 8326.12, 2326.12, 7359.08)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 8393.33, 2393.33, 7418.48)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 8428.76, 2428.76, 7449.80)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 8453.17, 2453.17, 7471.37)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 8459.41, 2459.41, 7476.89)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 8462.69, 2462.69, 7479.78)]
        public void InterestResult_tax_0_inflation_2_5_beginning_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal afterInflation)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.Beginning,
                CompoundPeriod = compoundPeriod,
                InflationRate = _inflation
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.InflationAdjustment.Should().Be(afterInflation);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6105.10, 1105.10, 5396.02)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1610.51, 610.51, 1423.46)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 5303.13)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 7715.61, 1715.61, 6819.47)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 7764.47, 1764.47, 6862.66)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 7790.18, 1790.18, 6885.38)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 7807.89, 1807.89, 6901.04)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 7812.42, 1812.42, 6905.04)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 7814.79, 1814.79, 6907.14)]
        public void InterestResult_tax_0_inflation_2_5_end_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal afterInflation)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.End,
                CompoundPeriod = compoundPeriod,
                InflationRate = _inflation
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.InflationAdjustment.Should().Be(afterInflation);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6686.45, 1712.14, 25.69)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1599.56, 608.69, 9.13)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 0)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 8286.01, 2320.82, 34.81)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 8351.94, 2387.76, 35.82)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 8386.68, 2423.03, 36.35)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 8410.61, 2447.33, 36.72)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 8416.74, 2453.55, 36.81)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 8419.95, 2456.79, 36.84)]
        public void InterestResult_tax_1_5_inflation_0_beginning_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal totalTax)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.Beginning,
                CompoundPeriod = compoundPeriod,
                TaxRate = _tax
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.TotalTax.Should().Be(totalTax);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6086.89, 1103.45, 16.56)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1599.56, 608.69, 9.13)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 0)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Annually, 7686.45, 1712.14, 25.69)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semestrial, 7734.38, 1760.79, 26.41)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Quarterly, 7759.60, 1786.40, 26.80)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Monthly, 7777.00, 1804.05, 27.05)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Semimonthly, 7781.45, 1808.57, 27.12)]
        [InlineData(1000, 10D, 1000, CompoundPeriod.Weekly, 7783.77, 1810.93, 27.16)]
        public void InterestResult_tax_1_5_inflation_0_end_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal totalTax)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.End,
                CompoundPeriod = compoundPeriod,
                TaxRate = _tax
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.TotalTax.Should().Be(totalTax);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6686.45, 1712.14, 5909.85, 25.69)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1599.56, 608.69, 1413.78, 9.13)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 5303.13, 0)]
        public void InterestResult_tax_1_5_inflation_2_5_beginning_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal afterInflation,
            decimal totalTax)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.Beginning,
                CompoundPeriod = compoundPeriod,
                InflationRate = _inflation,
                TaxRate = _tax
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.InflationAdjustment.Should().Be(afterInflation);
            result.TotalTax.Should().Be(totalTax);
        }

        [Theory]
        [InlineData(0, 10D, 1000, CompoundPeriod.Annually, 6086.89, 1103.45, 5379.92, 16.56)]
        [InlineData(1000, 10D, 0, CompoundPeriod.Annually, 1599.56, 608.69, 1413.78, 9.13)]
        [InlineData(1000, 0D, 1000, CompoundPeriod.Annually, 6000, 0, 5303.13, 0)]
        public void InterestResult_tax_1_5_inflation_2_5_end_of_year(
            decimal start, 
            double interest, 
            decimal contribution,
            CompoundPeriod compoundPeriod,
            decimal endBalane,
            decimal totalInterest,
            decimal afterInflation,
            decimal totalTax)
        {
            var request = new InterestRequest
            {
                StartPrincipal = start,
                InterestRate = interest,
                ContributionValue = contribution,
                PeriodYears = _yearsPeriod,
                InvestmentPeriod = Period.End,
                CompoundPeriod = compoundPeriod,
                InflationRate = _inflation,
                TaxRate = _tax
            };

            var result = _calculator.InterestResult(request);

            result.Should().BeOfType<InterestResponse>();
            result.EndBalance.Should().Be(endBalane);
            result.TotalContribution.Should().Be(start + contribution * _yearsPeriod);
            result.TotalInterest.Should().Be(totalInterest);
            result.InterestSchedule.Should().HaveCount(_yearsPeriod);
            result.InflationAdjustment.Should().Be(afterInflation);
            result.TotalTax.Should().Be(totalTax);
        }
    }
}