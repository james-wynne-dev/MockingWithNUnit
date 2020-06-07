using Loans.Domain;
using System;
using System.Collections.Generic;

namespace Loans.Domain.Applications
{
    public class LoanTerm : ValueObject
    {
        public int Years { get; }        

        // Explicitly stating to hide dealt constructor to indicate immutability
        private LoanTerm(){}

        public LoanTerm(int years)
        {
            if (years < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(years), 
                    "Please specify a value greater than 0.");
            }

            Years = years;
        }

        public int ToMonths() => Years * 12;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Years;
        }        
    }
}
