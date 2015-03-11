using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ProgramingStudy.Study;
using ProgramingStudy.Exercism;

namespace TestObject
{
   [TestClass]
    public class LeapTest
    {
          [TestMethod]
        public void Valid_leap_year()
        {
            Assert.AreEqual(Year.IsLeap(1996), true);
        }


         [TestMethod]
        public void Invalid_leap_year()
        {
            Assert.AreEqual(Year.IsLeap(1997), false);
        }


       [TestMethod]
        public void Turn_of_the_20th_century_is_not_a_leap_year()
        {
            Assert.AreEqual(Year.IsLeap(1900), false);
        }


         [TestMethod]
        public void Turn_of_the_25th_century_is_a_leap_year()
        {
            Assert.AreEqual(Year.IsLeap(2400), true);
        }
    }
}