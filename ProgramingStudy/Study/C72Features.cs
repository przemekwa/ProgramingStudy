using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class A1 : B1
    {
        public A1()
        {
            base.Test();
        }
    }


    public class B1
    {
         internal void Test()
        {

        }
    }

    public class C72Features
    {
        public C72Features()
        {
            var a  = new A1();

            a.Test();
        }
    }
}
