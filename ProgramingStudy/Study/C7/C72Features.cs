
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class A1 : B1
    {
        public A1()
        {
           base.Test();
        }
    }


    public class B1
    {
        private protected void Test()
        {

        }
    }

    public class C72Features : IStudyTest
    {
        public void Study()
        {
            OptionalArguments();
            NumericLiterals();
        }

        private void NumericLiterals()
        {
            const int Sixteen =   0b_0001_0000;
            
            const int ThirtyTwo = 0b_0010_0000;
            
            const int SixtyFour = 0b_0100_0000;

            const int One =  0b_0001;

            const int Two =  0b_0010;
            
            const int Four = 0b_0100;
        }

        private void OptionalArguments()
        {
            // C # 7.2

            TestFunc(a: 2, "b", c: new Point());
        }

        private void TestFunc(int a, string b, Point? c = null)
        {

        }
    }
}
