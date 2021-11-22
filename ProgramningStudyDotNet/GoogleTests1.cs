using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    [ExecuteAttribute(DateTime = "22-11-2021 00:00")]
    internal class GoogleTests1 : IStudyTest
    {
        public void Study()
        {
            Console.WriteLine("Hello Google");
        }
    }

