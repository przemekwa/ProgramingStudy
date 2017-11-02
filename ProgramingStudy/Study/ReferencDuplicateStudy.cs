using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Serializable]
    class A
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }


    class ReferencDuplicateStudy : IStudyTest
    {
        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

        public void Study()
        {

            var first = new A
            {
                Number = 21,
                Name = "Ala ma kota"
            };


            var second = new A
            {
                Name = "Grześ ma banana",
                Number = 13214
            };


            first = DeepCopy<A>(second);

            first.Name = "test";


            ;



        }
    }
}
