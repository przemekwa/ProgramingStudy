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
            Console.WriteLine(FindEvenIndex(new int[] { 20, 10, 30, 10, 10, 15, 35 }));
        }

        public static int FindEvenIndex(int[] arr)
        {
            var result = -1;


            for (var index = 0; index < arr.Length; index++)
            {
                var sumLeft = arr.Skip(index+1).Sum();
                var sumRight = arr.Take(index).Sum();

                if (sumLeft == sumRight)
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
