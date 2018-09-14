﻿using System;
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
            var employeesList = GetEmployeesFromFile("BeeOffice_14.09.csv");

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
            rootNode.Add(new TreeNode(UNASSIGNED_ID));

            var tempNode = rootNode;

            foreach (var employeesString in allStringEmployees)
            {
                AddOrganizationUnit(rootNode, tempNode, employeesString);
            }

            AddPositions(rootNode, allStringEmployees, employeesList);
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

                if (string.IsNullOrWhiteSpace(employee.OrganizationUnit))
                {
                    var unNode = rootNode.Find(UNASSIGNED_ID);

                    var msg = $"Dział dla {employee.Id} @@";

                    if (unNode.Find(msg) == null)
                    {
                        unNode.Add(new TreeNode(msg));
                    }

                    continue;
                }

                if (rootNode.Find(employee.OrganizationUnit) == null)
                {
                    var newroot = new TreeNode(employee.OrganizationUnit);
                    tempNode.Add(newroot);
                    tempNode = newroot;
                }
            }

            tempNode = rootNode;
        }

        private void AddPositions(TreeNode rootNode, List<List<Employee>> allStringEmployees, IEnumerable<Employee> employees )
        {
            foreach (var employeeString in allStringEmployees)
            {
                foreach (var employee in employeeString)
                {
                    if (employees.FirstOrDefault(d=>d.Id==employee.BossId) == null)
                    {
                        var unNode = rootNode.Find(UNASSIGNED_ID);

                        var msg = $"Stanowisko dla {employee.Id} @@";

                        if (unNode.Find(msg) == null)
                        {
                            unNode.Add(new TreeNode(msg));
                        }

                        continue;
                    }

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
