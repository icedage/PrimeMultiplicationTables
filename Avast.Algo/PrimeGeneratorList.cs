using System;
using System.Collections.Generic;
using System.Linq;

namespace Avast.Algo
{
    public class PrimeGeneratorList
    {
        public IEnumerable<int> GeneratePrimes(int number)
        {
            return Primes().Take(number);
        }

        static IEnumerable<int> Primes()
        {
            var inMemory = new List<int>();

            var primeNumbers = Enumerable.Range(2, int.MaxValue - 2).Select(number => new
            {
                Sqrt = (int)Math.Sqrt(number), 
                Current = number
            }).Where(number => !inMemory.TakeWhile(c => c <= number.Sqrt)
              .Any(cachedNumber => number.Current % cachedNumber == 0))
              .Select(p => p.Current);

            foreach (var prime in primeNumbers)
            {
                inMemory.Add(prime);
                yield return prime;
            }
        }
     }
}
