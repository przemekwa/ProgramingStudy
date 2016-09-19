using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class Validator
    {
        /// <summary>
        /// Check if NIP is valid. Alroritm on http://pl.wikipedia.org/wiki/NIP
        /// </summary>
        /// <param name="nip">Value of Nip</param>
        /// <returns><c>true</c> if [is valid NIP] [the specified NIP]; otherwise, <c>false</c>.</returns>
        public static bool IsValidNip(string nip)
        {
            if (string.IsNullOrEmpty(nip))
            {
                throw new ArgumentNullException("nip");
            }

            var nipToCheck = nip.Replace("-", "").Replace(" ", "").Trim();

            if (nipToCheck.Length != 10)
            {
                return false;
            }

            var wages = new[]
            {
                6, 5, 7, 2, 3, 4, 5, 6, 7
            };

            var digtArrays = nipToCheck.Select(d => int.Parse(d.ToString(CultureInfo.InvariantCulture))).ToArray();

            var sum =
                digtArrays
                    .Take(9)
                    .Select((digt, index) => new { number = digt, wage = index })
                    .Sum(digt => digt.number * wages[digt.wage]);

            return digtArrays[9] == (sum % 11);
        }

        /// <summary>
        /// Check if REGON is valid. Alroritm on https://pl.wikipedia.org/wiki/REGON
        /// </summary>
        /// <param name="regon">Regon number</param>
        /// <returns><c>true</c> if [is valid REGON] [the specified REGON]; otherwise, <c>false</c>.</returns>
        public static  bool IsValidRegon(string regon)
        {
            if (string.IsNullOrEmpty(regon))
            {
                return false;
            }

            int[] wages;
            int controlNumberFromRegon = 0;
            int controlNumber;

            switch (regon.Length)
            {
                case 9:
                    wages = new[] { 8, 9, 2, 3, 4, 5, 6, 7 };

                    for (int i = 0; i < 8; i++)
                    {
                        controlNumberFromRegon += int.Parse(regon[i].ToString()) * wages[i];
                    }

                    controlNumber = controlNumberFromRegon % 11;

                    if (controlNumber == 10)
                    {
                        controlNumber = 0;
                    }

                    return controlNumber.ToString() == regon[8].ToString();
                case 14:
                    wages = new[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };

                    for (int i = 0; i < 13; i++)
                    {
                        controlNumberFromRegon += int.Parse(regon[i].ToString()) * wages[i];
                    }

                    controlNumber = controlNumberFromRegon % 11;

                    return controlNumber.ToString() == regon[13].ToString();
                default:
                    return false;
            }
        }

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
