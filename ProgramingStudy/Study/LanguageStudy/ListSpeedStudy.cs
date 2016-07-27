using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.LanguageStudy
{
    class ListSpeedStudy : IStudyTest
    {
        public void Study()
        {
            var test = Enumerable.Repeat("ssss", 50000);

            Stopwatch l = new Stopwatch();
            l.Start();

            foreach (var VARIABLE in test)
            {
                Console.WriteLine(VARIABLE);
            }


            l.Stop();



            var t1 = l.Elapsed;
            var test2 = test.GetEnumerator();

            l.Reset();
            l.Start();
            while (test2.MoveNext())
            {
                Console.WriteLine(test2.Current);
            }
            l.Stop();

            var t2 = l.Elapsed;


            Console.WriteLine("Wolno {0}", t1);
            Console.WriteLine("Szybko {0}", t2);
            Console.ReadKey();
        }
    }
}
