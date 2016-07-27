

using System.ComponentModel;

namespace ProgramingStudy.Study.LanguageStudy
{
   
        using System;

        [AttributeUsage(AttributeTargets.Class)]
        public class MojAtrybut : Attribute
        {
            public string Name { get; set; }

            public MojAtrybut(string name)
            {
                this.Name = name;
            }

            public void Cos()
            {

            }
        }

        public class Kolejnosc : Attribute
        {
            public int Numer { get; set; }

            public Kolejnosc(int numer)
            {
                this.Numer = numer;
            }
        }


        [MojAtrybut("anana")]
        public class Klasa23
        {
            [Kolejnosc(3)]
            public int cos { get; set; }

           public int cos1 { get; set; }


            public int cos2 { get; set; }


            public int cos3 { get; set; }
            public int cos4 { get; set; }


            public void jeden()
            {
                Console.WriteLine("Jeden");
            }


            public void Dwa()
            {
                Console.WriteLine("Dwa");
            }


            public void Trzy()
            {
                Console.WriteLine("Trzy");
            }


            public void Cztery()
            {
                Console.WriteLine("Cztery");
            }
        }

    public class Atrybuty : IStudyTest
    {
        public void AtrubbuteTests()
        {
            Klasa23 te = new Klasa23();

            var test = te.GetType().GetProperties();

            Int32 q = 54;

            var t1 = q.GetType();

            var t = test[0].PropertyType;

            var t3 = t.BaseType;

            var converter = TypeDescriptor.GetConverter(t);

            var result = converter.ConvertFrom("124");

            var tqqqq = test[0].GetCustomAttributes(typeof(Kolejnosc), true);

            var test2 = (Kolejnosc) tqqqq[0];

            test[1].SetValue(te, 3.454, null);

            //var wykonywanieWkolejnosci = new List<KeyValuePair<int, MethodInfo>>();

            //foreach (var methodInfo in test)
            //{
            //    wykonywanieWkolejnosci.AddRange(Attribute.GetCustomAttributes(methodInfo).OfType<Kolejnosc>()
            //        .Select(b => new KeyValuePair<int, MethodInfo>(b.Numer, methodInfo)));
            //}

            //foreach (var methodInfo in wykonywanieWkolejnosci.OrderBy(t => t.Key))
            //{
            //    methodInfo.Value.Invoke(te,null);
            //}
        }

        public void Study()
        {
            throw new NotImplementedException();
        }
    }
}
