using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class Coding : IStudyTest
    {
        public void Study()
        {
            using (var sw = new StreamWriter("test.txt", false, Encoding.GetEncoding(28592)))
            {
                sw.WriteLine("Zażółć gęślą jaźń");

                sw.Close();
            }

            using (var sw = new StreamWriter("test3.txt", false, Encoding.GetEncoding(1250)))
            {
                sw.WriteLine("Zażółć gęślą jaźń");

                sw.Close();
            }
        }
    }
}
