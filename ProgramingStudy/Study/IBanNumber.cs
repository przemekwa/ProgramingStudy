using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    internal class IBanNumber : IStudyTest
    {
        public void Study()
        {
            var s = string.Format("109014894000000114535018252100");

            var doubleNumber = BigInteger.Parse(s);

            Console.WriteLine(98 - (doubleNumber - (doubleNumber/97)*97));
        }
    }
}
