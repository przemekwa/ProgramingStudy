using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.BCCHelpers
{
    public class Lidero : IStudyTest
    {
        public class CatalogItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? ParentId { get; set; }
            public string FullPath { get; set; }
        }

        public class Course
        {
            public int Id { get; set; }
            public int Calalog_id { get; set; }
        }

        public Dictionary<int, CatalogItem> catalogList { get; set; }
        public List<Course> courseList { get; set; }

        public Lidero()
        {
            this.courseList = new List<Course>();

            this.courseList.Add(new Course
            {
                Id = 515,
                Calalog_id = 14
            });

            this.courseList.Add(new Course
            {
                Id = 516,
                Calalog_id = 2
            });

            this.courseList.Add(new Course
            {
                Id = 517,
                Calalog_id = 2
            });

            this.courseList.Add(new Course
            {
                Id = 518,
                Calalog_id = 2
            });




            this.catalogList = new Dictionary<int, CatalogItem>();

            catalogList.Add(5,new CatalogItem
            {
                Id = 5,
                Name = "Główny",
                ParentId = null
            });

            catalogList.Add(9,new CatalogItem
            {
                Id = 9,
                Name = "Cecylia",
                ParentId = 2
            });

            catalogList.Add(10, new CatalogItem
            {
                Id = 10,
                Name = "Batory",
                ParentId = 2
            });

            catalogList.Add(11, new CatalogItem
            {
                Id = 11,
                Name = "Amerelis",
                ParentId = 2
            });

            catalogList.Add(14, new CatalogItem
            {
                Id = 14,
                Name = "Zetor 01",
                ParentId = 4
            });

            catalogList.Add(2, new CatalogItem
            {
                Id = 2,
                Name = "Szkolenia",
                ParentId = 5
            });

            catalogList.Add(12, new CatalogItem
            {
                Id = 12,
                Name = "Zefir",
                ParentId = 9
            });

            catalogList.Add(13, new CatalogItem
            {
                Id = 13,
                Name = "Ursus",
                ParentId = 10
            });

            catalogList.Add(4, new CatalogItem
            {
                Id = 4,
                Name = "Zetor5",
                ParentId = 10
            });

        }


        public void Study()
        {
            var fullCatalogList = this.SetFullPathProperty(this.catalogList);


            foreach (var item in this.courseList)
            {
                Console.WriteLine(string.Join("->", fullCatalogList[item.Calalog_id].FullPath.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Reverse()));
            }


        }


        public Dictionary<int, CatalogItem> SetFullPathProperty(Dictionary<int, CatalogItem> catalogStructure)
        {
            foreach (var item in catalogStructure)
            {
                if (!item.Value.ParentId.HasValue)
                {
                    item.Value.FullPath = item.Value.Name;
                    continue;
                }

                item.Value.FullPath = $"{item.Value.Name}-";

                item.Value.FullPath += $"{catalogList[item.Value.ParentId.Value].Name}-";

                var parent = catalogList[item.Value.ParentId.Value];

                while (parent.ParentId.HasValue)
                {
                    item.Value.FullPath += $"{catalogList[parent.ParentId.Value].Name}-";

                    parent = catalogList[parent.ParentId.Value];
                };
            }

            return catalogStructure;
        }




    }
}
