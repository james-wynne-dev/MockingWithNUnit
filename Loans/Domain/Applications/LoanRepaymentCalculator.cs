using System;

namespace Loans.Domain.Applications
{
    public class LoanRepaymentCalculator
    {
        public decimal CalculateMonthlyRepayment(LoanAmount loanAmount, decimal annualInterestRate, LoanTerm loanTerm)
        {
            var monthly = (double)annualInterestRate / 100 / 12 * (double)loanAmount.Principal / (1 - Math.Pow(1 + ((double)annualInterestRate / 100 / 12), -loanTerm.ToMonths()));

            return new decimal(Math.Round(monthly, 2, MidpointRounding.AwayFromZero));
        }
    }
}
