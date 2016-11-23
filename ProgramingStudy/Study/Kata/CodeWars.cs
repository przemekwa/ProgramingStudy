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
            Console.WriteLine(FindNextSquare(625));
        }

        public static long FindNextSquare(long num)
        {
            var muliplly = Math.Sqrt(num);

            if (((double)((int)muliplly)) == muliplly)
            {
                return ((int)muliplly + 1)*((int)muliplly + 1);
            }
            else
            {
                return -1;
            }
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
