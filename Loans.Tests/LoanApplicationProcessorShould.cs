using System;
using Loans.Domain.Applications;
using NUnit.Framework;
using Moq;

namespace Loans.Tests
{
    public class LoanApplicationProcessorShould
    {
        [Test]
        public void DeclineLowSalary()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42, product, amount, "Sarah", 25, "133 Pluralsight Drive, Draper, Utah", 64_999);

            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            var mockCreditScorer = new Mock<ICreditScorer>();

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockCreditScorer.Object);

            sut.Process(application);

            Assert.That(application.GetIsAccepted(), Is.False);
        }

        [Test]
        public void Accept()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42, product, amount, "Sarah", 25, "133 Pluralsight Drive, Draper, Utah", 65_000);

            // setting up a mock method return
            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            mockIdentityVerifier.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<int>(), "133 Pluralsight Drive, Draper, Utah")).Returns(true);

            // setting up a mock property
            var mockCreditScorer = new Mock<ICreditScorer>();
            mockCreditScorer.Setup(x => x.Score).Returns(300);

            // manully setting up a mock property hierarchy
            // CreditScorer -> ScoreResult -> ScoreValue
            //var mockScoreValue = new Mock<ScoreValue>();
            //mockScoreValue.Setup(x => x.Score).Returns(300);
            //var mockScoreResult = new Mock<ScoreResult>();
            //mockScoreResult.Setup(x => x.ScoreValue).Returns(mockScoreValue.Object);
            //mockCreditScorer.Setup(x => x.ScoreResult).Returns(mockScoreResult.Object);

            // Getting moq to create the hierarchy of object
            // Moq creates each of the objects in the hierarchy, all the properties in hierarchy must be virtual
            mockCreditScorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);

            // Tracking changes to properties
            // Can provide an initial value with a second argument
            mockCreditScorer.SetupProperty(x => x.Count);
            // Can use the below to setup all properties but it will overwrite any previous setup, so use it first!
            //mockCreditScorer.SetupAllProperties();

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockCreditScorer.Object);

            sut.Process(application);

            // Check property was accessed, number of times is optional
            mockCreditScorer.VerifyGet(x => x.ScoreResult.ScoreValue.Score, Times.Once);
            // Check property was set
            mockCreditScorer.VerifySet(x => x.Count = It.IsAny<int>());

            Assert.That(application.GetIsAccepted(), Is.True);

            Assert.That(mockCreditScorer.Object.Count, Is.EqualTo(1));
        }

        [Test]
        public void NullReturnExample()
        {
            var mock = new Mock<INullExample>();

            // mock Setup method returns null by default but you can specify as shown below
            mock.Setup(x => x.SomeMethod());
                //.Returns<string>(null);

            string mockReturnValue = mock.Object.SomeMethod();

            Assert.That(mockReturnValue, Is.Null);
        }

        [Test]
        public void InitializeIdentityVerifier()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42, product, amount, "Sarah", 25, "133 Pluralsight Drive, Draper, Utah", 65_000);

            // setup mocks
            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            mockIdentityVerifier.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<int>(), "133 Pluralsight Drive, Draper, Utah")).Returns(true);

            var mockCreditScorer = new Mock<ICreditScorer>();
            mockCreditScorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockCreditScorer.Object);

            sut.Process(application);

            // Testing if initialize is called
            mockIdentityVerifier.Verify(x => x.Initialize());

            mockIdentityVerifier.Verify(x => x.Validate(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));

            // Testing if we tested method and property has been called
            mockIdentityVerifier.VerifyNoOtherCalls();
        }

        [Test]
        public void CalculateScore()
        {
            LoanProduct product = new LoanProduct(99, "Loan", 5.25m);
            LoanAmount amount = new LoanAmount("USD", 200_000);
            var application = new LoanApplication(42, product, amount, "Sarah", 25, "133 Pluralsight Drive, Draper, Utah", 65_000);

            // setup mocks
            var mockIdentityVerifier = new Mock<IIdentityVerifier>();
            mockIdentityVerifier.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<int>(), "133 Pluralsight Drive, Draper, Utah")).Returns(true);

            var mockCreditScorer = new Mock<ICreditScorer>();
            mockCreditScorer.Setup(x => x.ScoreResult.ScoreValue.Score).Returns(300);

            var sut = new LoanApplicationProcessor(mockIdentityVerifier.Object, mockCreditScorer.Object);

            sut.Process(application);

            // Testing if method called with specific values or values of a given type and optionally, how many times it was called
            mockCreditScorer.Verify(x => x.CalculateScore(
                It.IsAny<string>(),
                "133 Pluralsight Drive, Draper, Utah"),
                Times.AtLeastOnce);
        }
    } 
    
    public interface INullExample
    {
        string SomeMethod();
    }
}
