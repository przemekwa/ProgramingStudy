using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study.Kata
{
    public class BinaryChop : IStudyTest
    {
        public int SearchNumber { get; set; }

        public int ResultIndex { get; set; }

        public int Chop(int searchNumber, int[] table)
        {
            this.ResultIndex = 0;
            this.SearchNumber = searchNumber;

            if (table.Length == 0)
            {
                return -1;
            }

            if (table.Length > 1)
            {
                this.ResultIndex = this.GetIndex(table);
            }

            var t = this.podziel(table, this.ResultIndex);

            while (t.Length > 1)
            {
                var index = this.GetIndex(t);

                t = this.podziel(t, index);
            }

            return t[0] == searchNumber ? this.ResultIndex : -1;
        }

        private int[] podziel(int[] table, int index)
        {
            if (table[index] > this.SearchNumber)
            {
                this.ResultIndex--;
                return table.Take(index).ToArray();
            }
            else if (table[index] < this.SearchNumber)
            {
                this.ResultIndex++;
                return table.Skip(index).ToArray();
            }
            else
            {
                return new[] { table[index] };
            }
        }

        private int GetIndex(int[] table)
        {
            var mid = table.Length / 2;

            return mid;
        }

        public void Study()
        {
            throw new NotImplementedException();
        }
    }
}
