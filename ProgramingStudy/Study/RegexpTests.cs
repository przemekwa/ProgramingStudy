using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class RegexpTests : IStudyTest
    {
        public void Study()
        {
            var result = Test8(null);
            var result2 = Test8(new o {IsProcessed = true });
            var result4 = Test8(new o {IsProcessed = false });
            
           
        }

        public bool Test8(o obj)
        {

             return obj != null && obj.IsProcessed;

             if (obj == null)
            {
               return false;
            }

            if (obj.IsProcessed== false)
            {
               return false;
            }

            return true;
        }


        public class o
        {
            public bool IsProcessed { get; set; }
        }


        
       
    }
}
