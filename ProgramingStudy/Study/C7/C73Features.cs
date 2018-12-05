namespace ProgramingStudy.Study.C7
{
    internal unsafe struct S
    {
        public fixed int myFixedField[10];
    }

    internal struct VeryLargeStruct
    {

    }


    public class C73Features : IStudyTest
    {
        private S s = new S();

        public void Study()
        {
            FixedPoint();
            NewRefAssigment();
            StackallocArrya();

        }

        private unsafe void StackallocArrya()
        {
            int* pArr = stackalloc int[3] { 1, 2, 3 };
            int* pArr2 = stackalloc int[] { 1, 2, 3 };
            //Span<int> arr = stackalloc[] { 1, 2, 3 };
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
                int p_old = ptr[5];
            }

            // after C# 7.3

            int p_new = s.myFixedField[5];

        }
    }
}
