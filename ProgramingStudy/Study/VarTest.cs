using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study
{
    public class VarTest : IStudyTest
    {
        public void Study()
        {

            var tekst = "123";
            var liczba = 12M;
            var slownik = new Dictionary<string, string>();


            


            var intList = Enumerable.Range(0, 100);

            var listaTypowAnonimowych = intList
                .Where(x => (x % 2 == 0) && (x != 0))
                .Select(x => new
                {
                    Liczba = x,
                    CzyParzysta = true
                });

            foreach (var typAnonimowy in listaTypowAnonimowych)
            {
                WriteLine($"Wartość właściwości Liczba: {typAnonimowy.Liczba}");
                WriteLine($"Wartość właściwości CzyParzysta: {typAnonimowy.CzyParzysta}");
            }
        }
    }
}
