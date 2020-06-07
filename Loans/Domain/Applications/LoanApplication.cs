using System;

namespace Loans.Domain.Applications
{
    public class LoanApplication : Entity
    {
        private LoanProduct _product;
        private LoanAmount _amount;
        private string _applicantName;
        private int _applicantAge;
        private string _applicantAddress;
        private decimal _applicantSalary;
        private bool _isAccepted;

        protected LoanApplication() { }

        public LoanApplication(int id, 
                               LoanProduct product, 
                               LoanAmount amount, 
                               string applicantName, 
                               int applicantAge, 
                               string applicantAddress, 
                               decimal applicantSalary)
        {
            Id = id;
            _product = product;
            _amount = amount;
            _applicantName = applicantName;
            _applicantAge = applicantAge;
            _applicantAddress = applicantAddress;
            _applicantSalary = applicantSalary;
        }        

        public LoanProduct GetProduct()
        {
            return _product;
        }

        public LoanAmount GetAmount()
        {
            return _amount;
        }

        public string GetApplicantName()
        {
            return _applicantName;
        }

        public int GetApplicantAge()
        {
            return _applicantAge;
        }

        public string GetApplicantAddress()
        {
            return _applicantAddress;
        }

        public decimal GetApplicantSalary()
        {
            return _applicantSalary;
        }

        public bool GetIsAccepted()
        {
            return _isAccepted;
        }

        public void Accept()
        {
            _isAccepted = true;
        }

        public void Decline()
        {
            _isAccepted = false;
        }
    }
}
