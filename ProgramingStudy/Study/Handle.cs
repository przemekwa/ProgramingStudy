using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class Handle
    {
       

        public event Action Pierwszy;
        
        public Handle()
        {
            
        }

        public void Nic()
        {
            this.Pierwszy();
        }

    }

    class Test2 :IStudyTest
    {
        public Test2()
        {
        }

        void d_Pierwszy()
        {
            Console.WriteLine("Cześć");
        }

        public void Study()
        {
            var d = new Handle();
            d.Pierwszy += d_Pierwszy;


            d.Nic();

        }
    }
}
