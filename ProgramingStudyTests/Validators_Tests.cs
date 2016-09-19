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
        [Theory]
        [InlineData("00281802650")]
        public void IsValidPesel(string pesel)
        {
            Assert.True(Validator.IsPeselValid(pesel));
        }

        [Theory]
        [InlineData("930041341")]
        [InlineData("141387142")]
        [InlineData("839072903")]
        [InlineData("210466948")]
        [InlineData("23511332857188")]
        public void IsValidRegon(string regon)
        {
            Assert.True(Validator.IsValidRegon(regon));
        }


        [Theory]
        [InlineData("")]
        [InlineData("123")]
        [InlineData("1234567890")]
        [InlineData(null)]
        public void IsNotValidRegon(string regon)
        {
            Assert.False(Validator.IsValidRegon(regon));
        }

        [Theory]
        [InlineData(" 527-26-38-392")]
        [InlineData("1070010731")]
        [InlineData("896 000 56 73")]
        [InlineData("123-456-32-18")]
        public void ValidNip(string nip)
        {
            Assert.True(Validator.IsValidNip(nip));
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("6577654567")]
        [InlineData("1535658590")]
        [InlineData("1234567890")]
        public void IsNotValidNip(string nip)
        {
            Assert.False(Validator.IsValidNip(nip));
        }
    }
}
