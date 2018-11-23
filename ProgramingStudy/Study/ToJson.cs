using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class ToJson : IStudyTest
    {
        public class MyObj
        {
            [JsonProperty(PropertyName = "clinet")]
            public string Client { get; set; }

            [JsonProperty(PropertyName = "color")]
            public int Color { get; set; }
        }

        
        public void Study()
        {
          var obj  = new MyObj
          {

              Client = "Clinet",
              Color = 2
          };


           string  result = JsonConvert.SerializeObject(obj);
            

        }
    }
}
