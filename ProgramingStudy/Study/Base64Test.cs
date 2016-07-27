using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class Base64Test : IStudyTest
    {
        public void Study()
        {
            var stringTest = "Idealy sa jak gwiazdy - nie mozna ich osiagnac, ale mozna sie nimi kierowac.";

            var result = Convert.ToBase64String(Encoding.ASCII.GetBytes(stringTest), Base64FormattingOptions.InsertLineBreaks);

            Console.WriteLine(result);

            Console.WriteLine(Encoding.ASCII.GetString(Convert.FromBase64String(result)));

            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            var t = Thread.CurrentPrincipal;

            var bf = new BinaryFormatter();

            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, t);

                var base64 = Convert.ToBase64String(ms.GetBuffer());
            }
            
            //using (var ms = new FileStream("userPrincipial.dat", FileMode.Open))
            //{
            //    var result2 = (WindowsIdentity)bf.Deserialize(ms);
            //               }
        }
    }
}
