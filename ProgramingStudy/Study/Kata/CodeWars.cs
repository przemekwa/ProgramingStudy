﻿using System;



using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgramingStudy.Study.Kata
{
    using System.Collections;
    using System.Diagnostics;

    class CodeWars : IStudyTest
    {
        public void Study()
        {
            foreach (var a in TowerBuilder(6))
            {
                Console.WriteLine(a);
            }
          
        }

        public static string[] TowerBuilder(int nFloors)
        {
            var result = new List<string>();
            var currentFloor = 1;
            var space = nFloors;
            
            for (var i = 0; i < nFloors*2; i+=2)
            {
                result.Add(new string('*', currentFloor).PadLeft(space).PadRight(2*space - currentFloor));
                currentFloor += 2;
                space++;
            }

            return result.ToArray();
        }


        public static string OkkOokOo(string okkOookk)
        {
            Console.WriteLine();

            var f =
                okkOookk.Replace(", ", "")
                    .Replace("o", "0")
                    .Replace("O", "0")
                    .Replace("K", "1")
                    .Replace("k", "1")
                    .Split(new[] {"?", "!"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x =>
                    {
                        var int32 = Convert.ToInt64(x, 2);

                        var charr = Convert.ToChar(int32);

                        return charr;
                    }).ToList();
            

            return string.Join("", f);


        }







        public static bool ValidBraces(String braces)
        {
            if (braces.Length % 2 != 0)
            {
                return false;
            }

            var dict = new Dictionary<char, char>
            {
                {'(', ')'},
                {')', '('},
                {']', '['},
                {'[', ']'},
                {'}', '{'},
                {'{', '}'}
            };


            var list = new List<char>();

            foreach (var b in braces)
            {
                switch (b)
                {
                    case '(':
                    case '{':
                    case '[':
                        list.Add(b);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        var lastOrDefault = list.LastOrDefault();

                        if (lastOrDefault != dict[b])
                        {
                            return false;
                        }

                        list.Remove(lastOrDefault);
                        break;
                }
            }

            return list.Count == 0;
        }

        
      
        private static List<int[]> permutationList;

        public static long NextBiggerNumber(long n)
        {
            permutationList = new List<int[]>();

            var s = n.ToString().Select(x => int.Parse(x.ToString())).ToArray();
            
            if (s.Count() < 2)
            {
                return -1;
            }

            for (var i = s.Count() - 1; i >= 0; i -= 1)
            {
                if (i - 1 < 0)
                {
                    break;
                }

                if (s[i] > s[i - 1])
                {
                   var nextNumber =  GetNextNumber(s.Skip(i-1));
                    
                    for (var j = 0; j < nextNumber.Length; j++)
                    {
                        s[(i - 1 + j)] = nextNumber[j];
                    }
                    break;
                }
            }

            var result = long.Parse(string.Join("", s.Select(s3 => s3.ToString())));

            return result == n ? -1 : result;
        }


        private static int[] GetNextNumber(IEnumerable<int> numberDigtList)
        {
            Permute(numberDigtList.ToArray(), 0, numberDigtList.Count()-1);

            var intPermutationsList = permutationList.Select(d1 => int.Parse(string.Join("", d1))).ToArray();

            Array.Sort(intPermutationsList);

            var number = int.Parse(string.Join("", numberDigtList));

            var result = intPermutationsList.First(d2 => d2 > number);

            return result.ToString().Select(x => int.Parse(x.ToString())).ToArray();
        }

        static void Permute(int[] arry, int i, int n)
        {
            if (i == n)
            {
                permutationList.Add(arry.ToArray());
            }
            else
            {
                int j;
                for (j = i; j <= n; j++)
                {
                    Swap(ref arry[i], ref arry[j]);
                    Permute(arry, i + 1, n);
                    Swap(ref arry[i], ref arry[j]); //backtrack
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        public static string GetReadableTime(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);

            return $"{((int) ts.TotalHours).ToString("00")}:{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";
        }
        public static string print(int n)
        {
            var result = new StringBuilder();

            for (int i = 1; i < n+1; i++)
            {
                if (i%2 == 0)
                {
                    continue;
                }
                result.Append(new String('*', i));
                result.Append("\n");
            }

            return result.ToString();
        }
        public static string ReverseWords(string str)
        {
            
            return string.Join(" ", str.Split(' ').Reverse());
        }
        //        A child plays with a ball on the nth floor of a big building the height of which is known

        //(float parameter "h" in meters, h > 0) .

        //He lets out the ball.The ball rebounds for example to two-thirds

        //(float parameter "bounce", 0 < bounce< 1)

        //of its height.

        //His mother looks out of a window that is 1.5 meters from the ground

        //(float parameters window<h).

        //How many times will the mother see the ball either falling or bouncing in front of the window

        //(return a positive integer unless conditions are not fulfilled in which case return -1) ?

        //Note

        //You will admit that the ball can only be seen if the height of the rebouncing ball is stricty greater than the window parameter.

        //Example:

        //h = 3, bounce = 0.66, window = 1.5, result is 3

        //h = 3, bounce = 1, window = 1.5, result is -1
        public static int BouncingBall(double h, double bounce, double window)
        {
            var result = 0;

            var currentH = h;

            while (currentH > window)
            {
                if (currentH >= window)
                {
                    result += 1;
                }

                currentH = currentH*bounce;

                if (currentH >= window)
                {
                    result += 1;
                }
            }

            return result == 0 ?-1:result;
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
