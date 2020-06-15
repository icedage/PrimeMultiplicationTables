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
            List<int> cache = new List<int>();

            var primeNumbers = Enumerable.Range(2, int.MaxValue - 2).Select(candidate => new
            {
                Sqrt = (int)Math.Sqrt(candidate), 
                Current = candidate
            }).Where(number => !cache.TakeWhile(c => c <= number.Sqrt)
                    .Any(cachedNumber => number.Current % cachedNumber == 0))
                    .Select(p => p.Current);

            foreach (var prime in primeNumbers)
            {
                cache.Add(prime);
                yield return prime;
            }
        }
     }
}
