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
                Console.WriteLine(ValidBraces("{({})}"));
            }

        public class N
        {
            public char Open { get; set; }
            public char Close { get; set; }
            public bool HaveBody { get; set; }
            public int Index { get; set; }
        }

        public static bool ValidBraces(String braces)
        {
            var stos = new List<N>();

            for (int index = 0; index < braces.Length; index++)
            {
                var c = braces[index];

                switch (c)
                {
                    case '{':
                    case '(':
                        var n = new N
                        {
                            Open = c,
                            Close = '\0',
                            Index = index
                        };

                        var lastOpenAll = stos.LastOrDefault(t => t.Open != '\0' && t.Close != '\0');

                        if (lastOpenAll != null)
                        {
                            lastOpenAll.HaveBody = true;
                        }

                        stos.Add(n);
                        break;

                    case '}':
                        var lastOpen = stos.LastOrDefault(t => t.Open == '{' && t.Close == '\0');

                        var lastOpenAll1 = stos.LastOrDefault(t => t.Open != '\0' && t.Close == '\0');

                        if (lastOpenAll1 != null)
                        {
                            return false;
                        }


                        if (lastOpen == null)
                        {
                            return false;
                        }

                        if (lastOpen.HaveBody)
                        {
                            return false;
                        }

                        lastOpen.HaveBody = false;
                        lastOpen.Close = c;

                        break;
                    case ')':

                        var lastOpen2 = stos.LastOrDefault(t => t.Open == '(' && t.Close=='\0');

                        var lastOpenAll2 = stos.LastOrDefault(t => t.Open != '\0' && t.Close == '\0');

                        if (lastOpenAll2 != null)
                        {
                            return false;
                        }

                        if (lastOpen2 == null)
                        {
                            return false;
                        }

                        if (lastOpen2.HaveBody)
                        {
                            return false;
                        }

                        lastOpen2.HaveBody = false;
                        lastOpen2.Close = c;
                       
                        break;
                    default:
                        break;
                }
            }

            return stos.Any(t => t.Open != '\0' && t.Close != '\0');
        }

        public class Test
        {
            public int Count { get; set; }
            public bool Open { get; set; }
            public int Group { get; set; }
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
