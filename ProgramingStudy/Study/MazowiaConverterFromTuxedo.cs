using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class MazowiaConverterFromTuxedo
    {
        public enum EncodingTuxedoType
        {
            PL_ISO = 0,
            PL_WIN,
            PL_LTN,
            PL_MZV,
            PL_ATM,
            PL_BEZ
        }

        private static int[,] lc_tab_pl =
        {
            {161,198,202,163,209,211,166,172,175,177,230,234,179,241,243,182,188,191},
            {165,198,202,163,209,211,140,143,175,185,230,234,179,241,243,156,159,191},
            {164,143,168,157,227,224,151,141,189,165,134,169,136,228,162,152,171,190},
            {143,149,144,156,165,163,152,160,161,134,141,145,146,164,162,158,166,167},
            {196,199,203,208,209,211,214,218,220,228,231,235,240,241,243,246,250,252},
            { 65, 67, 69, 76, 78, 79, 83, 90, 90, 97, 99,101,108,110,111,115,122,122}
        };


        public static byte[] FrzKonwPL(byte[] toConvertString, EncodingTuxedoType iZ, EncodingTuxedoType iDo)
        {
            if (iZ < 0 || (short)iZ > 5 || (short)iDo < 0 || (short)iDo > 5)
            {
                return new byte[0];
            }

            for (var i = 0; i < toConvertString.Length; i++)
            {
                for (var j = 0; j < 18; j++)
                {
                    if (toConvertString[i] == lc_tab_pl[(short)iZ, j])
                    {
                        toConvertString[i] = (byte)lc_tab_pl[(short)iDo, j];
                        break;
                    }
                }
            }

            return toConvertString;
        }
    }
}
