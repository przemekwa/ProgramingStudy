using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public struct RefOutInObj
    {
        public int Index { get; set; }
    }

    public class RefOutIn : IStudyTest
    {
        public void Study()
        {
            RefOutInObj obj = default;

            //int s;

         


            //Console.WriteLine(obj.Index);
            //Console.WriteLine(s);
        }


        public void A( RefOutInObj obj,  int s)
        {

            s = 100;
            obj = new RefOutInObj
            {
                Index = 10
            };
            
        }
    }
}
