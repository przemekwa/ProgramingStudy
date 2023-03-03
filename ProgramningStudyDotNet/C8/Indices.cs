using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet.C8
{
    [Execute(DateTime = "01-03-2023 08:36")]
    public class Indices : IStudyTest
    {
        
        public void Study()
        {
            char[] sample = new char[] { 'A', 'B', 'C', 'D','E' };

            var lastElement = sample[^1]; // E ostatni element
            var secondLastElement = sample[^2]; // D przed ostatni element

            var firstTwo = sample[..3]; // A B C z całej tablicy weź 3 elementy. Idź tak długo jak będziesz mieć 3
            var lastThr = sample[2..];  // C D E pomiń 2 pierwsze elemeny. Pomijaj 2 elemeny a potem daj resztę
            var middleOne = sample[2..3]; // C pomiń 2 pierwsze elemeny ale idź tak długo jak będziesz mieć 3 elemeny (razem z tymi pominiętymi) 
            var lastTwo = sample[^2..]; // D E daj 2 ostatnie (^) elemeny


            Index lastElementType = ^1;
            Range middleOneType = 2..3;



        }


        public void NullCoalescingAssigment()
        {
            List<int> test = null;

            //zamiast

            if (test == null)
            {
                test = new List<int>();
            }

            //można użyć tego

            test ??= new List<int>();

        }



    }
}
