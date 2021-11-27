using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public record Rec1(string name, Rec2 age);
public record Rec2(int age);
public class Cla1
{
    public string Name { get; init; }

}

[Execute(DateTime = "27-11-2021 08:36")]
   public class RecordsFeature : IStudyTest
    {
        public void Study()
        {

        var r1 = new Rec1("Rec1", new Rec2(12));

        var r2 = new Rec1("Rec1", new Rec2(13));

        Console.Write(r1 == r2);


        var c1 = new Cla1
        {
            Name = "Cla1"
        };


        var c2 = new Cla1
        {
            Name = "Cla1"
        };

        Console.Write(c1 == c2);


        Console.WriteLine("Hello form c9 records");
        }
    }

