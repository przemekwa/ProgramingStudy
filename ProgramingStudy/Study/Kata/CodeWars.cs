using System;



using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.Kata
{
    using System.Collections;

    class Test6 : IEqualityComparer<char>
    {
        public bool Equals(char x, char y)
        {
            return x == y;
        }

        public int GetHashCode(char obj)
        {
            return obj.GetHashCode();
        }
    }



    class CodeWars : IStudyTest
    {
        public void Study()
        {
            Console.WriteLine(DuplicateCount("Indivisibility"));
        }


        //"abcde" -> 0 # no characters repeats more than once
        //"aabbcde" -> 2 # 'a' and 'b'
        //"aabbcdeB" -> 2 # 'a' and 'b'
        //"indivisibility" -> 1 # 'i'
        //"Indivisibilities" -> 2 # 'i' and 's'
        //"aa11" -> 2 # 'a' and '1'
        public static int DuplicateCount(string str)
        {
            var duplicateCount = str.ToLower().GroupBy(x => x).Count(g => g.Count() > 1);


            return 0;
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
