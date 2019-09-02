using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class RemoveCharsFromXML : IStudyTest
    {
        public void Study()
        {
            var stringTest = "ążźśęćńłó";

            Console.WriteLine(CleanInvalidXmlChars(stringTest));

        }


        public string CleanInvalidXmlChars(string StrInput)
        {

            if (string.IsNullOrWhiteSpace(StrInput))
            {
                return StrInput;
            }

            // From xml spec valid chars:
            // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]    
            // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF.

            string RegularExp = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(StrInput, RegularExp, String.Empty);
        }
    }
}
