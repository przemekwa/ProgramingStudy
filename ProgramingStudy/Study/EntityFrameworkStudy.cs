using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class EntityFrameworkStudy : IStudyTest
    {
        public void Study()
        {
            var context = new EntityContext();


            var f = context.EntityParents.First();

            var d = f.EntityChild;

            context.EntityParents.Remove(f);



            //context.EntityParents.Add(new EntityParent
            //{
            //    Name = "Przemek3",
            //    EntityChild = new EntityChild
            //    {
            //        Name = "Julek3"
            //    }

            //});


           




            context.SaveChanges();

        }
    }


    public class EntityContext : DbContext
    {
        public DbSet<EntityParent> EntityParents { get; set; }
        public DbSet<EntityChild> EntityChild { get; set; }

        public EntityContext() :base("entityFramework")
        {
            this.Database.CreateIfNotExists();
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<EntityParent>()
                .HasRequired(a => a.EntityChild)
                .WithMany()
                .HasForeignKey(u => u.EntityChildId).WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }



    }


    public class EntityParent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int EntityChildId { get; set; }
        public virtual EntityChild EntityChild { get; set; }
    }

    public class EntityChild
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }


























}
