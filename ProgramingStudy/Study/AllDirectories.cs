using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Execute(DateTime = "04-09-2020 12:55")]
    public class AllDirectories : IStudyTest
    {
        public void Study()
        {

            var path = "D:/temp";

            var di = new DirectoryInfo(path);


            foreach (var item in di.GetFiles("*.*",SearchOption.AllDirectories))
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
