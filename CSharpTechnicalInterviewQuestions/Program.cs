using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTechnicalInterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = { 1, 2, 3, 4, 5, 6 };
            int[] second = { 2147483647, 2, 3, 4, 5, 6};
            string third = "This should be reversed";
            string fourth = "There were a bunch of 'e's in here";
            int[] fifth = { 1, 2, 3, 4, 5, 6, 15 };

            Console.WriteLine("1. " + SumOfOddNums(first));
            Console.WriteLine("2. " + SumOfNums(second));
            Console.WriteLine("3. " + ReverseString(third));
            Console.WriteLine("4. " + RemoveDuplicateChars(fourth));
            Console.WriteLine("4(without using linq). " + RemoveDuplicateCharsNoLinq(fourth));
            FizzBuzz(fifth);

            Console.Read();
        }

        static int SumOfOddNums (int[] nums)
        {
            int total = 0;

            foreach (var num in nums)
            {
                if (num % 2 != 0)
                    total += num;
            }
            return total;
        }

        static int SumOfNums (int[] nums)
        {
            int total = 0;

            foreach (var num in nums)
            {
                try
                {
                    checked
                    {
                        total += num;
                    }
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine("Arithmetic caused an overflow with exception: " + e.ToString());
                }
            }
            return total;
        }

        static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        // Fairly simple LINQ approach that turns the string into a char array
        // and then returns non-duplicate members of the array using Distinct()
        // and then turns it back into an array which is returned as a string.
        static string RemoveDuplicateChars(string s)
        {
            return new string(s.ToCharArray().Distinct().ToArray());
        }


        // May as well try without using LINQ
        static string RemoveDuplicateCharsNoLinq(string s)
        {
            char[] chars = s.ToCharArray();
            List<char> nonRepeating = new List<char>();
            string output = string.Empty;

            foreach (var ch in chars)
            {   
                if (!nonRepeating.Contains(ch))
                {
                    nonRepeating.Add(ch);
                    output += ch;
                }
            }
            return output;
        }

        static void FizzBuzz(int[] input)
        {
            foreach (var num in input)
            {
                string result = string.Empty;

                if (num % 3 == 0)
                    result += "Fizz ";
                if (num % 5 == 0)
                    result += "Buzz";

                if (string.IsNullOrEmpty(result))
                    Console.WriteLine(num.ToString());
                else
                    Console.WriteLine(result);
            }
        }
    }
}
