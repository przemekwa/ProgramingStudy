using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [Flags]
    public enum Test
    {
        Pierwsza =0,
        Druga = 2,
        Trzecia = 4
    }
    class EnumEnumeration : IStudyTest
    {
        public void Study()
        {

            Test wartość = Test.Trzecia | Test.Druga;


            var dict = new Dictionary<Test, Action>
            {
               {Test.Pierwsza, ()=>Console.WriteLine("1")},
               {Test.Druga, ()=>Console.WriteLine("2")},
               {Test.Trzecia, ()=>Console.WriteLine("3")}
            };

           
            foreach (var t in dict.Keys)
            {
                if (wartość.HasFlag(t))
                {
                    dict[t].Invoke();
                }
            }





            //var action = from value in t
            //             where wartość.HasFlag(value) 
            //             select dict[value];




            
                
            



        }
    }
}
