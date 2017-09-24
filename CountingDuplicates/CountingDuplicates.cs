using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountingDuplicates
{
    [TestClass]
    public class CountingDuplicates
    {
        //Count the number of Duplicates

        //Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits 
        //that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase 
        //and lowercase) and numeric digits.

        //Example

        //"abcde" -> 0 # no characters repeats more than once
        //"aabbcde" -> 2 # 'a' and 'b'
        //"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (bandB)
        //"indivisibility" -> 1 # 'i' occurs six times
        //"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
        //"aA11" -> 2 # 'a' and '1'
        //"ABBA" -> 2 # 'A' and 'B' each occur twice

        [TestMethod]
        public void Input_Empty_should_return_0()
        {
            CountShouldEqual(string.Empty, 0);
        }


        [TestMethod]
        public void Input_a_should_return_0()
        {
            CountShouldEqual("a", 0);
        }

        [TestMethod]
        public void Input_aa_should_return_1()
        {
            CountShouldEqual("aa", 1);
        }

        [TestMethod]
        public void Input_aA_should_return_1()
        {
            CountShouldEqual("aA", 1);
        }

        [TestMethod]
        public void Input_ABBA_should_return_2()
        {
            CountShouldEqual("ABBA", 2);
        }

        [TestMethod]
        public void Input_aabBcde_should_return_2()
        {
            CountShouldEqual("aabBcde", 2);
        }

        private static void CountShouldEqual(string input, int expected)
        {
            CountingDuplicate counting = new CountingDuplicate();
            var result = counting.DuplicateCharCount(input);

            Assert.AreEqual(expected, result);
        }
    }

    public class CountingDuplicate
    {
        public int DuplicateCharCount(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            return input.ToUpper().GroupBy(x=>x).Count(x => x.Count() > 1);
        }
    }
}
