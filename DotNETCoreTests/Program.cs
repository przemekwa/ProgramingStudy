using System;
using System.Threading.Tasks;

namespace DotNETCoreTests
{
    class Program
    {
        static  void  Main(string[] args)
        {

           
            MainAsync(args).GetAwaiter().GetResult();



          
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
             Console.WriteLine("Start");
            var test = new Test();

           var r = await test.RunAsync();

            Console.Write(r);


              Console.WriteLine("STOP");
            
        }

    }
}
