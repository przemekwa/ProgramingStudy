using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.LanguageStudy
{

    class InMutable
    {
        public IEnumerable<int> List { get; private set; }

        public InMutable()
        {
            this.List = new List<int> {1, 2, 3};
        }
    }

    class DacInterview :IStudyTest
    {
        public void Study()
        {
          //this.NullModulo(null);
            this.IsNotInmutable();
        }

        private void IsNotInmutable()
        {
            /// Private set nie daje nie zmienności dla obiektu. Przykład poniżej. Do listy List, można dodawać elementy mimo, że metoda set jest prywatna.
            
            var test = new InMutable();

           (test.List as List<int>).Add(4);

            Console.WriteLine(test.List.Count()); // Lista ma 4 elementy

        }

        private void NullModulo(int? number)
        {
            //Czyli to nie prawda. Number nie jest konwertowany na zero. Tylko całość daje null.

             // int test = number%2;  błądd

            int? test = number%2;  // błądd
        }
    }
}
