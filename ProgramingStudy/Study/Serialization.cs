using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProgramingStudy.Study
{
    [Serializable]
    public class TestObject
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
    }

    public class Serialization : IStudyTest
    {

       

        public void Study()
        {
            var testobj = new TestObject
            {
                StringValue = "Przemek",
                IntValue = 32,
                DateTimeValue = DateTime.Now
            };

            var result = "";

            byte[] bufferOrginal;

            using (var ms = new MemoryStream())
            {
                var xmls = new XmlSerializer(typeof(TestObject));

                xmls.Serialize(ms, testobj);

                bufferOrginal = ms.GetBuffer();

                result = Encoding.UTF8.GetString(bufferOrginal);
            }

            var dexml = new XmlSerializer(typeof(TestObject));

            using (var ms = new MemoryStream())
            {
                var byteArray = new byte[result.Length];

                Encoding.UTF8.GetBytes(result, 0, result.Length, byteArray, 0);


                ms.Write(byteArray,0,byteArray.Length);

                var objectResult = (TestObject)dexml.Deserialize(ms);
            }
        }
    }
}
