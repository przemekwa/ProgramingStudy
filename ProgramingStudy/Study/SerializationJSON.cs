using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ProgramingStudy.Study
{
    public class SerializationJSON : IStudyTest
    {
        public void Study()
        {

            var testObj = new CreateInstalmentArgument();
            
            var result = "";

            result = JsonConvert.SerializeObject(testObj);

            var g = new JsonObjectAttribute("1");


            var @object = JsonConvert.DeserializeObject<CreateInstalmentArgument>(result);
        }
    }
}
