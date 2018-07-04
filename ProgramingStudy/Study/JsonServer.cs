using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class JsonServer : IStudyTest
    {
        public void Study()
        {
            var restClient = new RestClient("http://localhost:3000");

            var req = new RestRequest("/posts");

            req.Method = Method.POST;

            var content = JsonConvert.SerializeObject(new
            {
                title = "Nowy",
                author = "Jendrzej",
                bleble = "działa"
            });

            req.AddHeader("Content-type", "application/json");
            req.AddParameter("application/json", content, ParameterType.RequestBody);
          




            var res = restClient.Execute(req);

            Console.WriteLine(res.Content);




        }
    }
}
