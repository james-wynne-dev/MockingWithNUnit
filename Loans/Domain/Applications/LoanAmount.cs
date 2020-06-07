using System.Collections.Generic;

namespace Loans.Domain.Applications
{
    public class LoanAmount : ValueObject
    {
        public string CurrencyCode { get; }
        public decimal Principal { get; }
        
        private LoanAmount(){}

        public LoanAmount(string currencyCode, decimal principal)
        {
            CurrencyCode = currencyCode;
            Principal = principal;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CurrencyCode;
            yield return Principal;
        }        
    }
}
