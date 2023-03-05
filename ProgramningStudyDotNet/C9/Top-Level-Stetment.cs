using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet.C9
{
    [Execute(DateTime = "03-03-2023 08:36")]
    public class Top_Level_Stetment : IStudyTest
    {
        class TopLevel
        {
            public int Property { get; init; }
        }

        public void Study()
        {
            var topLevel = new TopLevel { Property = 1 };

           // topLevel.Property = 2; //Error CS8852  Init - only property or indexer, can only be assigned in an object initializer,
                                   //or on 'this' or 'base' in an instance constructor or an 'init'

        }
    }
}
