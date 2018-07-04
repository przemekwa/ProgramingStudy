using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class RegExpTests : IStudyTest
    {
        public void Study()
        {

            Grouping();

            //var pattern = @"(?s)[\s\S]+(?=\r.+Business Consulting Center sp. z o.o.\r\nZłotniki, ul. Krzemowa 1, 62-002 Suchy Las k. Poznania)";

            //var @string = File.ReadAllText("Job/emails.txt");

           

            //var f= new Regex(pattern,RegexOptions.Compiled);

            //var d = f.Matches(@string);

            //Console.WriteLine($"Found: {d.Count}");
 
        }

        private void Grouping()
        {
            var pattern = @"(?s)\k<a>";

             var f= new Regex(pattern);

            var d = f.Matches("deep");

            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
         
        }
    }
}
