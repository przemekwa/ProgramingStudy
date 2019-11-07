using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Execute(DateTime="25-10-2019 14:53")]
    public class ienumerableStudy : IStudyTest
    {
        public class Line
        {

        }

        public class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;

            }

            public IEnumerable<Point> MyProperty { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        public void Study()
        {
            IEnumerable<Point> list = new List<Point>
            {
                new Point(1,1),
                new Point(2,2),
                new Point(3,4)
            };

            IEnumerable<Point> list2 = new List<Point>
            {
                new Point(1,1),
                new Point(2,2),
                new Point(3,4)
            };

            foreach (var point in list)
            {
                point.MyProperty = list2.Take(2);
            }

            var t = list;


            
        }
    }
}
