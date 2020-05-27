using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class ExtensionMethod
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            if (array.Length == 0 || size == 0)
            {
                yield return array;
            }

            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IList<T> list, int size)
        {
            if (list.Count == 0 || size == 0)
            {
                yield return list;
            }

            for (var i = 0; i < (float)list.Count / size; i++)
            {
                yield return list.Skip(i * size).Take(size);
            }

        }

        public static IEnumerable<IEnumerable<T>> SplitInToParts<T>(this IList<T> source, short parts)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Count == 0)
            {
                throw new InvalidOperationException("Source cannot be empty");
            }

            if (parts == 0)
            {
                throw new ArgumentException("Cannot divide by zero.", "parts");
            }

            var totalRows = source.Count;

            var skipRows = 0;

            var takeRows = totalRows / parts;

            for (var part = 0; part < parts; part++)
            {
                var partialList = new List<T>();

                partialList.AddRange(source.Skip(skipRows).Take(takeRows));

                skipRows += takeRows;

                if (part == parts - 2)
                {
                    takeRows = totalRows - skipRows;
                }

                yield return partialList;
            }

        }
    }

   
    class ExtensionLinqu : IStudyTest
    {
        public void Study()
        {

            var testList = new List<int>();

            testList.AddRange(Enumerable.Range(1, 30));

            

            foreach (var lista in testList.SplitInToParts<int>(4))
            {
                Console.WriteLine("{0} - {1}", lista.Count(), 10);
            }
        
        }
    }
}
