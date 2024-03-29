﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet.adventofcode
{
    /// <summary>
    /// https://adventofcode.com/2021/day/2
    /// </summary>
    [ExecuteAttribute(DateTime = "09-12-2021 10:13")]
    internal class Day2 : IStudyTest
    {
        public void Study()
        {
            var courses = GetCoursePosition();

            var result = CalculatePosition(courses);

            Console.WriteLine($"Result is {result}");
        }

        private int CalculatePosition(List<string> courses)
        {
            var forward = 0;
            var depth = 0;
            var aim = 0;

            foreach (var item in courses)
            {
                switch (item)
                {
                    case string s when s.Contains("down"):
                        aim+= Convert.ToInt32(item.Replace("down", "").Trim());
                        break;
                    case string s when s.Contains("up"):
                        aim -= Convert.ToInt32(item.Replace("up", "").Trim());
                        break;
                    default:
                        var fValue = Convert.ToInt32(item.Replace("forward", "").Trim());
                        forward += fValue;
                        depth += aim * fValue;
                        break;
                }

            }

            return forward * depth;
        }

        private List<string> GetCoursePosition()
        {
            var result = new List<string>
            {
                "forward 7",
                "down 1",
                "forward 9",
                "forward 4",
                "forward 7",
                "down 8",
                "forward 9",
                "down 2",
                "forward 5",
                "down 3",
                "forward 5",
                "up 7",
                "forward 3",
                "down 7",
                "down 8",
                "up 2",
                "down 4",
                "down 7",
                "forward 1",
                "forward 9",
                "down 9",
                "forward 7",
                "forward 8",
                "up 9",
                "down 6",
                "down 7",
                "forward 1",
                "forward 5",
                "forward 3",
                "down 3",
                "down 4",
                "forward 1",
                "forward 1",
                "forward 7",
                "down 4",
                "forward 6",
                "forward 1",
                "forward 9",
                "forward 4",
                "forward 6",
                "forward 6",
                "down 5",
                "down 4",
                "down 8",
                "up 9",
                "up 9",
                "down 6",
                "down 6",
                "forward 4",
                "forward 1",
                "down 1",
                "forward 7",
                "down 1",
                "forward 3",
                "forward 7",
                "forward 3",
                "up 8",
                "down 7",
                "down 4",
                "forward 7",
                "forward 1",
                "forward 2",
                "down 1",
                "down 4",
                "up 2",
                "up 8",
                "forward 6",
                "forward 5",
                "down 9",
                "up 8",
                "forward 1",
                "up 9",
                "down 7",
                "forward 1",
                "forward 5",
                "up 1",
                "up 7",
                "down 1",
                "down 5",
                "forward 9",
                "down 5",
                "up 5",
                "forward 8",
                "forward 9",
                "down 8",
                "forward 1",
                "down 1",
                "forward 7",
                "down 8",
                "up 4",
                "forward 9",
                "up 1",
                "down 7",
                "forward 4",
                "up 8",
                "down 5",
                "down 2",
                "down 1",
                "forward 5",
                "forward 3",
                "up 5",
                "forward 6",
                "up 1",
                "up 6",
                "up 2",
                "up 6",
                "up 5",
                "down 6",
                "forward 5",
                "down 4",
                "forward 7",
                "up 5",
                "down 3",
                "forward 9",
                "down 5",
                "down 2",
                "up 2",
                "forward 2",
                "down 1",
                "up 3",
                "down 8",
                "forward 8",
                "down 8",
                "forward 6",
                "forward 4",
                "forward 7",
                "forward 6",
                "up 6",
                "down 4",
                "forward 7",
                "forward 9",
                "forward 2",
                "forward 5",
                "down 4",
                "forward 4",
                "forward 9",
                "forward 2",
                "down 2",
                "forward 8",
                "up 8",
                "forward 1",
                "down 6",
                "forward 5",
                "down 4",
                "down 4",
                "down 7",
                "down 5",
                "forward 7",
                "forward 7",
                "down 9",
                "up 9",
                "forward 4",
                "down 2",
                "forward 6",
                "down 4",
                "forward 8",
                "forward 4",
                "up 5",
                "forward 8",
                "down 2",
                "forward 8",
                "forward 6",
                "forward 9",
                "down 7",
                "forward 1",
                "forward 1",
                "forward 1",
                "down 3",
                "forward 2",
                "down 5",
                "forward 3",
                "forward 8",
                "forward 4",
                "forward 7",
                "forward 8",
                "up 7",
                "down 2",
                "up 7",
                "forward 4",
                "forward 7",
                "down 4",
                "down 7",
                "down 3",
                "down 8",
                "forward 2",
                "down 2",
                "forward 2",
                "down 6",
                "forward 2",
                "down 8",
                "forward 2",
                "forward 5",
                "down 5",
                "forward 4",
                "down 7",
                "up 8",
                "up 7",
                "down 2",
                "down 1",
                "forward 4",
                "down 2",
                "forward 9",
                "down 2",
                "down 2",
                "forward 7",
                "forward 3",
                "forward 6",
                "up 8",
                "up 7",
                "forward 1",
                "forward 3",
                "down 9",
                "down 1",
                "forward 8",
                "down 7",
                "up 8",
                "down 3",
                "up 4",
                "forward 9",
                "forward 6",
                "up 6",
                "up 4",
                "down 2",
                "down 4",
                "forward 7",
                "down 2",
                "down 9",
                "forward 1",
                "forward 9",
                "down 6",
                "forward 1",
                "down 8",
                "forward 9",
                "down 9",
                "down 6",
                "up 4",
                "forward 5",
                "up 9",
                "down 2",
                "forward 7",
                "down 1",
                "down 1",
                "down 7",
                "down 4",
                "down 1",
                "down 6",
                "forward 4",
                "forward 6",
                "up 1",
                "down 8",
                "down 4",
                "forward 1",
                "down 5",
                "down 4",
                "up 1",
                "down 9",
                "forward 1",
                "down 1",
                "up 8",
                "forward 8",
                "forward 8",
                "down 5",
                "down 2",
                "down 3",
                "forward 1",
                "down 1",
                "forward 3",
                "down 7",
                "forward 7",
                "forward 1",
                "forward 3",
                "forward 5",
                "forward 3",
                "down 8",
                "forward 1",
                "up 2",
                "up 3",
                "down 4",
                "down 4",
                "up 4",
                "down 4",
                "up 8",
                "down 8",
                "down 7",
                "down 6",
                "forward 5",
                "down 3",
                "forward 2",
                "up 9",
                "down 7",
                "forward 2",
                "down 1",
                "down 3",
                "down 7",
                "down 1",
                "forward 7",
                "down 2",
                "down 9",
                "down 7",
                "up 1",
                "down 5",
                "forward 7",
                "forward 2",
                "forward 7",
                "forward 3",
                "down 2",
                "down 8",
                "up 3",
                "down 3",
                "forward 3",
                "down 2",
                "up 7",
                "up 1",
                "forward 5",
                "down 6",
                "down 3",
                "forward 6",
                "forward 8",
                "forward 2",
                "down 9",
                "down 1",
                "down 1",
                "down 4",
                "forward 8",
                "down 3",
                "up 3",
                "up 4",
                "forward 3",
                "forward 7",
                "down 3",
                "up 6",
                "down 8",
                "up 4",
                "up 3",
                "forward 5",
                "down 9",
                "down 2",
                "forward 6",
                "forward 4",
                "up 6",
                "up 1",
                "forward 4",
                "forward 7",
                "forward 1",
                "forward 8",
                "forward 3",
                "forward 3",
                "forward 9",
                "forward 4",
                "forward 4",
                "forward 4",
                "forward 2",
                "forward 7",
                "down 8",
                "forward 5",
                "up 1",
                "forward 3",
                "forward 7",
                "down 3",
                "forward 7",
                "up 6",
                "forward 4",
                "up 2",
                "down 7",
                "down 4",
                "up 3",
                "up 7",
                "down 1",
                "forward 5",
                "up 7",
                "up 7",
                "down 7",
                "down 9",
                "down 7",
                "forward 5",
                "forward 7",
                "down 1",
                "down 5",
                "down 6",
                "forward 6",
                "up 7",
                "forward 7",
                "forward 6",
                "down 4",
                "down 3",
                "down 9",
                "up 5",
                "down 9",
                "down 3",
                "forward 8",
                "forward 1",
                "forward 5",
                "down 6",
                "forward 7",
                "down 7",
                "forward 8",
                "down 9",
                "up 1",
                "up 2",
                "forward 2",
                "down 4",
                "up 1",
                "forward 2",
                "forward 9",
                "down 8",
                "forward 3",
                "up 3",
                "up 3",
                "forward 3",
                "down 7",
                "down 5",
                "forward 2",
                "up 3",
                "forward 3",
                "forward 5",
                "up 5",
                "forward 3",
                "down 1",
                "down 3",
                "down 6",
                "down 1",
                "forward 7",
                "forward 6",
                "down 5",
                "down 2",
                "forward 7",
                "down 3",
                "forward 2",
                "forward 2",
                "forward 2",
                "down 1",
                "forward 4",
                "forward 5",
                "down 8",
                "up 8",
                "up 7",
                "down 7",
                "forward 9",
                "down 8",
                "forward 1",
                "forward 6",
                "up 3",
                "forward 8",
                "up 9",
                "down 6",
                "down 9",
                "up 4",
                "down 1",
                "forward 1",
                "up 7",
                "down 4",
                "forward 7",
                "forward 4",
                "down 2",
                "forward 3",
                "forward 4",
                "down 7",
                "forward 5",
                "up 8",
                "down 9",
                "down 3",
                "forward 3",
                "forward 8",
                "down 7",
                "forward 1",
                "up 7",
                "down 7",
                "forward 7",
                "down 9",
                "down 6",
                "down 3",
                "down 1",
                "up 5",
                "up 6",
                "forward 8",
                "down 8",
                "up 1",
                "forward 6",
                "up 2",
                "down 6",
                "down 7",
                "down 5",
                "forward 7",
                "up 3",
                "up 6",
                "down 3",
                "up 9",
                "forward 9",
                "down 2",
                "down 4",
                "up 2",
                "forward 7",
                "down 7",
                "up 4",
                "forward 2",
                "down 4",
                "forward 7",
                "up 9",
                "forward 4",
                "forward 9",
                "down 8",
                "up 2",
                "up 2",
                "forward 2",
                "up 8",
                "forward 1",
                "forward 8",
                "forward 8",
                "down 9",
                "forward 6",
                "up 1",
                "down 3",
                "down 4",
                "down 6",
                "forward 6",
                "up 6",
                "down 2",
                "down 1",
                "down 1",
                "forward 9",
                "forward 2",
                "down 7",
                "down 8",
                "down 6",
                "down 3",
                "forward 1",
                "up 6",
                "up 4",
                "forward 3",
                "down 1",
                "forward 6",
                "down 8",
                "forward 6",
                "forward 5",
                "down 3",
                "down 5",
                "up 2",
                "down 7",
                "forward 8",
                "down 8",
                "up 3",
                "down 4",
                "down 3",
                "down 4",
                "up 9",
                "up 6",
                "forward 5",
                "forward 8",
                "down 8",
                "forward 1",
                "forward 8",
                "down 1",
                "down 3",
                "down 4",
                "down 6",
                "forward 3",
                "down 8",
                "down 9",
                "down 3",
                "forward 3",
                "forward 2",
                "forward 2",
                "down 1",
                "up 7",
                "down 6",
                "up 2",
                "down 9",
                "down 4",
                "down 3",
                "down 5",
                "down 4",
                "forward 4",
                "up 8",
                "forward 1",
                "down 9",
                "down 3",
                "down 3",
                "down 8",
                "down 5",
                "up 6",
                "up 5",
                "down 7",
                "down 3",
                "down 7",
                "forward 1",
                "up 5",
                "down 1",
                "forward 1",
                "down 7",
                "down 9",
                "down 3",
                "forward 1",
                "forward 7",
                "down 8",
                "forward 5",
                "up 5",
                "forward 2",
                "down 6",
                "forward 2",
                "down 2",
                "forward 2",
                "up 7",
                "down 2",
                "down 5",
                "down 2",
                "forward 7",
                "forward 2",
                "forward 4",
                "down 2",
                "down 7",
                "down 6",
                "forward 9",
                "down 8",
                "down 3",
                "down 6",
                "forward 7",
                "down 3",
                "down 4",
                "down 7",
                "down 7",
                "down 1",
                "up 8",
                "up 7",
                "up 6",
                "down 8",
                "up 8",
                "forward 8",
                "down 2",
                "down 4",
                "forward 7",
                "forward 4",
                "down 5",
                "down 4",
                "down 3",
                "forward 6",
                "up 9",
                "down 1",
                "down 3",
                "down 4",
                "down 7",
                "up 3",
                "up 4",
                "forward 1",
                "up 4",
                "down 9",
                "up 4",
                "up 3",
                "down 1",
                "down 2",
                "forward 5",
                "up 4",
                "down 1",
                "down 4",
                "down 8",
                "down 1",
                "up 6",
                "down 6",
                "forward 8",
                "forward 7",
                "down 5",
                "down 6",
                "down 5",
                "down 6",
                "down 9",
                "forward 6",
                "down 6",
                "down 7",
                "forward 3",
                "down 2",
                "down 9",
                "up 2",
                "down 6",
                "forward 2",
                "forward 6",
                "forward 4",
                "down 4",
                "forward 8",
                "forward 2",
                "forward 7",
                "forward 4",
                "down 9",
                "forward 6",
                "down 6",
                "forward 1",
                "down 4",
                "down 5",
                "forward 5",
                "up 5",
                "forward 7",
                "up 2",
                "down 9",
                "forward 9",
                "down 9",
                "forward 9",
                "forward 3",
                "forward 7",
                "forward 5",
                "forward 1",
                "down 5",
                "forward 5",
                "down 3",
                "down 2",
                "up 9",
                "down 7",
                "down 2",
                "forward 3",
                "down 8",
                "down 6",
                "down 7",
                "up 5",
                "up 9",
                "down 6",
                "down 8",
                "down 5",
                "down 8",
                "forward 4",
                "forward 5",
                "down 2",
                "down 1",
                "forward 6",
                "down 6",
                "forward 9",
                "forward 2",
                "forward 1",
                "down 3",
                "forward 8",
                "forward 6",
                "up 7",
                "forward 5",
                "down 4",
                "up 7",
                "down 6",
                "down 3",
                "up 8",
                "forward 5",
                "forward 5",
                "down 1",
                "down 7",
                "forward 2",
                "down 5",
                "forward 3",
                "forward 6",
                "forward 6",
                "up 5",
                "down 4",
                "down 2",
                "forward 7",
                "up 8",
                "forward 5",
                "up 7",
                "forward 6",
                "forward 6",
                "forward 6",
                "up 7",
                "down 1",
                "down 4",
                "down 4",
                "forward 5",
                "down 5",
                "up 7",
                "down 7",
                "forward 8",
                "down 6",
                "down 2",
                "forward 3",
                "down 8",
                "up 3",
                "down 2",
                "forward 7",
                "down 1",
                "forward 3",
                "up 1",
                "up 4",
                "down 4",
                "up 6",
                "down 1",
                "down 2",
                "forward 9",
                "up 8",
                "forward 3",
                "down 2",
                "forward 3",
                "down 7",
                "up 6",
                "forward 9",
                "down 3",
                "down 9",
                "up 5",
                "down 9",
                "down 6",
                "forward 8",
                "forward 5",
                "down 8",
                "forward 5",
                "forward 9",
                "up 1",
                "down 3",
                "up 2",
                "down 1",
                "down 2",
                "down 8",
                "forward 9",
                "forward 9",
                "down 7",
                "down 7",
                "down 5",
                "down 1",
                "down 7",
                "up 1",
                "up 1",
                "forward 8",
                "down 6",
                "up 8",
                "down 7",
                "down 1",
                "forward 1",
                "forward 4",
                "down 9",
                "up 2",
                "down 6",
                "forward 2",
                "down 4",
                "forward 7",
                "up 8",
                "down 3",
                "forward 9",
                "down 7",
                "up 7",
                "down 6",
                "down 9",
                "down 2",
                "up 7",
                "down 3",
                "down 9",
                "forward 7",
                "down 7",
                "up 6",
                "down 5",
                "down 4",
                "up 1",
                "down 1",
                "up 7",
                "up 9",
                "down 1",
                "forward 6",
                "forward 3",
                "down 5",
                "down 1",
                "up 8",
                "forward 9",
                "forward 6",
                "down 1",
                "up 3",
                "down 2",
                "forward 3",
                "up 6",
                "down 5",
                "down 3",
                "up 7",
                "down 8",
                "down 5",
                "down 3",
                "forward 6",
                "up 8",
                "down 4",
                "forward 3",
                "forward 5",
                "forward 9",
                "forward 1",
                "up 4",
                "forward 8",
                "forward 9",
                "forward 1",
                "up 9",
                "up 4",
                "forward 4",
                "forward 4",
                "forward 8",
                "up 5",
                "up 2",
                "down 7",
                "down 4",
                "up 5",
                "down 5",
                "forward 6",
                "up 8",
                "down 5",
                "down 7",
                "down 3",
                "up 2",
                "up 2",
                "forward 3",
                "forward 5",
                "forward 1",
                "forward 9",
                "forward 1",
                "down 2",
                "down 2",
                "up 6",
                "up 6",
                "down 5",
                "down 3",
                "down 4",
                "forward 4",
                "down 6",
                "up 6",
                "forward 8",
                "down 9",
                "forward 2",
                "forward 6",
                "down 7",
                "forward 3",
                "down 2",
                "down 5",
                "up 3",
                "forward 6",
                "forward 7",
                "forward 3",
                "forward 4",
                "down 9",
                "up 9",
                "forward 7",
                "down 8",
                "forward 1",
                "down 2",
                "up 5",
                "up 9",
                "forward 8",
                "up 5",
                "forward 7",
                "up 6",
                "forward 9",
                "down 6",
                "forward 4",
                "down 4",
                "forward 7",
                "up 8",
                "down 8",
                "down 7",
                "down 9",
                "up 1",
                "down 5",
                "forward 6",
                "down 9",
                "down 2",
                "down 2",
                "down 6",
                "down 6",
                "forward 8",
                "forward 5",
                "up 7",
                "forward 9",
                "forward 3",
                "forward 8",
                "forward 8",
                "down 7",
                "up 1",
                "down 4",
                "forward 7",
                "up 5",
                "down 9",
                "down 7",
                "forward 8",
                "down 3",
                "up 2",
                "down 7",
                "forward 3",
                "up 8",
                "forward 4",
                "up 2",
                "forward 1",
                "forward 4",
                "forward 5",
                "forward 3",
                "forward 6",
                "down 9",
                "up 7",
                "forward 7",
                "up 6",
                "down 2",
                "down 5",
                "forward 2",
                "forward 8",
                "down 3",
                "forward 6",
                "down 6",
                "forward 4",
                "up 3",
                "forward 3",
                "down 4",
                "up 3",
                "forward 6",
                "forward 7",
                "down 5",
                "forward 5",
                "down 9",
                "forward 7",
                "down 5",
                "down 6",
                "forward 9"
            };



            var resultTest = new List<string>
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2",
            };

            return result;
        }
    }
}
