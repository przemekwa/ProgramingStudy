using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class MazowiaEncoding : IStudyTest
    {
        public void Study()
        {
            string[] stringTab =
            {
                "ą", "ć", "ę", "ł", "ń", "ó", "ś", "ź", "ż","ţ"
            };

            byte[] byteMazoviaCheck =
            {
                134, 141, 145, 146, 164, 162, 158, 166, 167,254
            };


            for (int index = 0; index < stringTab.Length; index++)
            {
                var temp =
                    MazowiaConverterFromTuxedo.FrzKonwPL(Encoding.GetEncoding("iso-8859-2").GetBytes(stringTab[index]),
                        MazowiaConverterFromTuxedo.EncodingTuxedoType.PL_ISO,
                        MazowiaConverterFromTuxedo.EncodingTuxedoType.PL_MZV);

                if (byteMazoviaCheck[index] != temp[0])
                {
                    throw new Exception();
                }



                var temp2 = MazowiaConverterFromTuxedo.FrzKonwPL(temp,
                        MazowiaConverterFromTuxedo.EncodingTuxedoType.PL_MZV,
                        MazowiaConverterFromTuxedo.EncodingTuxedoType.PL_ISO);


                if (temp2[0] != (Encoding.GetEncoding("iso-8859-2").GetBytes(stringTab[index]))[0])
                {
                    throw new Exception();
                }

                var t = Encoding.GetEncoding("iso-8859-2").GetString(temp2);

                if (t == "ţ")
                {
                    throw new Exception();
                }
            }
        }
    }
   
}
