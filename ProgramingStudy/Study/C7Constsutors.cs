using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{

    public class Test3 : IStudyTest
    {
        public void Study()
        {
           
        }
    }

    public class Location
    {
        private string locationName;

        public Location(string name) => LocationName = name;

       
        public string LocationName { get => locationName; set => locationName = value; }
    }
}
