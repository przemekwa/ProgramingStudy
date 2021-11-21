
using ProgramingStudyCore;
using System;
using System.Linq;

namespace ProgramingStudyCore
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Program Study");

            var assembly = typeof(IStudyTest).Assembly;

            var type = assembly
                .GetTypes()
                .Select(p =>
                new
                {
                    Attribute = p.CustomAttributes.Where(s => s.AttributeType == typeof(ExecuteAttribute)),
                    Type = p
                })
                .Where(s => s.Attribute.Any())
                .OrderByDescending(s => ((ExecuteAttribute)Attribute.GetCustomAttribute(s.Type, typeof(ExecuteAttribute))).ExecuteDateTime)
                .First();

            var studyTest = (IStudyTest)Activator.CreateInstance(type.Type);

            studyTest.Study();
        }
    }

}