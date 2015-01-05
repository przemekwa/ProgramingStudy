using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramingStudy.Study;

namespace ProgramingStudyTests
{
    [TestClass]
    public class StudyList
    {
        [TestMethod]
        public void CreateList()
        {
            Assert.AreEqual(listTest.IntegerList, "");

        }
    }
}
