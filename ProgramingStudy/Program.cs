﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingStudy.Study;
using ProgramingStudy.Study.LanguageStudy;

namespace ProgramingStudy
{
    using Study.Kata;

    public class Program
    {
        public static readonly IStudyTest StudyTest = new CodeWars();

        public static void Main(string[] args)
        {
            while (true)
            {
                var name = StudyTest.GetType().Name;

                Console.WriteLine("Start {0}", name);

                var stopWatch = new Stopwatch();

                stopWatch.Start();

                StudyTest.Study();

                stopWatch.Stop();

                Console.WriteLine("Stop {0}, Time {1}", name, stopWatch.Elapsed);

                Console.ReadKey();
            }
        }
    }
}
