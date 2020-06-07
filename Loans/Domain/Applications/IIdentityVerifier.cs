namespace Loans.Domain.Applications
{
    public interface IIdentityVerifier
    {
        void Initialize();

        bool Validate(string applicantName, 
                      int applicantAge, 
                      string applicantAddress);


        void Validate(string applicantName, 
                      int applicantAge, 
                      string applicantAddress, 
                      out bool isValid);

        void Validate(string applicantName, 
                      int applicantAge, 
                      string applicantAddress, 
                      ref IdentityVerificationStatus status);
    }
}