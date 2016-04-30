using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcStudy.Controllers
{
    public class DictionaryCreator
    {
        private IEnumerable<string> listOfFields;

        public DictionaryCreator(IEnumerable<string> listOfFields)
        {
            this.listOfFields = listOfFields;
        }

        public IDictionary<string,string> GetEditableFields()
        {
            var result = new Dictionary<string, string>();

            foreach (var field in this.listOfFields)
            {
                switch (field)
                {
                    case "#DATAOD#":
                        result.Add("Data od", "date");
                        break;
                    case "#DATADO#":
                        result.Add("Data do", "date");
                        break;
                    case "#MASK#":
                        result.Add("Numer maskowany karty", "text");
                        break;
                    case "#RACH#":
                        result.Add("Numer rachunku", "text");
                        break;
                }
                           
            }

            return result;

        }

    }
}