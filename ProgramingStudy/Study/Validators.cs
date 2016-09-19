using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class Validator
    {
        public static bool IsPeselValid(string pesel)
        {
            if (pesel == null || pesel.Length != 11)
            {
                return false;
            }

            if (pesel == "00000000000")
            {
                return false;
            }

            int checksum;
            int[] weights;

            weights = new[] { 1, 3, 7, 9 };
            checksum = 0;
            for (int i = 0; i <= 9; i++)
            {
                int digit;
                if (!int.TryParse(pesel.Substring(i, 1), out digit))
                {
                    return false;
                }

                checksum = (checksum + digit * weights[i % 4]) % 10;
            }

            checksum = (10 - checksum) % 10;
            if (pesel.Substring(10) != checksum.ToString())
            {
                return false;
            }

            DateTime dt;
            if (!Validator.ExtractDateFromPesel(pesel, out dt))
            {
                return false;
            }

            return true;
        }

        public static bool ExtractDateFromPesel(string pesel, out DateTime dob)
        {
            int year, month, day;

            dob = new DateTime(1000, 1, 1);
            year = int.Parse(pesel.Substring(0, 2));
            month = int.Parse(pesel.Substring(2, 2));
            day = int.Parse(pesel.Substring(4, 2));

            if (month >= 81 && month <= 92)
            {
                year = year + 1800;
                month = month - 80;
            }
            else
            {
                if (month >= 1 && month <= 12)
                {
                    year = year + 1900;
                }
                else
                {
                    if (month >= 21 && month <= 32)
                    {
                        year = year + 2000;
                        month = month - 20;
                    }
                    else
                    {
                        if (month >= 41 && month <= 52)
                        {
                            year = year + 2000;
                            month = month - 40;
                        }
                        else
                        {
                            if (month >= 61 && month <= 72)
                            {
                                year = year + 2000;
                                month = month - 60;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            try
            {
                dob = new DateTime(year, month, day);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
