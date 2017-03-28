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
            this.SendFile();
        }


        private void SendFile()
        {
            var connectionInfo = new ConnectionInfo("127.0.0.1",22, "tester",
                                         new PasswordAuthenticationMethod("tester", "password"),
                                         new PrivateKeyAuthenticationMethod("rsa.key"));
            using (var client = new SftpClient(connectionInfo))
            {
                client.Connect();

                var ftpDir = $"CatalogueExports/{DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}";

                if (!client.Exists(ftpDir))
                {
                    client.CreateDirectory("CatalogueExports");

                    client.CreateDirectory(ftpDir);
                }


                var directory = client.ListDirectory(ftpDir);

                var dir = Directory.CreateDirectory("Test");

                using (var sw = new StreamWriter("Test/test2.txt"))
                {
                    sw.WriteLine(DateTime.Now);
                }


                File.Delete("file.zip");

                ZipFile.CreateFromDirectory(dir.FullName, "file.zip",CompressionLevel.Optimal, false);


                var sr = new FileStream("file.zip", FileMode.Open);

                

               

                var path = Path.Combine(ftpDir, "file.zip");

                client.UploadFile(sr,path, null);

                sr.Close();

            }


        }

    }
}
