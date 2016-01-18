using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramingStudy.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestObject
{
    [TestClass]
    public class ExtensionStringTest
    {
        [TestMethod]
        public void SplitWithCheckSeparatorTest()
        {
            const string testString = "Ala-Ma-\"2\"-Koty";

            var result = testString.SplitWithCheckSeparator('-', '"', false);

            Assert.AreEqual(result.Length, 4);

            Assert.AreEqual(result[0], "Ala");
            Assert.AreEqual(result[1], "Ma");
            Assert.AreEqual(result[2], "\"2\"");
            Assert.AreEqual(result[3], "Koty");
        }


        [TestMethod]
        public void Split_SplitWithCheckSeparatorTest()
        {
            const string testString = "Ala-Ma-2-Koty-";

            var resultSplit = testString.SplitWithCheckSeparator('-', '"', false);
            var resultSplitWithCheckSeparatort = testString.Split('-');

            Assert.AreEqual(resultSplit.Length, resultSplitWithCheckSeparatort.Length);

            Assert.AreEqual(resultSplit[0], resultSplitWithCheckSeparatort[0]);
            Assert.AreEqual(resultSplit[1], resultSplitWithCheckSeparatort[1]);
            Assert.AreEqual(resultSplit[2], resultSplitWithCheckSeparatort[2]);
            Assert.AreEqual(resultSplit[3], resultSplitWithCheckSeparatort[3]);
        }


        [TestMethod]
        public void SplitWithCheckSeparator_EraseCheckSeparatorTest()
        {
            const string testString = "Ala-Ma-\"2\"-Koty";

            var result = testString.SplitWithCheckSeparator('-', '"', true);

            Assert.AreEqual(result.Length, 4);

            Assert.AreEqual(result[0], "Ala");
            Assert.AreEqual(result[1], "Ma");
            Assert.AreEqual(result[2], "2");
            Assert.AreEqual(result[3], "Koty");
        }

    }
}
