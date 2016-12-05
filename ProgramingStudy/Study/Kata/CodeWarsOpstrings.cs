using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.Kata
{
    public class CodeWarsOpstrings : IStudyTest
    {
        public static readonly Func<string, string> Diag1Sym = Diag1Sym1;
        public static readonly Func<string, string> Rot90Clock = Rot90Clock1;
        public static readonly Func<string, string> SelfieAndDiag1 = SelfieAndDiag11;
        public const string SEPARATOR = "\n";

        public static string Rot90Clock1(string strng)
        {
            return "";
        }
        public static string Diag1Sym1(string strng)
        {
            var lenght = strng.Split(new[] { SEPARATOR }, StringSplitOptions.None).First().Length;

            var result = new StringBuilder();

            for (var i = 0; i < lenght; i++)
            {
                for (var j = 0; j < lenght; j++)
                {
                    result.Append(strng[i+(lenght*j)+j]);
                }

                if (i < lenght-1)
                {
                    result.Append(SEPARATOR);
                }
            }

            return result.ToString();
        }
        public static string SelfieAndDiag11(string strng)
        {
            return "";
        }
        public static string Oper(Func<string, string> fct, string s)
        {
            return fct.Invoke(s);
        }

        public void Study()
        {
            Console.WriteLine(Oper(CodeWarsOpstrings.Diag1Sym, "wuUyPC\neNHWxw\nehifmi\ntBTlFI\nvWNpdv\nIFkGjZ"));
        }
    }
}
