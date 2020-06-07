using System;

namespace Loans.Domain.Applications
{
    public class IdentityVerifierServiceGateway : IIdentityVerifier
    {
        public DateTime LastCheckTime { get; private set; }

        public void Initialize()
        {
            // Initialize connection to external service
        }

        public bool Validate(string applicantName, int applicantAge, string applicantAddress)
        {
            Connect();
            var isValidIdentity = CallService(applicantName, applicantAge, applicantAddress);
            LastCheckTime = DateTime.Now;
            Disconnect();

            return isValidIdentity;
        }


        private void Connect()
        {
            // Open connection to external service
        }


        private bool CallService(string applicantName, int applicantAge, string applicantAddress)
        {
            // Make call to external service, interpret the response, and return result

            return false; // Simulate result for demo purposes
        }

        private void Disconnect()
        {
            // Close connection to external service
        }



        public void Validate(string applicantName, int applicantAge, string applicantAddress, out bool isValid)
        {
            throw new NotImplementedException();
        }

        public void Validate(string applicantName, int applicantAge, string applicantAddress, ref IdentityVerificationStatus status)
        {
            throw new NotImplementedException();
        }
    }
}