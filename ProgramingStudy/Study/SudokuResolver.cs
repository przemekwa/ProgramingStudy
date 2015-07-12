using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class SudokuResolver : IStudyTest
    {
        private int[,] sudokuMap = 
        {
            {0,0,0,0,0,8,1,4,0},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9},
            {1,2,3,4,5,6,7,8,9}
        };


        public void Study()
        {
            Console.WriteLine("Witaj w algorytmie sudoku 2015");

            this.NarysujPlansze(this.sudokuMap);
        }

        public int[,] DajObszar(int numerObszaru)
        {

            return new int[2,3];
        }
        
        private void NarysujPlansze(int[,] tabelaSuoku)
        {
            const string line = "+-----------------------------+";

            Console.WriteLine("Aktualna plansza");

            for (var i = 0; i < tabelaSuoku.Length / 9;i++ )
            {
                if (i%3 == 0)
                {
                    Console.WriteLine(line);
                }
                for (var j = 0; j < tabelaSuoku.Length / 9;j++ )
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("|");
                    }

                    Console.Write(" {0} ", tabelaSuoku[i,j]==0?" ": tabelaSuoku[i,j].ToString());
                }

                Console.Write("|");

                Console.WriteLine();
            }
            Console.WriteLine(line);
        }
    }
}
