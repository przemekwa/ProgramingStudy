using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class test
    {
        private string _napis = "Przemek";
        private int _liczbna = 12;
        private double _liczba1 = 13.1;

        public string napis
        {
            
            get { return _napis; }
            set { _napis = value; }
        }

        public int liczbna
        {
            get { return _liczbna; }
            set { _liczbna = value; }
        }

        public double liczba1
        {
            get { return _liczba1; }
            set { _liczba1 = value; }
        }
    }

    class Things : IStudyTest
    {
        
        public int Odejmij(int arg1, int arg2, 
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string methodName = "")
        {
            Console.WriteLine("Ścieżka do pliku {0}",filePath);
            Console.WriteLine("Number wiersza {0}", lineNumber);
            Console.WriteLine("Nazwa metody {0}", methodName);
            return arg1 - arg2;
        }




        public class Figury { };

        public class Czworokaty : Figury {}

        public class Kwadrat : Czworokaty { };
        

        public interface IEnumerable<out T>
        {

        }

        public void Study()
        {
         
        }
    }
}
