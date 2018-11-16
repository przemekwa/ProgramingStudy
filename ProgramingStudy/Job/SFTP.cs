using FluentFTP;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class SFTP : IStudyTest
    {
        enum ddd
        {
            asd,
            gff,
                p
        }

        public List<Tuple<Guid, KeyValuePair<Guid, int>>> CommaStringToCatalogue_Article_Pairs(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new List<Tuple<Guid, KeyValuePair<Guid, int>>>();

            try
            {
                return
                (from colonPair in s.Split(',')
                    select
                    new Tuple<Guid, KeyValuePair<Guid, int>>(new Guid(colonPair.Split(':').Skip(2).First()),
                        new KeyValuePair<Guid, int>(new Guid(colonPair.Split(':').First()),
                            int.Parse(colonPair.Split(':').Skip(1).First())))
                ).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("invalid string format during conversion", e);
            }
        }


        public void Study()
        {
            List<int> list =null;

            var f = string.Join(",", list);


        }

        public void Study1()
        {
            FtpClient client = new FtpClient();
            client.Host = "Selgros24.pl";
            client.Port = 2231;

            client.Credentials = new NetworkCredential("pcb_data", "");
            client.Connect();


            client.UploadFile(@"D://test.snp-poland.txt", "/");
        }
    }
}
