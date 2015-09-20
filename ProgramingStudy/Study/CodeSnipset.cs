using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                          

namespace ProgramingStudy.Study
{
   class MyClass
	{
public MyViewIterator MyView
        {
            get
            {
                return new MyViewIterator(this);
            }
        }

        public class MyViewIterator
        {
            readonly MyClass outer;

            internal MyViewIterator(MyClass outer)
            {
                this.outer = outer;
            }

            // TODO: provide an appropriate implementation here
            public int Length { get { return 1; } }

            public ElementType this[int index]
            {
                get
                {
                    //
                    // TODO: implement indexer here
                    //
                    // you have full access to MyClass privates
                    //
                    throw new NotImplementedException();
                    return default(ElementType);
                }
            }

            public System.Collections.Generic.IEnumerator<ElementType> GetEnumerator()
            {
                for (int i = 0; i < this.Length; i++)
                {				 
                    yield return this[i];
                }
            }
        }
	
	}
       
}
