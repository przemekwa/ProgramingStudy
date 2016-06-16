using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace ProgramingStudy.Study
{
    class NHbiernateTableDtoMapping : ClassMapping<NHbiernateTableDto>
    {
        public NHbiernateTableDtoMapping()
        {
            base.Id(x => x.Id, map =>
              {
                  map.Column("Serno");
                  map.Generator(Generators.Native);
                  map.UnsavedValue(0);
              });

            base.Property(x => x.Name, map =>
              {
                  map.Column("Name");
              });
        }
    }
}
