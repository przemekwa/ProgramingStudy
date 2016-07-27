using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.LanguageStudy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;




    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BaseBase
    {
        public BaseBase(string a)
        {
            Console.WriteLine("Bazowa " + a);
        }
    }


    public class Dziedziczona : BaseBase
    {
        public Dziedziczona(string b) : base(b)
        {
            Console.WriteLine("Dziedziczona");
        }

    }

    class Inheritance : IStudyTest
    {
        public void Study()
        {
            new BaseBase("Przemek");
            new Dziedziczona("Dziedziczona");

        }
    }
}
