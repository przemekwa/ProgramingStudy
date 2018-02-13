using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{

    public class Test8
    {
        public int Age { get; set; }
    }

    public class C72Features: IStudyTest
    {
        public void Study()
        {
            var d = new Test8
            {
                Age = 12
            };


            TestMethod(d);


        }

        public void TestMethod(in Test8 test8)
        {
            test8.Age = 12;

        }

    }

    
}
