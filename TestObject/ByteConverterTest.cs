using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramingStudy.Study;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObject
{
    [TestClass]
    public class ByteConverterTest
    {
        [TestMethod]
        public void ByteConverterUsingFile()
        {
            string text = "Tajny Tekst";

            string fileName = Path.GetRandomFileName();

            var encoding = new UnicodeEncoding();

            File.WriteAllBytes(fileName, encoding.GetBytes(text));

            var result = encoding.GetString(File.ReadAllBytes(fileName));

            Assert.AreEqual(text, result);

            File.Delete(fileName);
        }

        [TestMethod]
        public void ByteConverterUsingHardWay()
        {
            string text = "Przemek Walkowski";

            string fileName = Path.GetRandomFileName();

            var encoding = new UnicodeEncoding();

            File.WriteAllBytes(fileName, encoding.GetBytes(text));

            var byteConverter = new ByteConverter();

            var result = encoding.GetString(byteConverter.GetByteFromFile(fileName));

            Assert.AreEqual(text, result);

            File.Delete(fileName);

        }

    }
}
