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
        public TestObject TestObject2 { get; set; }
    }

    public class Serialization : IStudyTest
    {

       

        public void Study()
        {
            var testobj = new TestObject
            {
                StringValue = "Przemek",
                IntValue = 32,
                DateTimeValue = DateTime.Now,
                TestObject2 = new TestObject
                {
                    StringValue = "Jola"
                }
            };

            var result = "";

            byte[] bufferOrginal;

            using (var ms = new MemoryStream())
            {
                var xmls = new XmlSerializer(typeof(TestObject));

                xmls.Serialize(ms, testobj);

                bufferOrginal = ms.ToArray();

                result = Encoding.UTF8.GetString(bufferOrginal);
            }

            var dexml = new XmlSerializer(typeof(TestObject));

            using (var ms = new MemoryStream())
            {
                var buffer = Encoding.UTF8.GetBytes(result);

                ms.Write(buffer, 0, buffer.Length);

                ms.Position = 0;

                var objectResult = (TestObject)dexml.Deserialize(ms);
            }
        }
    }
}
