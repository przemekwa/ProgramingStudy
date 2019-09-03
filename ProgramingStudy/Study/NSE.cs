using ProgramingStudy;
using ProgramingStudy.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{

    public class ListClass {

        

        private List<string> _list;

        public List<string> AList
    {
        get
        {
            if (_list == null)
                _list = new List<String>
                {
                    "Hello",
                    "World"
                };

            return _list;
        }


    }

        
            public bool IsValid
        {
            get
            {
                return _list != null;
            }
        }
}

}
    [Execute(DateTime ="03-09-2019 18:46")]
    public class NSE : IStudyTest
{
    public void Study()
    {
        var list = new ListClass();

        var result = list.IsValid;

    }
}

