using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class FizzBuzz : IStudyTest
    {
        public void Study()
        {
            var number = 15;

            var p3 = number % 3 == 0;
            var p5 = number % 5 == 0;

            var t = new List<Object>
            {
                number%3 == 0,
                "Fizz",
                number%5 == 0,
                "Buzz",
            };

            var result = string.Empty;

            for (var i = 0; i < t.Count; i = i + 2)
            {
                if ((bool)t[i])
                {
                    result += t[i + 1];
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                result = number.ToString();
            }

            Console.WriteLine(result);


            if (p3 && p5)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (p3)
            {
                Console.WriteLine("Fizz");
            }
            else if (p5)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }
    }
}
