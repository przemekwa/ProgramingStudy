using System;



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
            var months = nbMonths(2000, 8000, 1000, 1.5);

            Console.WriteLine($"{months[0]}, {months[1]}");
        }

        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingperMonth, double percentLossByMonth)
        {
            var month = 0;
            double startPriceOldDouble = startPriceOld;
            double startPriceNewDouble = startPriceNew;
            double wallet = 0;

            while (startPriceNewDouble >= (wallet + startPriceOldDouble))
            {
                if (++month % 2 == 0)
                {
                    percentLossByMonth += 0.5D;
                }

                startPriceOldDouble -= (startPriceOldDouble * percentLossByMonth) / 100;
                startPriceNewDouble -= (startPriceNewDouble * percentLossByMonth) / 100;
                wallet += (double)savingperMonth;
            }

            return new[] { month, (int)System.Math.Round(((wallet + startPriceOldDouble) - startPriceNewDouble)) };
        }


        public static int palindromeChainLength(int n)
        {
            var result = 0;

            var longNumber = (long) n;

            while (longNumber != Reverse(longNumber))
            {
                result++;
                longNumber+= Reverse(longNumber);
                Console.WriteLine(longNumber);

            }
            
            return result;
        }

        public static long Reverse(long number) => long.Parse(new string(number.ToString().Reverse().ToArray()));







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
            return System.Math.Sqrt(num) % 1 == 0 ? (long)System.Math.Pow(System.Math.Sqrt(num) + 1, 2) : -1;
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
