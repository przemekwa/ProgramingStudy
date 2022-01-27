using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgramningStudyDotNet
{
    [Execute(DateTime = "26-01-2022 08:36")]
    public class SO1 : IStudyTest
    {
        public void Study()
        {
            Console.Write("Hello");

            var json = "";
            
            var model = GetJsonModel(json);

            var folderName = GetName(model.data, 19006); 

        }

        private string GetName(Data data, int searchValue)
        {
            var folderName = data.name;

            if (data.childComponents.Any(s=>s.id == searchValue)) 
            {
                return folderName;
            }


            if (data.childFolders.Length > 0)
            {
                foreach (var item in data.childFolders)
                {
                    var folderName1 = GetName(item, searchValue);

                    if (folderName1 != null)
                    {
                        return folderName1;
                    }
                }
            }

            return null;
        }

        private YourJson GetJsonModel(string model)
        {
            var test = "{ 	\"data\": { 		\"id\": 0, 		\"name\": \"\", 		\"childFolders\": [ 			{ 				\"id\": 19002, 				\"name\": \"Locker\", 				\"childFolders\": [ 					{ 						\"id\": 19003, 						\"name\": \"Folder1\", 						\"childFolders\": [], 						\"childComponents\": [ 							{ 								\"id\": 19005, 								\"name\": \"route1\", 								\"state\": \"STOPPED\", 								\"type\": \"ROUTE\" 							} 						] 					}, 					{ 						\"id\": 19004, 						\"name\": \"Folder2\", 						\"childFolders\": [], 						\"childComponents\": [ 							{ 								\"id\": 19008, 								\"name\": \"comm1\", 								\"state\": \"STOPPED\", 								\"type\": \"COMMUNICATION_POINT\" 							}, 							{ 								\"id\": 19006, 								\"name\": \"route2\", 								\"state\": \"STOPPED\", 								\"type\": \"ROUTE\" 							}, 							{ 								\"id\": 19007, 								\"name\": \"route3\", 								\"state\": \"STOPPED\", 								\"type\": \"ROUTE\" 							} 						] 					} 				], 				\"childComponents\": [] 			} 		], 		\"childComponents\": [] 	}, 	\"error\": null }";

            return JsonSerializer.Deserialize<YourJson>(test);

        }
    }
}


public class YourJson
{
    public Data data { get; set; }
    public object error { get; set; }
}

public class Data
{
    public int id { get; set; }
    public string name { get; set; }
    public Data[] childFolders { get; set; }
    public Childcomponent[] childComponents { get; set; }
}

public class Childcomponent
{
    public int id { get; set; }
    public string name { get; set; }
    public string state { get; set; }
    public string type { get; set; }
}


