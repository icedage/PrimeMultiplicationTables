using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avast.Algo.Tests
{
    [TestFixture]
    public class JaggedTableTests
    {
        [TestCase(new int [] { })]
        [TestCase(new[] { 1})]
        [TestCase(new[] { 2, 3 })]
        [TestCase(new[] { 2, 3, 5 })]
        [TestCase(new[] { 13, 17, 19, 23, 29 })]
        public void JaggedTable_Should_Return_X_Rows_BY_Z_Columns_For_N_Numbers(int[] provided)
        {
            //ARRANGE
            var numbers = provided;

            //ACT
            JaggedTable table = new JaggedTable();
            var returned = table.GetJaggedList(numbers);
            
            //ASSERT ROWS
            Assert.AreEqual(provided.Count(), returned.Count());

            //ASSERT COLUMNS
            if (provided.Length == 0)
            {
                var columns = returned.Length;
                Assert.AreEqual(columns, provided.Count());
            }
            else 
            {
                var columns = returned[0]; ;
                Assert.AreEqual(columns.Length, provided.Count());
            }
        }

        [TestCase]
        public void JaggedTable_Should_Return_Correct_Multiplication_Set()
        {
            //ARRANGE
            JaggedTable table = new JaggedTable();
            List<int> provided = new List<int>() { 13, 17 };
            
            //ACT
            var returned = table.GetJaggedList(provided);
            var expected = new int[provided.Count][];
                
            expected[0] = (new int[] { 169, 221 });
            expected[1] = (new int[] { 221, 289 });
       
            //ASSERT
            CollectionAssert.AreEqual(expected[0], returned[0]);
            CollectionAssert.AreEqual(expected[1], returned[1]);
        }

        [TestCase(new[] { 79, 83, 89, 97 })]
        [TestCase(new[] { 47, 53, 59, 61, 67 })]
        [TestCase(new[] { 13, 17, 19, 23, 29, 31, 37, 41, 43 })]
        public void JaggedTable_Should_Match_Last_Element_Of_First_Row_With_First_Element_Of_The_Next(int[] provided)
        {
            JaggedTable table = new JaggedTable();
            var returned = table.GetJaggedList(provided);
            Assert.AreEqual(returned[0][returned.Count()-1], returned[returned.Count() - 1][0]);
        }
    }
}
