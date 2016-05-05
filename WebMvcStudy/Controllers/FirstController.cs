using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcStudy.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            var listOfEditableFields = new List<string>
            {
                "#DATAOD#",
                "#DATADO#",
                "#MASK#",
                "#RACH#"
            };

            var dictModel = new DictionaryCreator(listOfEditableFields);

            //Więcej informacji na
            //http://www.hanselman.com/blog/ASPNETWireFormatForModelBindingToArraysListsCollectionsDictionaries.aspx
            //

            return View(dictModel.GetEditableFields());
        }

        public ActionResult SecondAction(IDictionary<string,EditField> lista)
        {
            return View(lista);
        }
    }
}