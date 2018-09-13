using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    
    public class PZLStructure : IStudyTest
    {



        public class Emp
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Boss_Id { get; set; }
            public string Stanowsiko { get; set; }
            public string JOrg { get; set; }

        }
        public void Study()
        {
            var empList = File.ReadAllLines("BeeOffice_11.09_h.csv").Skip(1).Select(s =>
            {
                var row = s.Split(new[] { ";" }, StringSplitOptions.None);

                return new Emp
                {
                    Id = row[6],
                    Name = row[0] + " " + row[1],
                    Boss_Id = row[3],
                    Stanowsiko = row[2],
                    JOrg = row[4]
                };
            });

            var list = new List<List<Emp>>();
            var errorList = new List<List<Emp>>();
            var notEmp = new List<List<Emp>>();
            var notJOrg = new List<List<Emp>>();

            foreach (var item in empList)
            {
                var hasError = false;

                var train = new List<Emp>
                {
                    item
                };

                var whileEmp = item;
               

                while (string.IsNullOrEmpty(whileEmp.Boss_Id) == false)
                {
                    var boss = empList.FirstOrDefault(e => e.Id == whileEmp.Boss_Id);

                     if (whileEmp.Boss_Id == whileEmp.Id)
                    {
                        errorList.Add(train);
                        //hasError = true;
                        break;
                    }

                    if (boss == null)
                    {
                        notEmp.Add(train);
                        //hasError = true;
                        break;
                    }

                    if (string.IsNullOrEmpty(item.JOrg))
                    {
                        notJOrg.Add(train);
                        hasError = true;
                        break;
                    }

                    if (boss != null && whileEmp.Boss_Id != whileEmp.Id)
                    {
                        train.Add(boss);
                    }

                   

                    whileEmp = boss;
                }
                if (hasError == false)
                {
                    list.Add(train);
                }
                
            }

            var root = new TreeNode("Zarząd");
            var tempRoot = root;
            


            foreach (var train in list)
            {
                train.Reverse();


                

                foreach (var item in train)
                {

                    var g = root.Find(item.JOrg);

                    if (g==null)
                    {
                        var newroot = new TreeNode(item.JOrg);
                        tempRoot.Add(newroot);
                        tempRoot = newroot;
                    }
                    else
                    {
                        
                    }

                    
                }

                


            
                tempRoot = root;


            }

            Console.WriteLine(TreeNode.BuildString(root));

        }
    }
}
