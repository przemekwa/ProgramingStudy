using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.LiteDB
{
    class LiteDBStudy : IStudyTest
    {
        public void Study()
        {
            var e = new TestObject
            {
                Name = "Przemek",
                Age = 18
            };

            var r = new LocalRepository<TestObject>();

            r.Add(e);

            var all = r.GetAll();

            var test = all.First();





           
        }
    }
}
