using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet.C9
{
    public class Pattern_matchnig : IStudyTest
    {
        public void Study()
        {
            var cardNumber = 2;

            string name = cardNumber switch
            {
                >= 10 => "First",
                > 5 => "Second",
                <= -2 => "Last",
                < 0 => "Last",
                _ => "Unknown"
            };


        }
    }
}
