using Loans.Domain.Applications;
using NUnit.Framework;
using System;

namespace Loans.Tests
{
    public class LoanTermShould
    {
        [Test]        
        public void ReturnTermInMonths()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years");
        }


        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);

            Assert.That(sut.Years, Is.EqualTo(1));
        }


        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void RespectValueInequality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);

            Assert.That(a, Is.Not.EqualTo(b));
        }


        [Test]
        public void NotAllowZeroYears()
        {
            Assert.That(() => new LoanTerm(0), 
                        Throws.TypeOf<ArgumentOutOfRangeException>()
                              .With
                              .Matches<ArgumentOutOfRangeException>(
                                       ex => ex.ParamName == "years"));
        }
    }
}
