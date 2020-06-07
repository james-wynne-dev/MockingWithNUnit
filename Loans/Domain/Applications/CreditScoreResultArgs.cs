using System;

namespace Loans.Domain.Applications
{
    public class CreditScoreResultArgs : EventArgs
    {
        public int Score { get; set; }        
    }
}