using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class QuickSort :IStudyTest
    {
        private int[] tabToSort = { 2, 1, 10, 4, 7, 6, 5, 9, 8, 330, 3, 1, 2 };

        public void Study()
        {
            Qs(0, tabToSort.Length - 1);
        }

        public void Qs(int indexPoczatku, int indexKonca)
        {
            var pozycja = Podziel(indexPoczatku, indexKonca);

            if (pozycja - 1 >= indexPoczatku)
            {
                Qs(indexPoczatku, pozycja - 1);
            }

            if (pozycja + 1 <= indexKonca)
            {
                Qs(pozycja + 1, indexKonca);
            }
        }

        public int Podziel(int indexPoczatku, int indexKonca)
        {
            var pivotIndex = this.WyznaczPivot(indexPoczatku, indexKonca);

            var wartoscPivota = tabToSort[pivotIndex];

            Zamien(pivotIndex, indexKonca);

            var pozycja = indexPoczatku;

            for (int i = pozycja; i <= indexKonca; i++)
            {
                if (tabToSort[i] < wartoscPivota)
                {
                    Zamien(i, pozycja);
                    pozycja++;
                }
            }

            Zamien(pozycja, indexKonca);
            return pozycja;
        }

        public void Zamien(int indexPoczatku, int indexKonca)
        {
            var temp = tabToSort[indexPoczatku];
            tabToSort[indexPoczatku] = tabToSort[indexKonca];
            tabToSort[indexKonca] = temp;
        }


        public int WyznaczPivot(int indexPoczatku, int indexKonca) => indexPoczatku;
    }
}
