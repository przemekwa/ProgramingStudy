using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study
{
    public class C7FeaturesTests : IStudyTest
    {
        public void Study()
        {
            WriteLine($"Pattern Matching: {this.PatterMatching()} ");
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
