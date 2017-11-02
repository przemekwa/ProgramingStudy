using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study
{

    interface I1
    {
        void M1();

        //void M2()
        //{
        //    WriteLine("I1.M2");
        //}
    }

    class C1 : I1
    {
        public void M1()
        {
            WriteLine("C1.M1");
        }
    }

    class C2 : I1
    {
        public void M1()
        {
            WriteLine("C2.M1");
        }

        public void M2()
        {
            WriteLine("C2.M2");
        }
    }


    public class C7FeaturesTests : IStudyTest
    {
        public void Study()
        {
            WriteLine($"Pattern Matching: {this.PatterMatching()} ");

            WriteLine($"New Tuple:");

            WriteLine($"To string() {this.GetTuple()}");

            var tuple = this.GetTuple();

            WriteLine($"Tuple Item1 {tuple.Item1}");
            WriteLine($"Tuple Item1 {tuple.Item2}");

            WriteLine($"Tuple {nameof(tuple.Age)} {tuple.Age}");
            WriteLine($"Tuple {nameof(tuple.Count)} {tuple.Count}");


            (int Wiek, int Ilość) deTuple = this.GetTuple();

            (int Wiek, int _) deTuple2 = this.GetTuple();
        }

        public void TestInterface()
        {

        }

        public (int Age, int Count) GetTuple()
        {
            var p = (age1: 12, agr2: 12);

            return p;
        }

        public int PatterMatching()
        {
            object[] objects = { "34", 12, 1, null };

            foreach (var obj in objects)
            {
                switch (obj)
                {
                    case string s when int.TryParse(s, out int i):
                        WriteLine($"String jako int: {s} ");
                        break;
                    case int s:
                        WriteLine($"Int:{s} ");
                        break;
                    default:
                        WriteLine("Null");
                        break;
                }
            }


            return -1;
        }

    }
}
