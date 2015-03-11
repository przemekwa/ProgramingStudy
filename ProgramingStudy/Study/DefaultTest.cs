using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class DefaultTest : IStudyTest
    {
        class ja
        {
            public string Test { get; set; }
        }
        public void Study()
        {
            int a = 1;

            var t = new ja();


         

            if (default(int) == 0)
            {
                Console.WriteLine(default(int));
            }

       

            

        }

        private void Show(object a)
        {
    
        }
    }
}
