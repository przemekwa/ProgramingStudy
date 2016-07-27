using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProgramingStudy.Study.LanguageStudy
{
    public class C6News : IStudyTest
    {
        public int MyProperty { get; set; } = 20;

        public override string ToString() => "3, 323";

        public void Study()
        {
            var stringNew = $"Moja wartość: {MyProperty}";

            var d = new Dictionary<int, string>()
            {
                [2] = "sds",
                [3] = "dsds"
            };

            int? s = 2;

            var stringCut = stringNew?.Substring(2);

            this.Foo(2);

            WriteLine("sdsds");
        }

        public decimal Okres => 12M + this.MyProperty;

        public int Foo(int a) => a + 2;
    }
}
