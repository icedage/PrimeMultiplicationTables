using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Avast.Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeGenerator = new PrimeGeneratorList();
            var jaggedTable = new JaggedTable();
            Console.WriteLine("*********************************");

            while (true)
            {
                Console.WriteLine("Input whole number greater than 0:");
                var inputvalue = Console.ReadLine();
            
                var primes = primeGenerator.GeneratePrimes(int.Parse(inputvalue));
                var table = jaggedTable.GetJaggedList(primes);
                Console.Write("{0,0}{1,7}", "|", "|");
                foreach (int number in primes)
                    Console.Write("{0,5}{1,2}", number, "|");

                var arrayPrimes = primes.ToArray();
                Console.WriteLine();
                
                for (int i = 0; i < table.Count(); i++)
                {
                    Console.Write("{0,0}{1,5}{2,2}", "|", arrayPrimes[i], "|");
                    for (int j = 0; j < table.Count(); j++)
                        Console.Write("{0,5}{1,2}", table[i][j], "|");

                    Console.WriteLine();
                }
            }
        }
    }
}
