using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class JsonWithHtml : IStudyTest
    {
        public class TestJson
        {
            public int Id { get; set; }
            public string Html { get; set; }
        }

        public void Study()
        {
            RawJson();
            ConverToJson();
        }

        private void ConverToJson()
        {
           var tj = new TestJson
           {
               Id =1,
               Html = GetHtml()
           };

             string json = JsonConvert.SerializeObject(tj);
             var json2 = JsonConvert.DeserializeObject<TestJson>(GetJsonString());
       
        }

        private void RawJson()
        {
            var rawHtml = GetHtml(); // <div class="ad_box"><img class="banner" src="some_ad.png" alt="" />"

            rawHtml = rawHtml.Replace("\"","\\\""); // replace " for \"

            rawHtml = rawHtml.Replace("</","<\\/");

            
        }

        private string GetJsonString() => "{\"Id\":1,\"Html\":\"<div class=\\\"ad_box\\\"><img class=\\\"banner\\\" src=\\\"some_ad.png\\\" alt=\\\"\\\" />\"}";

        private string GetHtml()
        =>
           "<div class=\"ad_box\"><img class=\"banner\" src=\"some_ad.png\" alt=\"\" />";
        
    }
}
