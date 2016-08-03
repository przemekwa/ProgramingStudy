using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class ThinkInterview : IStudyTest
    {
        public void Study()
        {
            var listIn = new[] {2.0, 1.0, 3.0};
            var listOut = new[] {3.0, 6.0, 2.0};

            this.GetList(listIn.ToList());
        }


        private IEnumerable<double> GetList(List<double> list)
        {
            var result=  new List<double>();

            for (int i = 0; i < list.Count  ; i++)
            {
                var tempList = new List<double>(list)
                {
                    [i] = 1
                };

                double iloczyn = 1;

                foreach (var f in tempList)
                {
                    iloczyn *= f;
                }

                result.Add(iloczyn);
            }

            return result;
        }
    }
}
