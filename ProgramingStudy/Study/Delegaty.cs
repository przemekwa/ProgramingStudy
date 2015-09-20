using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class Delegaty
    {
        public delegate int hd(int x);

        public Delegaty()
        {
            hd helloDelegate = HelloDelegate;

            helloDelegate += HelloDelegate2;


       
            
        }

        public int HelloDelegate(int x)
        {
            return x;
        }

        public int HelloDelegate2(int x)
        {
            return x;
        }

    }
}
