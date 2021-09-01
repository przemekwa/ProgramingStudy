using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Execute(DateTime = "22-01-2021 18:46")]
    public class andorStydy : IStudyTest
    {
        public void Study()
        {
            var test1 = false;
            var test2 = false;
            var test3 = true;
            var test4 = false;


            if (test1 || test2 || test3 && test4)
            {
                Console.WriteLine("mam racje");
            }
            else
            {
                Console.WriteLine("a może nie");
            }

        }
    }
}

