using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProgramingStudy.Study
{
    class CultureInfoTest : IStudyTest
    {

        public void Study()
        {
            var englishFormat = new CultureInfo("en-GB");

            decimal d = 12.632M;

            Console.WriteLine("Moje ustawienia regionalne: {0}", CultureInfo.CurrentCulture);

            Console.WriteLine("Mój separator: {0}", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            Console.WriteLine("Format liczby na dla moich ustawień: {0}", d.ToString(CultureInfo.CurrentCulture));

            var text = d.ToString(englishFormat);

            Console.WriteLine("Liczba, którą odebrałem z bazy lub pliku : {0}", text);

            double convertToDouble = Convert.ToDouble(text, CultureInfo.InvariantCulture);

            Console.WriteLine("Liczba po konwersjii: {0}", convertToDouble);

        }


        void CountCultureInfo()
        {
            

        }
    }
}
