﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{

    [Execute(DateTime ="25-09-2019 18:46")]
    public class DownloadAllFreeEboks :IStudyTest
    {
        const string PATHWITHBOOKS = @".\MSFTEbooks2.txt";

        IList<string> showBuffor = new List<string>();
        IList<string> progressBuffor = new List<string> { "" };

        bool ccomplete = true;
        string fileName = string.Empty;

        public void Study()
        {
                
            var showTask = new Task(() =>
            {

                for (;;)
                {
                    Thread.Sleep(500);
                    Console.Clear();
                
                    foreach (var s in showBuffor)
                    {
                        Console.WriteLine(s);
                    }

                    foreach (var s in progressBuffor)
                    {
                        Console.WriteLine(s);
                    }
                }
            });

            showTask.Start();

            string PATH = "";

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
                        ccomplete = true;
                     
                        wc.DownloadProgressChanged += wc_DownloadProgressChanged;

                        wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                        fileName = line.Substring(line.LastIndexOf('/')+1) + ".pdf";

                        wc.DownloadFileAsync(new Uri(line), fileName);

                        while (ccomplete) { }
                    }
                }
            }
        }

        void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            showBuffor.Add(string.Format("Ściągnięto plik {0}", fileName));
            
            ccomplete = false;
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBuffor[0] = string.Format("Ściągam plik {0} - {1}%",fileName,e.ProgressPercentage.ToString());
        }
              
    }
}
