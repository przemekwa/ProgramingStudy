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
        public const string UNASSIGNED_ID = "Nieprzypisani";
        public void Study()
        {
            var tree = GetRootNode();
            ShowAllTree(tree);
        }

        public TreeNode GetRootNode(string fileName = "BeeOffice_14.09.csv")
        {
            var employeesList = GetEmployeesFromFile(fileName);

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


            return GenerateTreeNodes(employeesList, allStringEmployees);
        }

        private TreeNode GenerateTreeNodes(IEnumerable<Employee> employeesList, List<List<Employee>> allStringEmployees)
        {
            var rootNode = new TreeNode("Zarząd")
            {
                new TreeNode(UNASSIGNED_ID)
            };

            foreach (var employeesString in allStringEmployees)
            {
                AddOrganizationUnitAndPosition(rootNode, employeesString, employeesList);
            }

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

        private void AddOrganizationUnitAndPosition(TreeNode rootNode, List<Employee> employeesString, IEnumerable<Employee> employeesList)
        {
            employeesString.Reverse();

            TreeNode boosNode = rootNode;

            foreach (var employee in employeesString)
            {
                if (string.IsNullOrWhiteSpace(employee.OrganizationUnit))
                {
                    var unNode = rootNode.Find(UNASSIGNED_ID);

                    var msg = $"Dział dla {employee.Id} @@";

                    if (unNode.Find(msg) == null)
                    {
                        boosNode = new TreeNode(msg);
                        unNode.Add(boosNode);
                    }

                    continue;
                }


                if (employeesList.FirstOrDefault(d=>d.Id == employee.BossId) == null)
                {
                    var unNode = rootNode.Find(UNASSIGNED_ID);

                    var msg = $"Stanowisko/Dział dla {employee.BossId} @@";

                    if (unNode.Find(msg) == null)
                    {
                        boosNode = new TreeNode(msg);
                        unNode.Add(boosNode);
                    }

                    continue;
                }

                var nodeWithOrganizationUnit = rootNode.Find(employee.OrganizationUnit);

                if (nodeWithOrganizationUnit == null)
                {
                    //
                    // Jeśli nie ma organizacji, dodaj ją do Zarządu, dodaj pracownika i ustaw i uaktualnij gałąź z szefem.
                    //

                    var newNodeOrgUnit = new TreeNode(employee.OrganizationUnit);
                    var newNodePos = new TreeNode(employee.Position);

                    newNodeOrgUnit.Add(newNodePos);

                    boosNode.Add(newNodeOrgUnit);

                    boosNode = newNodePos;
                }
                else
                {
                    //
                    // Jeśli jest organizacja to sprawdź czy stanowisko nie jest puste. Jeśli puste to dodaj do nieprzypisanych i uaktualnij gałąź z szefem.
                    //

                    if (string.IsNullOrWhiteSpace(employee.Position)) 
                    {
                        var unNode = rootNode.Find(UNASSIGNED_ID);

                        var msg = $"Stanowisko dla {employee.Id} @@";

                        if (unNode.Find(msg) == null)
                        {
                            boosNode = new TreeNode(msg);
                            unNode.Add(boosNode);
                        }

                        continue;
                    }

                    //
                    // Jeśli jest to sprawdź czy w gałęzi z szefem już takiego stanowisko nie ma. Jeśli jest uaktualnij gałąź z szefem. Jeśli nie to dodaj nowe
                    // stanowisko i uaktualnij gałąź z szefem
                    //

                    if (boosNode.Find(employee.Position) != null)
                    {
                        boosNode = boosNode.Find(employee.Position);
                        continue;
                    }

                    //
                    // To jest przypadek, gdy szef może mieć też inny dział niż pracownik. Szuakmy wtedy w gałęzi szefa, działy pracownika i dopiero wtedy dodajemy 
                    // stanowisko.
                    //

                    if (boosNode.Find(employee.OrganizationUnit) != null)
                    {
                        boosNode = boosNode.Find(employee.OrganizationUnit);
                    }

                    var newroot = new TreeNode(employee.Position);

                    boosNode.Add(newroot);

                    boosNode = newroot;
                }
            }
        }



        private void ShowAllTree(TreeNode rootNode)
        {
            File.WriteAllText($"tree{DateTime.Now.ToString("ddMMyyyyHHmmss")}.txt", TreeNode.BuildString(rootNode));
        }
    }
}
