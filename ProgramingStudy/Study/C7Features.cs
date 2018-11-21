using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study
{
    public class C7Features : IStudyTest
    {

        private int _prop;

        public int Prop
        {
            get => _prop;
            set => value = _prop;
        }

        public C7Features(int d) => this.Prop = d;


        public void Study()
        {
            OutVariable();
            Tuple();
            Discards();
            PatternMatchingIs();
            RefReturn();
            LocalFunction();
            Constructors();
            NumericLiterals();        
        }

        private void NumericLiterals()
        {
            const long BillionsAndBillions = 100_000_000_000;
           
            const double AvogadroConstant = 6.022_140_857_747_474e23;
            
            decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
            
            const int Sixteen =   0b0001_0000;
            
            const int ThirtyTwo = 0b0010_0000;
            
            const int SixtyFour = 0b0100_0000;
            
            const int OneHundredTwentyEight = 0b1000_0000;

            const int One =  0b0001;

            const int Two =  0b0010;
            
            const int Four = 0b0100;
            
            const int Eight = 0b1000;
        }

        private int SomeFunction => 1983 + 5 + 2;


        private void Constructors()
        {


        }

        private void LocalFunction()
        {
            var resultSet = GetList(2);

            // no exception because no iterate 

            foreach (var item in resultSet)
            {

            }
        }

        private IEnumerable<int> GetList(int i)
        {
            if (i < 3)
            {
                throw new Exception();
            }

            return returnList();

            IEnumerable<int> returnList()
            {
                foreach (var item in Enumerable.Range(0, 2))
                {
                    yield return item;
                }
            }
        }

        private void RefReturn()
        {
            var array = new int[4];

            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;

            ref var item2 = ref GetItem(array, 1);

            item2 = 100;

            WriteLine(array[1]);  // 100
        }

        private ref int GetItem(int[] array, int v)
        {
            return ref array[v];
        }

        private void PatternMatchingIs()
        {
            var type = new Point();

            if (type is var point)
            {
                WriteLine(point.X);
                WriteLine(point.Y);
            }

            DiceSum(new List<object> { 2, 3, new List<object> { 4, 5, 6 } });


        }

        public static int DiceSum(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 1:
                        sum += 1;
                        break;
                    case int val when val == 5:
                        sum += 5;
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList:
                        sum += DiceSum(subList);
                        break;
                }
            }
            return sum;
        }

        private void Discards()
        {
            var tuple = (2, "Day");

            (var day, _) = tuple;
        }

        private void Tuple()
        {
            // old times

            var tuple = GetTuple();

            var year = tuple.Item1;
            var name = tuple.Item2;


            // C7

            NewTuple();

        }

        private void NewTuple()
        {
            var tuple = (1893, "Year");

            var year = tuple.Item1;
            var name = tuple.Item2;

            (var year2, var name2) = tuple;

            WriteLine(year2); // 1983
            WriteLine(name2); // Year

            // tuple

            var model = (Year: 1983, Name: "Year");

            WriteLine(model.Name); // 1983
            WriteLine(model.Year); // Year
        }



        private Tuple<int, string> GetTuple()
            => new Tuple<int, string>(1983, "Year");


        private void OutVariable()
        {
            // old times


            int numericResult;

            if (int.TryParse("83", out numericResult))
            {
                Console.WriteLine(numericResult);
            }

            // C#7

            if (int.TryParse("83", out int numericResult2))
            {
                Console.WriteLine(numericResult2);
            }
        }
    }
}
