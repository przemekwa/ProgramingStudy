using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.C7
{
    unsafe struct S
    {
        public fixed int myFixedField[10];
    }

    struct VeryLargeStruct
    {

    }

    
    public class C73Features : IStudyTest
    {
        private S s = new S();

        public void Study()
        {
            FixedPoint();
            NewRefAssigment();
        }

        private void NewRefAssigment()
        {
            //ref VeryLargeStruct refLocal = ref veryLargeStruct; // initialization
            //refLocal = ref anotherVeryLargeStruct; // reassigned, refLocal refers to different storage.
        }

        private unsafe void FixedPoint()
        {
            // before C# 7.3
            fixed (int* ptr = s.myFixedField)
            {
                int p_old= ptr[5];
            }

            // after C# 7.3

            int p_new = s.myFixedField[5];
            
        }
    }
}
