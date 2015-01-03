using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy
{
    class Portfel
    {
        decimal gotowka;

        public Portfel(decimal gotowka)
        {
            this.gotowka = gotowka;
        }

        public static explicit operator Gotowka(Portfel bank)
        {
            return new Gotowka
            {
                Wartosc = bank.gotowka
            };
        }
    }


    class Gotowka
    {
        public decimal Wartosc { get; set; }
    }


    class ExplicitImplicitTest
    {
        public ExplicitImplicitTest()
        {
            var portfel = new Portfel(12000.56M);

            var gotowka = portfel;

        }
    }
}
