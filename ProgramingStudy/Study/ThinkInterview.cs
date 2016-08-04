using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Impl.CustomizersImpl;

namespace ProgramingStudy.Study
{
    class ThinkInterview : IStudyTest
    {
        public void Study()
        {
            var listIn = new[] {2.0, 1.0, 3.0};
            var listOut = new[] {3.0, 6.0, 2.0};

           var list =  this.GetList2(listIn.ToList());
            ;
        }



        private IEnumerable<double> GetList2(List<double> list)
        {
            double temp = list.Aggregate<double, double>(1, (current, d) => current*d);

            return list.Select(d => temp/d).ToList();
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

                double iloczyn = tempList.Aggregate<double, double>(1, (current, f) => current*f);

                result.Add(iloczyn);
            }

            return result;
        }
    }
}
