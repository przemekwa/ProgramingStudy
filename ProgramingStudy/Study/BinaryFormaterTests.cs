using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class BinaryFormaterTests : IStudyTest
    {
        public object DeSerializer()
        {
            var fs = new FileStream("dane.dat", FileMode.Open);

            var bf = new BinaryFormatter();


            object result = null;

            try
            {
                result = bf.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            return result;

        }

        public void Serialization(object testObj)
        {
            var fs = new FileStream("dane.dat", FileMode.CreateNew);

            var bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, testObj);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                fs.Close();
            }


        }

        public void Study()
        {
            var payrollnumbers = new List<string> { "1", "2", "3" };

            var currpayrollIndex = payrollnumbers.IndexOf("1");
            var nextPayrollIndex = currpayrollIndex++;

            var payrollnumber = payrollnumbers[nextPayrollIndex];

            var testObj = new Hashtable();

            testObj.Add("Mąż", "Przemek");
            testObj.Add("Żona", "Jola");

            foreach (DictionaryEntry item in testObj)
            {
                Console.WriteLine("Klucz {0} Wartość {1}", item.Key, item.Value);
            }

            this.Serialization(testObj);

            var result = this.DeSerializer();

            foreach (DictionaryEntry item in testObj)
            {
                Console.WriteLine("Klucz {0} Wartość {1}", item.Key, item.Value);
            }

        }
    }
}
