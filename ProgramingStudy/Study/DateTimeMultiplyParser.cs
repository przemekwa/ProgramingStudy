using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class DateTimeMultiplyParser : IStudyTest
    {
        public void Study()
        {
            DataGodzinaParser();
        }

        public void DataGodzinaParser()
        {
            //string data = " 12/09/2013 12:00:23";
            string data = " 12-09-2013 12:00:23";

            string dzien = "";
            string miesiac = "";

            string rok = "";
            string godziny = "";
            string minuty = "";
            string sekundy = "";


            data = data.Trim();
            string[] spacje = data.Split(' ');

            if (spacje.Length >= 1)
            {
                Char rozdzielacz = Char.Parse(spacje[0].Substring(2, 1));

                string[] data4 = spacje[0].Split(rozdzielacz);

                if (data4.Length == 3)
                {
                    if (data4[0].Length == 2)
                    {
                        dzien = data4[0];
                    }
                    else if (data4[0].Length == 1)
                    {
                        dzien = "0" + data4[0];
                    }


                    if (data4[1].Length == 2)
                    {
                        miesiac = data4[1];
                    }
                    else if (data4[1].Length == 1)
                    {
                        miesiac = "0" + data4[1];
                    }

                    if (data4[2].Length == 4)
                    {
                        rok = data4[2];
                    }


                    Char rozdzielaczgodzina = new char();

                    if (spacje[1].Length == 7)
                    {
                        rozdzielaczgodzina = Char.Parse(spacje[1].Substring(1, 1));
                    }
                    else
                    {
                        rozdzielaczgodzina = Char.Parse(spacje[1].Substring(2, 1));
                    }



                    string[] godzina4 = spacje[1].Split(rozdzielaczgodzina);



                    if (godzina4.Length == 3)
                    {

                        if (godzina4[0].Length == 2)
                        {
                            godziny = godzina4[0];
                        }
                        else if (godzina4[0].Length == 1)
                        {
                            godziny = "0" + godzina4[0];
                        }


                        if (godzina4[1].Length == 2)
                        {
                            minuty = godzina4[1];
                        }
                        else if (godzina4[1].Length == 1)
                        {
                            minuty = "0" + godzina4[1];
                        }

                        if (godzina4[2].Length == 2)
                        {
                            sekundy = godzina4[2];
                        }
                        else if (godzina4[2].Length == 1)
                        {
                            sekundy = "0" + godzina4[2];
                        }
                    }

                }

            }

            var dateTime = new DateTime(Int32.Parse(rok), Int32.Parse(dzien), Int32.Parse(miesiac),
                Int32.Parse(godziny), Int32.Parse(minuty), Int32.Parse(sekundy));

            Console.WriteLine(dateTime.ToLongDateString());
        }

        public DateTime GetDateTime2(string data)
        {
            string dzien = string.Empty;
            string miesiac = string.Empty;

            string rok = string.Empty;
            string godziny = "00";
            string minuty = "00";
            string sekundy = "00";

            data = data.Trim();
            string[] spacje = data.Split(' ');

            if (Regex.IsMatch(data, "[A-Za-z]+"))
            {
                return new DateTime();
            }

            if (spacje.Length >= 1)
            {
                var rozdzielacz = char.Parse(spacje[0].Substring(2, 1));

                string[] data4 = spacje[0].Split(rozdzielacz);

                if (data4.Length == 3)
                {
                    if (data4[0].Length == 2)
                    {
                        dzien = data4[0];
                    }
                    else if (data4[0].Length == 1)
                    {
                        dzien = "0" + data4[0];
                    }

                    if (data4[1].Length == 2)
                    {
                        miesiac = data4[1];
                    }
                    else if (data4[1].Length == 1)
                    {
                        miesiac = "0" + data4[1];
                    }

                    if (data4[2].Length == 4)
                    {
                        rok = data4[2];
                    }

                    if (spacje.Length == 2)
                    {
                        char rozdzielaczgodzina;

                        if (spacje[1].Length == 7)
                        {
                            rozdzielaczgodzina = char.Parse(spacje[1].Substring(1, 1));
                        }
                        else
                        {
                            rozdzielaczgodzina = char.Parse(spacje[1].Substring(2, 1));
                        }

                        string[] godzina4 = spacje[1].Split(rozdzielaczgodzina);

                        if (godzina4.Length == 3)
                        {
                            if (godzina4[0].Length == 2)
                            {
                                godziny = godzina4[0];
                            }
                            else if (godzina4[0].Length == 1)
                            {
                                godziny = "0" + godzina4[0];
                            }

                            if (godzina4[1].Length == 2)
                            {
                                minuty = godzina4[1];
                            }
                            else if (godzina4[1].Length == 1)
                            {
                                minuty = "0" + godzina4[1];
                            }

                            if (godzina4[2].Length == 2)
                            {
                                sekundy = godzina4[2];
                            }
                            else if (godzina4[2].Length == 1)
                            {
                                sekundy = "0" + godzina4[2];
                            }
                        }
                    }
                }
            }

            return new DateTime(int.Parse(rok), int.Parse(miesiac), int.Parse(dzien), int.Parse(godziny), int.Parse(minuty), int.Parse(sekundy));
        }

        
    }
}
