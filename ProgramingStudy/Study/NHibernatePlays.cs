using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace ProgramingStudy.Study
{
    public class NHibernatePlays : IStudyTest
    {
        public void Study()
        {

            
            var g = new Random();

            g.Next(

            )


            var mapper = new NHibernate.Mapping.ByCode.ModelMapper();

            mapper.AddMapping(typeof(NHbiernateTableDtoMapping));

            var cfg = new Configuration();

            cfg.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            var sessionFactory = cfg.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                var list = session.QueryOver<NHbiernateTableDto>().List();
            }
        }
    }
}
