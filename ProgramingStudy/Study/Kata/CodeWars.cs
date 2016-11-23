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
            Console.WriteLine(Solution(10));
        }

        public static int Solution(int value)
        {
            var list = Enumerable.Range(0, value);

            var resut = 0;

            foreach (var i in list)
            {
                if (i%3 == 0)
                {
                    resut += i;
                    continue;
                }

                if (i%5 == 0)
                {
                    resut += i;
                }
            }

            return resut;

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
