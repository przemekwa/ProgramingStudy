using System;
using static System.Math;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.Kata
{
    class CodeWars : IStudyTest
    {
        public void Study()
        {
            Console.WriteLine(palindromeChainLength(89));
        }

        public static int palindromeChainLength(int n)
        {
            var result = 0;

            var longNumber = (long) n;

            while (!isPalindrome(longNumber))
            {
                longNumber += long.Parse(new string(longNumber.ToString().Reverse().ToArray()));
                result++;
                Console.WriteLine(longNumber);
            }
            
            return result;
        }

        public static bool isPalindrome(long number)
        {
            var numberString = number.ToString();

            for (var i = 0; i < numberString.Length / 2; i++)
            {
                if (numberString[i] == numberString[numberString.Length - 1 - i])
                {
                    continue;
                }
                    return false;
            }
            return true;
        }

            

    


        public static String Accum(string s)
        {
            var result = new StringBuilder();

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = 0; j < i+1; j++)
                {
                    result.Append(j == 0 ? char.ToUpper(s[i]) : char.ToLower(s[i]));
                }
                result.Append("-");
            }
            return result.ToString(0, result.Length-1);

            //string.Join("-", s.Select((x, i) => char.ToUpper(x) + new string(char.ToLower(x), i)));

        }


        public static long FindNextSquare(long num)
        {
            return Sqrt(num) % 1 == 0 ? (long)Pow(Sqrt(num) + 1, 2) : -1;
        }

        public static int Solution(int value)
        {
            return Enumerable.Range(0, value).Where(i => i%3 == 0 || i%5 == 0).Sum();

        }

        public static int FindEvenIndex(int[] arr)
        {
            var result = -1;

            for (var index = 0; index < arr.Length; index++)
            {
                if (arr.Skip(index + 1).Sum() == arr.Take(index).Sum())
                {
                    result = index;
                    break;
                }
            }

            return result;
        }


        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }
    }

    
}
