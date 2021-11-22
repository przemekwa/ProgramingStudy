using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    [ExecuteAttribute(DateTime = "22-11-2021 00:00")]
    internal class GoogleTests1 : IStudyTest
    {
    private const int X = 10;
    private const int Y = 10;

    public void Study()
    {
        Console.WriteLine("Hello Google");

        int[,] testArray = Init();
        Write(testArray);

    }

    private static void Write(int[,] testArray)
    {
        for (int i = 0; i < X; i++)
        {
            Console.WriteLine();

            for (int j = 0; j < Y; j++)
            {
                Console.Write(testArray[i, j]);
            }
        }
    }

    private static int[,] Init()
    {
        var testArray = new int[X, Y];

        testArray[0, 0] = 1;
        testArray[0, 1] = 1;
        testArray[0, 2] = 1;
        testArray[0, 3] = 1;
        testArray[0, 4] = 1;
        testArray[0, 5] = 1;
        testArray[0, 6] = 1;
        testArray[0, 7] = 1;
        testArray[0, 8] = 1;
        testArray[0, 9] = 1;

        testArray[1, 0] = 1;
        testArray[1, 1] = 1;
        testArray[1, 2] = 1;
        testArray[1, 3] = 1;
        testArray[1, 4] = 1;
        testArray[1, 5] = 1;
        testArray[1, 6] = 1;
        testArray[1, 7] = 1;
        testArray[1, 8] = 1;
        testArray[1, 9] = 1;

        testArray[2, 0] = 1;
        testArray[2, 1] = 1;
        testArray[2, 2] = 1;
        testArray[2, 3] = 1;
        testArray[2, 4] = 1;
        testArray[2, 5] = 1;
        testArray[2, 6] = 1;
        testArray[2, 7] = 1;
        testArray[2, 8] = 1;
        testArray[2, 9] = 1;


        testArray[3, 0] = 1;
        testArray[3, 1] = 1;
        testArray[3, 2] = 1;
        testArray[3, 3] = 1;
        testArray[3, 4] = 1;
        testArray[3, 5] = 1;
        testArray[3, 6] = 1;
        testArray[3, 7] = 1;
        testArray[3, 8] = 1;
        testArray[3, 9] = 1;


        testArray[4, 0] = 1;
        testArray[4, 1] = 1;
        testArray[4, 2] = 1;
        testArray[4, 3] = 1;
        testArray[4, 4] = 1;
        testArray[4, 5] = 1;
        testArray[4, 6] = 1;
        testArray[4, 7] = 1;
        testArray[4, 8] = 1;
        testArray[4, 9] = 1;

        testArray[5, 0] = 1;
        testArray[5, 1] = 1;
        testArray[5, 2] = 1;
        testArray[5, 3] = 1;
        testArray[5, 4] = 1;
        testArray[5, 5] = 1;
        testArray[5, 6] = 1;
        testArray[5, 7] = 1;
        testArray[5, 8] = 1;
        testArray[5, 9] = 1;


        testArray[6, 0] = 1;
        testArray[6, 1] = 1;
        testArray[6, 2] = 1;
        testArray[6, 3] = 1;
        testArray[6, 4] = 1;
        testArray[6, 5] = 1;
        testArray[6, 6] = 1;
        testArray[6, 7] = 1;
        testArray[6, 8] = 1;
        testArray[6, 9] = 1;


        testArray[7, 0] = 1;
        testArray[7, 1] = 1;
        testArray[7, 2] = 1;
        testArray[7, 3] = 1;
        testArray[7, 4] = 1;
        testArray[7, 5] = 1;
        testArray[7, 6] = 1;
        testArray[7, 7] = 1;
        testArray[7, 8] = 1;
        testArray[7, 9] = 1;



        testArray[8, 0] = 1;
        testArray[8, 1] = 1;
        testArray[8, 2] = 1;
        testArray[8, 3] = 1;
        testArray[8, 4] = 1;
        testArray[8, 5] = 1;
        testArray[8, 6] = 1;
        testArray[8, 7] = 1;
        testArray[8, 8] = 1;
        testArray[8, 9] = 1;

        testArray[9, 0] = 1;
        testArray[9, 1] = 1;
        testArray[9, 2] = 1;
        testArray[9, 3] = 1;
        testArray[9, 4] = 1;
        testArray[9, 5] = 1;
        testArray[9, 6] = 1;
        testArray[9, 7] = 1;
        testArray[9, 8] = 1;
        testArray[9, 9] = 1;
        return testArray;
    }
}

