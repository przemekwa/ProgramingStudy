using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class BCCTests : IStudyTest
    {
        public void Study()
        {
            var s = "5cb76897-f949-4697-9918-495cdc9612c6:97902597:,4fac27a1-8e97-4755-adaf-fcc213b3efdb:97902597:,5cb76897-f949-4697-9918-495cdc9612c6:97898720:,4fac27a1-8e97-4755-adaf-fcc213b3efdb:97898720:";
            this.CommaStringToCatalogue_Article_Pairs(s);
        }

        public List<Tuple<Guid, KeyValuePair<Guid, int>>> CommaStringToCatalogue_Article_Pairs(string s)
        {
            if (string.IsNullOrEmpty(s))
                return new List<Tuple<Guid, KeyValuePair<Guid, int>>>();

            try
            {
                foreach (var colonPair in s.Split(','))
                {
                    var guid = colonPair.Split(':').Skip(2).First();
                }

                return  (from colonPair in s.Split(',')
                 select
                 new Tuple<Guid, KeyValuePair<Guid, int>>(new Guid(colonPair.Split(':').Skip(2).First()),
                     new KeyValuePair<Guid, int>(new Guid(colonPair.Split(':').First()),
                         int.Parse(colonPair.Split(':').Skip(1).First())))
                ).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("invalid string format during conversion", e);
            }
        }
    }
}
