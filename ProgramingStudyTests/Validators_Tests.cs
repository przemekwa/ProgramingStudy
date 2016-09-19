using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingStudy.Study;
using Xunit;

namespace ProgramingStudyTests
{
    public class Validators_Tests
    {
        [Fact]
        public void Pesel_Validator_Test()
        {
            Assert.True(Validator.IsPeselValid("00281802650"));
        }
    }
}
