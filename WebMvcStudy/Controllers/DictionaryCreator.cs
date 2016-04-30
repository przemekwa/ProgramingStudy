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

        //private Dictionary<string,string> SymbolDictionary = new Dictionary<string, string>
        //{
        //    {"#DATAOD", "Data od" }
        //}

        public DictionaryCreator(IEnumerable<string> listOfFields)
        {
            this.listOfFields = listOfFields;
        }

        public IDictionary<string,EditField> GetEditableFields()
        {
            var result = new Dictionary<string, EditField>();

            foreach (var field in this.listOfFields)
            {
                switch (field)
                {
                    case "#DATAOD#":
                        result.Add("Data od", new EditField { Type = "date", Symbol =field } );
                        
                        break;
                    case "#DATADO#":
                        result.Add("Data do", new EditField { Type = "date", Symbol = field });
                        break;
                    case "#MASK#":
                        result.Add("Numer maskowany karty", new EditField { Type = "text", Symbol = field });
                        break;
                    case "#RACH#":
                        result.Add("Numer rachunku", new EditField { Type = "text", Symbol = field });
                        break;
                }
            }

            return result;
        }
    }
}