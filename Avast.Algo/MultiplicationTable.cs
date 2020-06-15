using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avast.Algo
{
    public class JaggedTable
    {
        public int[][] GetJaggedList(IEnumerable<int> primeNumbers)
        {
            int count = primeNumbers.Count();
            var jaggedList = new int[count][];
            int index_A = 0;
            int index_B = 0;

            foreach (int prime in primeNumbers)
            {
                jaggedList[index_A] = new int[count];
                foreach (int number in primeNumbers)
                {
                    jaggedList[index_A][index_B] = prime * number;
                    index_B++;
                }
                index_A++;
                index_B = 0;
            }

            return jaggedList;
        }
    }
}
