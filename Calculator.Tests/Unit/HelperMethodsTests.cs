using Calculator.API.Helper;
using Calculator.API.Models.Enums;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class HelperMethodsTests
    {
        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(0, 100, 0)]
        [InlineData(10, 100, 10)]
        [InlineData(8.55, 1055, 90.20)]
        public void InterestValue_Returns_Decimal_and_Correct_Value(double interest, decimal value, decimal expected)
        {
            var result = HelperMethods.InterestValue(interest, value);

            result.Should().Be(expected);
            result.Should().BeOfType(typeof(decimal));
        }

        [Theory]
        [InlineData(0, 100, 5, 100)]
        [InlineData(10, 1000, 2, 826.45)]
        [InlineData(1.25, 100, 1, 98.77)]
        [InlineData(1.25, 100, 0, 100)]
        public void ValueAfterInflation_Returns_Decimal_and_Correct_Value(double inflation, decimal value, int years, decimal expected)
        {
            var result = HelperMethods.ValueAfterInflation(inflation, value, years);

            result.Should().Be(expected);
            result.Should().BeOfType(typeof(decimal));
        }

        [Theory]
        [InlineData(0, CompoundPeriod.Annually, 0)]
        [InlineData(10, CompoundPeriod.Annually, 10)]
        [InlineData(5, CompoundPeriod.Semestrial, 5 + 0.25)]
        [InlineData(4.5, CompoundPeriod.Quarterly, 4.5 + 0.381)]
        [InlineData(5.25, CompoundPeriod.Monthly, 5.25 + 0.471)]
        [InlineData(1, CompoundPeriod.Semimonthly, 1 + 0.494)]
        [InlineData(0.75, CompoundPeriod.Weekly, 0.75 + 0.506)]
        public void CalculateCompound_Returns_Double_and_Correct_Value(double interest, CompoundPeriod period, double expected)
        {
            var result = HelperMethods.CalculateCompound(interest, period);

            result.Should().Be(expected);
            result.Should().BeOfType(typeof(double));
        }
    }
}