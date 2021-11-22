﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    [ExecuteAttribute(DateTime = "22-11-2021 00:00")]
    internal class GoogleTests1 : IStudyTest
    {
    private const int X = 6;
    private const int Y = 6;

    public void Study()
    {
        Console.WriteLine("Hello Google from https://www.youtube.com/watch?v=4tYoVx0QoN0");

        int[,] testArray = Init();
        Write(testArray);
        var resolveArray = RemoveIslands(testArray);
        CheckAnswer(resolveArray);
    }

    private void CheckAnswer( int[,] resolveArray)
    {
        var correctArray = new int[X, Y];

        correctArray[0, 0] = 1;
        correctArray[0, 1] = 0;
        correctArray[0, 2] = 0;
        correctArray[0, 3] = 0;
        correctArray[0, 4] = 0;
        correctArray[0, 5] = 0;


        correctArray[1, 0] = 0;
        correctArray[1, 1] = 0;
        correctArray[1, 2] = 0;
        correctArray[1, 3] = 1;
        correctArray[1, 4] = 1;
        correctArray[1, 5] = 1;


        correctArray[2, 0] = 0;
        correctArray[2, 1] = 0;
        correctArray[2, 2] = 0;
        correctArray[2, 3] = 0;
        correctArray[2, 4] = 1;
        correctArray[2, 5] = 0;



        correctArray[3, 0] = 1;
        correctArray[3, 1] = 1;
        correctArray[3, 2] = 0;
        correctArray[3, 3] = 0;
        correctArray[3, 4] = 1;
        correctArray[3, 5] = 0;


        correctArray[4, 0] = 1;
        correctArray[4, 1] = 0;
        correctArray[4, 2] = 0;
        correctArray[4, 3] = 0;
        correctArray[4, 4] = 0;
        correctArray[4, 5] = 0;

        correctArray[5, 0] = 1;
        correctArray[5, 1] = 0;
        correctArray[5, 2] = 0;
        correctArray[5, 3] = 0;
        correctArray[5, 4] = 0;
        correctArray[5, 5] = 1;

        //Write(correctArray);

        var result = true;

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (correctArray[i, j] != resolveArray[i, j])
                {
                    result = false;
                    break;
                }
            
            }

            if (result == false)
            {
                break;
            }

            
        }


        if (result)
        {
            
            Console.WriteLine("Sucess!");
        }
        else
        {
            Console.WriteLine("Wrong!");
        }
        

    }

    private int[,] RemoveIslands(int[,] testArray)
    {
        return testArray;
    }

    private static void Write(int[,] testArray)
    {
        Console.WriteLine("");

        for (int i = 0; i < X; i++)
        {
            Console.WriteLine("");

            for (int j = 0; j < Y; j++)
            {
                Console.Write($"{testArray[i, j]}");

                if (j == Y-1)
                {
                    continue;
                }
                Console.Write(" ,");
            }
        }

        Console.WriteLine("");
    }

    private static int[,] Init()
    {
        var testArray = new int[X, Y];

        testArray[0, 0] = 1;
        testArray[0, 1] = 0;
        testArray[0, 2] = 0;
        testArray[0, 3] = 0;
        testArray[0, 4] = 0;
        testArray[0, 5] = 0;
        

        testArray[1, 0] = 0;
        testArray[1, 1] = 1;
        testArray[1, 2] = 0;
        testArray[1, 3] = 1;
        testArray[1, 4] = 1;
        testArray[1, 5] = 1;
        

        testArray[2, 0] = 0;
        testArray[2, 1] = 0;
        testArray[2, 2] = 1;
        testArray[2, 3] = 0;
        testArray[2, 4] = 1;
        testArray[2, 5] = 0;
        


        testArray[3, 0] = 1;
        testArray[3, 1] = 1;
        testArray[3, 2] = 0;
        testArray[3, 3] = 0;
        testArray[3, 4] = 1;
        testArray[3, 5] = 0;
       

        testArray[4, 0] = 1;
        testArray[4, 1] = 0;
        testArray[4, 2] = 1;
        testArray[4, 3] = 1;
        testArray[4, 4] = 0;
        testArray[4, 5] = 0;
       
        testArray[5, 0] = 1;
        testArray[5, 1] = 0;
        testArray[5, 2] = 0;
        testArray[5, 3] = 0;
        testArray[5, 4] = 0;
        testArray[5, 5] = 1;
        

        return testArray;
    }
}

