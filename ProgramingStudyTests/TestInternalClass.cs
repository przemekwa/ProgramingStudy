using ProgramingStudy.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProgramingStudyTests
{
    
    public class TestInternalClass
    {
        [Fact]
        public void InternalClass()
        {
            var testClass = new TestInternals();

            Assert.Equal("ok", testClass.TestInternalMethod());

        }

    }
}
