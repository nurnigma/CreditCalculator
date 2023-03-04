using DecimalMath;
using CreditCalculator.Models;

namespace CreditCalculator.Utilities
{
    public static class LoanCalculator
    {
        public static List<Payment> Calculate(CreditTerms creditTerms)
        {
            var list = new List<Payment>();
            decimal residue = creditTerms.Sum;
            DateTime dateTime = DateTime.Now;

            decimal rate =
                creditTerms.CalculateType == CalculateType.ByMonth
                ? creditTerms.Rate / 100 / 12
                : creditTerms.Rate / 100;

            var paymentCount = creditTerms.Term / creditTerms.Step;

            for (int i = 1; i <= paymentCount; i++)
            {
                dateTime =
                    creditTerms.CalculateType == CalculateType.ByMonth
                        ? dateTime.AddMonths(creditTerms.Step)
                        : dateTime.AddDays(creditTerms.Step);

                decimal annuityRatio = rate * DecimalEx.Pow((1 + rate), paymentCount) / (DecimalEx.Pow((1 + rate), paymentCount) - 1);
                decimal annuityPayments = creditTerms.Sum * annuityRatio; //ануетный платеж 
                var percantage = residue * rate;
                var baseLoan = annuityPayments - percantage;
                residue -= baseLoan;

                list.Add(new Payment
                {
                    Id = i,
                    DateTime = dateTime,
                    PaymentOfTelo = annuityPayments,
                    PaymentPercentage = percantage,
                    BalanceOwed = residue
                });
            }

            return list;
        }

    }
}
