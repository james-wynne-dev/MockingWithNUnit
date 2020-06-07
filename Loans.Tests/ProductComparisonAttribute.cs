using NUnit.Framework;
using System;

namespace Loans.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    class ProductComparisonAttribute : CategoryAttribute
    {
    }
}
