using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class SpecialDecimal : IStudyTest
    {
        public void Study()
        {
            Console.WriteLine(SpecialDecimalRound(SpecialDecimalRound(SpecialDecimalRound(19.085M))));
            Console.WriteLine(SpecialDecimalRound(12.285M));
            Console.WriteLine(SpecialDecimalRound(19.585M));
            Console.WriteLine(SpecialDecimalRound(19.685M));
            Console.WriteLine(SpecialDecimalRound(19.985M));

        }

        public static decimal SpecialDecimalRound(decimal val, int decimalPlaces = 3)
        {
            int places = 1;
            for (int i = 0; i < decimalPlaces; i++)
            {
                places = places * 10;
            }
            return Math.Floor(val * places + 0.4m) / places;
        }

    }
}
