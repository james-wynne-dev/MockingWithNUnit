namespace Loans.Domain.Applications
{
    public class LoanProduct : Entity
    {
        private string _productName;
        private decimal _interestRate;

        protected LoanProduct() { }

        public LoanProduct(int id, string productName, decimal interestRate)
        {
            Id = id;
            _productName = productName;
            _interestRate = interestRate;
        }

        public string GetProductName()
        {
            return _productName;
        }

        public decimal GetInterestRate()
        {
            return _interestRate;
        }
    }
}
