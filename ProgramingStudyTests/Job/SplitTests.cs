using ProgramingStudy.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProgramingStudyTests.Job
{
    public class SplitTests
    {
        [Fact]
        public void SplitTest1()
        {
            var list = Enumerable.Repeat("test", 5000).ToList();

            var result = list.Split<string>(2099).ToList();

            Assert.Equal(3, result.Count);

            Assert.Equal(result.First().Count(), 2099);
            Assert.Equal(result.Skip(1).First().Count(), 2099);
            Assert.Equal(result.Skip(2).First().Count(), 5000-2099-2099);


        }

        [Fact]
        public void SplitTest2()
        {
            var list = Enumerable.Repeat("test", 5000).ToArray();

            var result = list.Split<string>(2099).ToList();

            Assert.Equal(3, result.Count);

            Assert.Equal(result.First().Count(), 2099);
            Assert.Equal(result.Skip(1).First().Count(), 2099);
            Assert.Equal(result.Skip(2).First().Count(), 5000 - 2099 - 2099);


        }

        [Fact]
        public void SplitTest3()
        {
            var list = Enumerable.Repeat("test", 0).ToArray();

            var result = list.Split<string>(2099).ToList();


            Assert.Equal(1, result.Count);

            Assert.Equal(result.First().Count(), 0);







        }
    }
}
