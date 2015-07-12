using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class DownloadAllFreeEboks :IStudyTest
    {
        const string PATH = @".\MSFTEbooks2.txt";

        bool ccomplete = true;

        public void Study()
        {
            if (!File.Exists(PATH))
            {
                throw new Exception(string.Format("Brak pliku w katalogu {0}", PATH));
            }

            using (var sr = new StreamReader(PATH))
            {
                var line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("http"))
                    {
                        continue;
                    }

                    using (WebClient wc = new WebClient())
                    {
                        ccomplete = false;
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                        wc.DownloadFileAsync(new Uri(line), Path.GetRandomFileName() + ".pdf");
                    }
                    while (!ccomplete)
                    {

                    }
                }
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.Clear();
            ccomplete = true;
            Console.Write("Plik ściągnięty");
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Clear();
            
            Console.Write("{0}/{1}",e.BytesReceived,e.TotalBytesToReceive);
        }
    }
}
