using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study
{
    public class C71Features : IStudyTest
    {
        public void Study()
        {
            DefaultFeature<int>(5);
            TupleWithName();
        }

        private void TupleWithName()
        {
             // C# 7.1

            int Number = 1983;
            var Name = "Przemek";

            var tuple = (Name, Number);

            Console.WriteLine(tuple.Name); // Przemek
            Console.WriteLine(tuple.Number); // 1983


            var myobj = new
            {
                tuple.Name,
                tuple.Number
            };

            Console.WriteLine(myobj.Name; 
            Console.WriteLine(myobj.Number); 

        }

        private void DefaultFeature<T>(T unknownType)
        {
            T defaultUnknownValue = default;
        }
    }
}
