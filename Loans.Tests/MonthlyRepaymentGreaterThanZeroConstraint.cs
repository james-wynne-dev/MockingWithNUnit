using Loans.Domain.Applications;
using NUnit.Framework.Constraints;

namespace Loans.Tests
{
    class MonthlyRepaymentGreaterThanZeroConstraint : Constraint
    {
        public string ExpectedProductName { get; }
        public decimal ExpectedInterestRate { get; }

        public MonthlyRepaymentGreaterThanZeroConstraint(string expectedProductName, 
                                                         decimal expectedInterestRate)
        {
            ExpectedProductName = expectedProductName;
            ExpectedInterestRate = expectedInterestRate;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            MonthlyRepaymentComparison comparison = actual as MonthlyRepaymentComparison;

            if (comparison is null)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            }

            if (comparison.InterestRate == ExpectedInterestRate && 
                comparison.ProductName == ExpectedProductName && 
                comparison.MonthlyRepayment > 0)
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            }

            return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
}
