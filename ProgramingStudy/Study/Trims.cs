using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class Trims : IStudyTest
    {
        public void Study()
        {
            var tekst = " sdsd  Przemek walkowski dsd   ";

            var newTekst = tekst.Trim();
            var newTekstEnd = tekst.TrimEnd();
            var newTekstStart = tekst.TrimStart();

            var list = new List<string>();

            IEnumerable<string> enumerable()
            {
                foreach (var d in list)
                {
                    yield return d.Trim();
                }
            }

            var t = enumerable();


        }
    }
}
