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
            
            this.SendFile(new FileInfo("file.zip"));
        }


        private void SendFile(FileInfo fileInfo)
        {
            var connectionInfo = new ConnectionInfo("127.0.0.1",22, "tester",
                                         new PasswordAuthenticationMethod("tester", "password"),
                                         new PrivateKeyAuthenticationMethod("rsa.key"));

            using (var client = new SftpClient(connectionInfo))
            {
                
                client.Connect();

                var rootDir = "CatalogueExports";
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
