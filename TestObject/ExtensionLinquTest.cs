using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ProgramingStudy.Study;

namespace TestObject
{
    [TestClass]
    public class ExtensionLinquTest
    {
        [TestMethod]
        public void Split3()
        {
            var testList = new List<int>();

            testList.AddRange(Enumerable.Range(1, 30));

            foreach (var lista in testList.SplitInToParts<int>(3))
            {
                Assert.AreEqual(10, lista.Count());    
            }
        }

        [TestMethod]
        public void Split4()
        {

            int[] source = { 1, 2, 3, 4, 5 };

                  
            IEnumerable<IEnumerable<int>> result = source.SplitInToParts(3);

            IEnumerable<IEnumerable<int>> expected = new List<IEnumerable<int>> 
            { 
                new List<int> { 1 }, 
                new List<int> { 2 }, 
                new List<int> { 3, 4, 5 } 
            };



            for (var i = 0; i < result.Count(); i++)
            {
                CollectionAssert.AreEqual(result.ToList()[i].ToList(), expected.ToList()[i].ToList());
            }


          

          

         
                
           
        }

        [TestMethod]
        public void Split6()
        {
            var testList = new List<int>();

            testList.AddRange(Enumerable.Range(1, 31));

            var testOutPutList = new List<int>();

            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(6);
            

            int index = 0;

            foreach (var lista in testList.SplitInToParts<int>(6))
            {
                Assert.AreEqual(testOutPutList[index++], lista.Count());
            }
        }

        [TestMethod]
        public void Split6a()
        {
            var testList = new List<int>();

            testList.AddRange(Enumerable.Range(1, 32));

            var testOutPutList = new List<int>();

            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(5);
            testOutPutList.Add(7);


            int index = 0;

            foreach (var lista in testList.SplitInToParts<int>(6))
            {
                Assert.AreEqual(testOutPutList[index++], lista.Count());
            }
        }

        [TestMethod]
        public void Split20()
        {
            var testList = new List<int>();

            testList.AddRange(Enumerable.Range(1, 32));

            var testOutPutList = new List<int>();

            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(1);
            testOutPutList.Add(13);

            int index = 0;

            foreach (var lista in testList.SplitInToParts<int>(20))
            {
                Assert.AreEqual(testOutPutList[index++], lista.Count());
            }
        }


    }
}
