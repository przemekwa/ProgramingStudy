using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BossId { get; set; }
        public string Position { get; set; }
        public string OrganizationUnit { get; set; }

    }

    public class PZLStructure : IStudyTest
    {
        public void Study()
        {
            var employeesList = GetEmployeesFromFile("BeeOffice_11.09_h.csv");

            var allStringEmployees = new List<List<Employee>>();
            var errorList = new List<List<Employee>>();
            var notEmp = new List<List<Employee>>();
            var notJOrg = new List<List<Employee>>();

            foreach (var employee in employeesList)
            {
                var hasError = false;

                var train = new List<Employee>
                {
                    employee
                };

                var currentEmployee = employee;


                while (string.IsNullOrEmpty(currentEmployee.BossId) == false)
                {
                    var boss = employeesList.FirstOrDefault(e => e.Id == currentEmployee.BossId);

                    if (currentEmployee.BossId == currentEmployee.Id)
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

                    if (string.IsNullOrEmpty(employee.OrganizationUnit))
                    {
                        notJOrg.Add(train);
                        hasError = true;
                        break;
                    }

                    if (boss != null && currentEmployee.BossId != currentEmployee.Id)
                    {
                        train.Add(boss);
                    }

                    currentEmployee = boss;
                }

                if (hasError == false)
                {
                    allStringEmployees.Add(train);
                }

            }


            TreeNode tree = GenerateTreeNodes(employeesList, allStringEmployees);

            ShowAllTree(tree);
        }

        private TreeNode GenerateTreeNodes(IEnumerable<Employee> employeesList, List<List<Employee>> allStringEmployees)
        {
            var rootNode = new TreeNode("Zarząd");
            var tempNode = rootNode;

            foreach (var employeesString in allStringEmployees)
            {
                AddOrganizationUnit(rootNode, tempNode, employeesString);
            }

            AddPositions(rootNode, allStringEmployees);
            return rootNode;
        }

        private IEnumerable<Employee> GetEmployeesFromFile(string fileName) =>
        
            File.ReadAllLines(fileName).Skip(1).Select(s =>
            {
                var row = s.Split(new[] { ";" }, StringSplitOptions.None);

                return new Employee
                {
                    Id = row[6],
                    Name = row[0] + " " + row[1],
                    BossId = row[3],
                    Position = row[2],
                    OrganizationUnit = row[4]
                };
            });
        

        private void AddOrganizationUnit(TreeNode rootNode, TreeNode tempNode, List<Employee> employeesString)
        {
            employeesString.Reverse();

            foreach (var employee in employeesString)
            {
                if (rootNode.Find(employee.OrganizationUnit) == null)
                {
                    var newroot = new TreeNode(employee.OrganizationUnit);
                    tempNode.Add(newroot);
                    tempNode = newroot;
                }
            }

            tempNode = rootNode;
        }

        private void AddPositions(TreeNode rootNode, List<List<Employee>> allStringEmployees)
        {
            foreach (var employeeString in allStringEmployees)
            {
                foreach (var employee in employeeString)
                {
                    var node = rootNode.Find(employee.OrganizationUnit);

                    if (node.Find(employee.Position) != null)
                    {
                        continue;
                    }

                    var newNode = new TreeNode(employee.Position);

                    node.Add(newNode);

                    node = newNode;
                }

            }
        }

        private void ShowAllTree(TreeNode rootNode)
        {
           File.WriteAllText("tree.txt", TreeNode.BuildString(rootNode));
        }
    }
}
