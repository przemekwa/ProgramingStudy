using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingStudy.Study;

namespace ProgramingStudy
{
    class Program
    {
        public static readonly IStudyTest StudyTest = new CultureInfoTest();

        static void Main(string[] args)
        {
            var testName = StudyTest.GetType().Name;

          //  Console.WriteLine("Start {0}", testName);

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            StudyTest.Study();

            stopWatch.Stop();

        //    Console.WriteLine("Stop {0}, Time {1}", testName, stopWatch.Elapsed);

            Console.ReadKey();
        }
    }
}
