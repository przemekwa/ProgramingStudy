using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record Location(int X, int Y, bool isOnBorder);



[ExecuteAttribute(DateTime = "27-11-2021 17:00")]
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
        // Write(resolveArray);
        CheckAnswer(resolveArray);
    }

    private void CheckAnswer(int[,] resolveArray)
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

        Write(correctArray);

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
        var locations = ToLocations(testArray);
        var islandsLocation = GetIslands(locations);

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (islandsLocation.Any(s => s.X == i && s.Y == j))
                {
                    testArray[i, j] = 0;
                }
            }
        }

        return testArray;
    }

    private IEnumerable<Location> ToLocations(int[,] testArray)
    {
        var result = new List<Location>();

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (testArray[i, j] == 1)
                {
                    result.Add(new Location(i, j, IsOnBorder(i, j, testArray)));
                }
            }
        }

        return result;
    }

    private IEnumerable<Location> GetIslands(IEnumerable<Location> locations)
    {
        var islandsLocations = new List<Location>();

        foreach (var currentLocation in locations)
        {
            if (currentLocation.isOnBorder)
            {
                continue;
            }

            var neighbours = locations.Where(s =>
                           (s.X == currentLocation.X + 1 && s.Y == currentLocation.Y)
                           || (s.X == currentLocation.X - 1 && s.Y == currentLocation.Y)
                           || (s.X == currentLocation.X && s.Y == currentLocation.Y + 1)
                           || (s.X == currentLocation.X && s.Y == currentLocation.Y - 1));

            if (neighbours.Any(s => s.isOnBorder))
            {
                continue;
            }

            if (neighbours.Any() == false)
            {
                islandsLocations.Add(currentLocation);
                continue;
            }

            foreach (var neighbourLocation in neighbours)
            {
                var loc = IsLocationOnBoard(neighbourLocation, locations, currentLocation);

                if (loc)
                {
                    break;
                }
                else
                {
                    islandsLocations.Add(currentLocation);
                }
            }
        }

        return islandsLocations;
    }


    private bool IsLocationOnBoard(Location neighboursLocation, IEnumerable<Location> locations, Location currentLocation)
    {
        if (neighboursLocation.isOnBorder)
        {
            return true;
        }


        var neighbours = locations.Where(s =>
                       ((s.X == neighboursLocation.X + 1 && s.Y == neighboursLocation.Y)
                       || (s.X == neighboursLocation.X - 1 && s.Y == neighboursLocation.Y)
                       || (s.X == neighboursLocation.X && s.Y == neighboursLocation.Y + 1)
                       || (s.X == neighboursLocation.X && s.Y == neighboursLocation.Y - 1))
                       && s != currentLocation);



        if (neighbours.Any(s => s.isOnBorder))
        {
            return true;
        }

        if (neighbours.Any() == false)
        {
            return false;
        }

        foreach (var neighbour in neighbours)
        {
            if (IsLocationOnBoard(neighbour, locations, currentLocation))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsOnBorder(int i, int j, int[,] testArray)
    {
        try
        {
            var up = testArray[i + 1, j];
            var down = testArray[i - 1, j];
            var left = testArray[i, j + 1];
            var right = testArray[i, j - 1];

            return false;
        }
        catch (Exception e)
        {
            return true;
        }
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

                if (j == Y - 1)
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

