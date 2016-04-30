using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class AwaitAsych : IStudyTest
    {
        public void Study()
        {
            int count = 5;

            while (count == 0 )
            {
                count--;
                Console.WriteLine("Number : {0}", count);
            }



        }

        public async void DoAsynch()
        {
            Console.WriteLine("Start DoAnych");

           await Method();

            Console.WriteLine("Stop DoAnych");
        }


        public Task Method()
        {
            Console.WriteLine("Start metody");

            var t = new Task(() =>
            {
                Console.WriteLine("Idzie zadanie");
                Thread.Sleep(2000);
            });


            t.Start();

            Console.WriteLine("Stop metody");

            return t;
        
        }
    }
}
