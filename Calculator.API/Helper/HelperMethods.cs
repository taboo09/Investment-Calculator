using System;
using Calculator.API.Models.Enums;

namespace Calculator.API.Helper
{
    public class HelperMethods
    {
        public static decimal InterestValue(double interest, decimal value)
        {
            if (interest == 0 || value == 0) return 0;

            var result = (Convert.ToDecimal(interest) * value) / 100;

            return Decimal.Round(result, 2);
        }

        public static decimal ValueAfterInflation(double inflation, decimal value, int years)
        {
            if (inflation == 0) return value;

            var inflationDecimal = Convert.ToDecimal(inflation);

            for (int i = 0; i < years; i++)
            {
                value = value / ((100 + inflationDecimal) / 100);
            }

            return Decimal.Round(value, 2);
        }

        public static double CalculateCompound(double interest, CompoundPeriod period)
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
    }
}