using System;
using System.Collections.Generic;

namespace Loans.Domain.Applications
{
    public class ProductComparer
    {
        private readonly LoanAmount _loanAmount;
        private readonly List<LoanProduct> _productsToCompare;

        public ProductComparer(LoanAmount loanAmount, List<LoanProduct> productsToCompare)
        {
            _loanAmount = loanAmount;
            _productsToCompare = productsToCompare;
        }

        public List<MonthlyRepaymentComparison> CompareMonthlyRepayments(LoanTerm loanTerm)
        {
            var calculator = new LoanRepaymentCalculator();

            var compared = new List<MonthlyRepaymentComparison>();

            foreach (var product in _productsToCompare)
            {
                decimal repayment = calculator.CalculateMonthlyRepayment(_loanAmount, product.GetInterestRate(), loanTerm);
                compared.Add(new MonthlyRepaymentComparison(product.GetProductName(), product.GetInterestRate(), repayment));
            }

            return compared;
        }
    }
}
