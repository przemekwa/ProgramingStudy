using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNETCoreTests
{
    public class Test
    {
        public async Task<string> RunAsync()
        {
                Console.WriteLine("RunAsync start");

            var d =  Task.Run((() =>
            {
              Thread.Sleep(5000);
                

            }));

            Console.WriteLine("RunAsync stop");

            Console.Write("sdsd");

            await d;


            return "Przemek";
        }


        private async void RunLong()
            {
            }
    }
}
