using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class ZipTest : IStudyTest
    {
        public void Study()
        {


            using (Stream fileStream = File.OpenRead(@"test.gz"))
            {
                var zippedStream = new GZipStream(fileStream, CompressionMode.Decompress);


                using (StreamReader sr = new StreamReader(zippedStream))
                {
                    var line = sr.ReadLine();


                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                }
            }






            //using (FileStream zipToOpen = new FileStream(@"test.zip", FileMode.Open))
            //{
            //    using (var archive = new GZipStream ZipArchiveMode.Read))
            //    {
            //        ZipArchiveEntry readmeEntry = archive.GetEntry("Readme.txt");


            //        using (var sr = new StreamReader(readmeEntry.Open()))
            //        {
            //            var line = sr.ReadLine();


            //            while (line != null)
            //            {
            //                Console.WriteLine(line);
            //                line = sr.ReadLine();
            //            }
            //        }

            //        //using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
            //        //{
            //        //    writer.WriteLine("Information about this package.");
            //        //    writer.WriteLine("========================");
            //}
        }
    
        }
    
}
