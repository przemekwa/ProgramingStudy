using System;
using System.Diagnostics;
using System.Linq;
using ProgramingStudy.Study;

namespace ProgramingStudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var assembly = typeof(IStudyTest).Assembly;

            var type = assembly
                .GetTypes()
                .Select(p => 
                new
                {
                    Attribute = p.CustomAttributes.Where(s => s.AttributeType == typeof(ExecuteAttribute)),
                    Type = p
                })
                .Where(s=>s.Attribute.Any())
                .OrderByDescending(s=> ((ExecuteAttribute)Attribute.GetCustomAttribute(s.Type, typeof(ExecuteAttribute))).ExecuteDateTime)
                .First();
                
            var studyTest = (IStudyTest)Activator.CreateInstance(type.Type);
            
            while (true)
            {
                var name = studyTest.GetType().Name;

                Console.WriteLine("Start {0}", name);

                var stopWatch = new Stopwatch();

                stopWatch.Start();

                studyTest.Study();

                stopWatch.Stop();

                Console.WriteLine("Stop {0}, Time {1}", name, stopWatch.Elapsed);

                Console.ReadKey();
            }
        }
    }
}
