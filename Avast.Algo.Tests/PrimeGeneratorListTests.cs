using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avast.Algo.Tests
{
    [TestFixture]
    public class PrimeGeneratorListTests
    {
        [TestCase(1, new int[] { 2 })]
        [TestCase(5, new int[] { 2, 3, 5, 7, 11 })]
        public void GeneratePrimes_SHould_Return_Prime_Numbers(int number, int[] expectedNumbers)
        {
            var primeGenerator = new PrimeGeneratorList();
            var numbers = primeGenerator.GeneratePrimes(number);
            CollectionAssert.AreEqual(expectedNumbers, numbers);
        }
    }
}
