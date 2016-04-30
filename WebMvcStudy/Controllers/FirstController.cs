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
            //Więcej informacji na
            //http://www.hanselman.com/blog/ASPNETWireFormatForModelBindingToArraysListsCollectionsDictionaries.aspx
            //

            var dictModel = new Dictionary<string, string>
            {
                { "Przemek","Walkowski" },
                { "Jola", "Grzybowska" }
            };

            return View(dictModel);
        }

        public ActionResult SecondAction(IDictionary<string,string> lista)
        {
            return View(lista);
        }
    }
}