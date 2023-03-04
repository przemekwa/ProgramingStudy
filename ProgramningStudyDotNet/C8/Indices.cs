using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet.C8
{
    public interface INew
    {
        void New();
        int Add(int x, int y) => x + y + Handicap;
        static int Handicap = 3;
    }


    public class NewClass : INew
    {
        public void New()
        {
            throw new NotImplementedException();
        }

    }







    [Execute(DateTime = "01-03-2023 08:36")]
    public class Indices : IStudyTest
    {
        
        public void Study()
        {


            NewClass newClass = new NewClass();

            INew.Handicap = 3;

            var test = ((INew)newClass);


            


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

        public void UsingTests()
        {
            if (true)
            {
                using var fr = new StreamReader(@"C:\");
            }
        }


        public struct Test
        {
            public int Field { get; set; }
            //public readonly void Change() => Field = 3;

        }

        public void Struct()
        {

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
