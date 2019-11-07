using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Execute(DateTime = "07-11-2019 10:00")]
    class DurationStudy : IStudyTest
    {
        public void Study()
        {
            Console.WriteLine(ConvertMinutesToStringValue(62)); 
            Console.WriteLine(ConvertMinutesToStringValue(480)); 
            Console.WriteLine(ConvertMinutesToStringValue(234)); 
        }


        public string ConvertMinutesToStringValue(long minutes, int? defaultDuration = 8, string zeroMinutes = "0d")
        {

           var result = string.Empty;
            if (minutes == 0)
            {
                return zeroMinutes;
                
            }

            bool isNegative = false;
            if (minutes < 0)
            {
                minutes = -(minutes);
                isNegative = true;
            }

            long divValue = minutes / ((defaultDuration.Value * 60));

            if (divValue > 0)
            {
                result += divValue + "d" + " ";
                minutes = minutes % ((defaultDuration.Value * 60));
            }

            if (minutes > 0)
            {
                divValue = minutes / 60;
                if (divValue > 0)
                {
                    result += divValue + "h" + " ";
                    minutes = minutes % 60;
                }

                if (minutes > 0)
                {
                    result += minutes + "m";
                }
            }

            if (isNegative)
            {
                result = "-" + result;
            }

            return result;
        }
    }
}
