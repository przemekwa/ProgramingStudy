using System;
using System.Drawing;

namespace ProgramingStudy.Study.C7
{
    internal unsafe struct S
    {
        public fixed int myFixedField[10];
    }

    internal struct VeryLargeStruct
    {

    }
  


    public unsafe class FixedType
    {
        public Point[] Points { get; set; } 

        public ref Point GetPinnableReference()
        {
            return ref Points[1];
        }
    }


    public class C73Features : IStudyTest
    {

        public int  MyProperty;


        private S s = new S();

        public void Study()
        {
            FixedPoint();
            NewRefAssigment();
            StackallocArrya();
            AssertTuple();

        }

        private void AssertTuple()
        {
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);

            Console.WriteLine(left == right); // 'true'


            var left1 = (a: 5, b: 10);
            var right1 = (a: 5, b: 10);

            (int a, int b)? nullableTuple = right1;
            Console.WriteLine(left1 == nullableTuple); // 'true'

            // lifted conversions
            var left2 = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left2 == nullableMembers); // 'true'

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left2 == longTuple); // 'true'

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // 'true'


            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Console.WriteLine(pair == another); // 'true'
            Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal contains different member names


            (int, (int, int)) nestedTuple = (1, (2, 3));
            Console.WriteLine(nestedTuple == (1, (2, 3)) );
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

        private unsafe void FixedAnyType(FixedType ft)
        {
            fixed (Point* d = ft )
            {
                
            }
        }

    }
}
