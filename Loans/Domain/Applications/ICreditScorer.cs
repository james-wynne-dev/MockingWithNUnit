namespace Loans.Domain.Applications
{
    public interface ICreditScorer
    {
        int Score { get; }

        void CalculateScore(string applicantName, string applicantAddress);
    }
}