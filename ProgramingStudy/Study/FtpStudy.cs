using FluentFTP;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class FtpStudy : IStudyTest
    {
        public void Study()
        {
            var dir = Directory.CreateDirectory("Test");

            using (var sw = new StreamWriter("Test/test2.txt"))
            {
                sw.WriteLine(DateTime.Now);
            }

            File.Delete("file.zip");

            ZipFile.CreateFromDirectory(dir.FullName, "file.zip", CompressionLevel.Optimal, false);
            
            this.SendFile3(new FileInfo("file.zip"));
        }


        public void SendFile3(FileInfo fileinfo)
        {
            FtpClient client = new FtpClient();

            client.Host = "ftp.zoom.pl";
            client.Credentials = new NetworkCredential("s3lgros", "");

            client.Connect();

            var rootDir = "SelgrosCatalogueExportsTests";


            client.UploadFile(fileinfo.FullName, Path.Combine(rootDir, fileinfo.Name), true, true, false);

            client.Disconnect();

        }

        public void SendFile2(FileInfo fileInfo)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("http://ftp.zoom.pl");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            
            request.Credentials = new NetworkCredential("s3lgros", "");

           
            StreamReader sourceStream = new StreamReader(fileInfo.FullName);

            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());

            sourceStream.Close();

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();

            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }

        public void SendFile(FileInfo fileInfo)
        {
            var connectionInfo = new ConnectionInfo("ftp.zoom.pl",21,"s3lgros",new NoneAuthenticationMethod("s3lgros") );

            using (var client = new SftpClient(connectionInfo))
            {
                
                
                client.Connect();

                var rootDir = "SelgrosCatalogueExportsTests";
                var exportDir = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

                string ftpDir = Path.Combine(rootDir, exportDir);

                if (!client.Exists(ftpDir))
                {
                    client.CreateDirectory(rootDir);

                    client.CreateDirectory(ftpDir);
                }

                using (var fs = new FileStream(fileInfo.FullName, FileMode.Open))
                {
                    client.UploadFile(fs, Path.Combine(ftpDir, fileInfo.Name), null);
                }
            }
        }
    }
}
