using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy
{
    class EnumTest : IStudyTest
    {
        enum days : byte
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }
       
        public void Study()
        {
            Console.WriteLine(days.Friday | days.Monday);

            Console.WriteLine((byte)days.Monday);
        }
    }
}
