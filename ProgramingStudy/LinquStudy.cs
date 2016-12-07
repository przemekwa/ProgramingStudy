namespace ProgramingStudy
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinquStudy : IStudyTest
    {
        public void Study()
        {
             this.LinquAggregate();

           IList<int> d = new List<int>();

        }

        public void LinquAggregate()
        {
            var list = new List<string>() {"S1", "S2", "S3"};

            var result = list.Aggregate((x, y) =>
            {

                var temp = x + "-" + y;

                return temp;
            });

            list = new List<string>() { "S1" };

            result = list.Aggregate((x, y) => x + "-" + y);

            list = new List<string>() { };

            result = list.Aggregate((x, y) => x + "-" + y);
        }
    }
}