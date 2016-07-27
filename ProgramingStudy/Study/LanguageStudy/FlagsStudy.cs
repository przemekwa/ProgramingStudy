using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.LanguageStudy
{
    public class FlagsStudy : IStudyTest
    {
        [Flags]
        enum Flaga
        {
            a = 1 << 0,
            b = 1 << 1,
            c = 1 << 2,
            d = 1 << 3
        }

        public void Study()
        {
            this.Foo(Flaga.b | Flaga.a);

            Console.WriteLine(Convert.ToString(16, 2));

            Console.WriteLine("1<<0 -- {0}", Convert.ToString(1 << 0, 2));
            Console.WriteLine("1<<1 -- {0}", Convert.ToString(1 << 1, 2));
            Console.WriteLine("1<<2 -- {0}", Convert.ToString(1 << 2, 2));
            Console.WriteLine("1<<3 -- {0}", Convert.ToString(1 << 3, 2));
            Console.WriteLine("1<<4 -- {0}", Convert.ToString(1 << 4, 2));

        }

        private void Foo(Flaga flaga)
        {

            if (((flaga & Flaga.a) == Flaga.a))
            {
                Console.WriteLine("A");

            }

            if (((flaga & Flaga.d) == Flaga.d))
            {
                Console.WriteLine("D");
            }
        }

        private void Bar(Flaga flaga)
        {
            if (flaga.HasFlag(Flaga.a))
            {
                Console.WriteLine("A");
            }

            if (flaga.HasFlag(Flaga.b))
            {
                Console.WriteLine("B");
            }

        }
    }
}
