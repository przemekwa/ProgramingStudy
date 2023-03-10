using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet
{
    [Execute(DateTime = "15-03-2023 08:36")]
    public class UnicodeShow : IStudyTest
    {
        public void Study()
        {
            var word = Console.ReadLine();

            foreach (var item in word)
            {
               var unicode =  Encoding.Convert(Encoding.UTF8, Encoding.Unicode, Encoding.UTF8.GetBytes(new[] { item }));

                Console.WriteLine(string.Format("Unicode: U+{0:X4}", BitConverter.ToInt16(unicode)));

                var uft8 = Encoding.UTF8.GetBytes(new[] { item });

                Console.WriteLine(string.Format("Unicode: U+{0:X4}", BitConverter.ToInt32(uft8)));


            }
        }
    }
}
