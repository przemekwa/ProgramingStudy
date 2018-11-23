using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingStudy.Study;
using ProgramingStudy.Study.Kata;
using Xunit;

namespace ProgramingStudyTests
{
    public class C22
    {
        private protected int Test2 {get;set;}
    }

    public class KataTests
    {
        [Fact]
        public void Kata_Binary_Chop_Test()
        {
            var binaryChop = new BinaryChop();

            Assert.Equal(4, binaryChop.Chop(5, new[] { 1, 2, 3, 4, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(3, new int[0]));
            Assert.Equal(-1, binaryChop.Chop(3, new[] { 1 }));
            Assert.Equal(0, binaryChop.Chop(1, new[] { 1 }));
            Assert.Equal(0, binaryChop.Chop(1, new[] { 1, 3, 5 }));
            Assert.Equal(1, binaryChop.Chop(3, new[] { 1, 3, 5 }));
            Assert.Equal(2, binaryChop.Chop(5, new[] { 1, 3, 5 }));
            Assert.Equal(-1, binaryChop.Chop(0, new[] { 1, 3, 5 }));
            Assert.Equal(-1, binaryChop.Chop(2, new[] { 1, 3, 5 }));
            Assert.Equal(-1, binaryChop.Chop(4, new[] { 1, 3, 5 }));
            Assert.Equal(-1, binaryChop.Chop(6, new[] { 1, 3, 5 }));
            Assert.Equal(0, binaryChop.Chop(1, new[] { 1, 3, 5, 7 }));
            Assert.Equal(1, binaryChop.Chop(3, new[] { 1, 3, 5, 7 }));
            Assert.Equal(3, binaryChop.Chop(7, new[] { 1, 3, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(0, new[] { 1, 3, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(2, new[] { 1, 3, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(4, new[] { 1, 3, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(6, new[] { 1, 3, 5, 7 }));
            Assert.Equal(-1, binaryChop.Chop(8, new[] { 1, 3, 5, 7 }));
        }
    }
}
