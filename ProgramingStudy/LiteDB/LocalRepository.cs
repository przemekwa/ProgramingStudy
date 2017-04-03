using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.LiteDB
{
    internal class LocalRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly string _databaseFilePath;

        public LocalRepository()
        {
            _databaseFilePath = @"localRepository.db";
        }

        public TEntity[] GetAll()
        {
            using (var db = new LiteDatabase(_databaseFilePath))
            {
                return db.GetCollection<TEntity>().FindAll().ToArray();
            }
        }

        public void Add(TEntity entity)
        {
            using (var db = new LiteDatabase(_databaseFilePath))
            {
                db.GetCollection<TEntity>().Insert(entity);
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new LiteDatabase(_databaseFilePath))
            {
                var updateResult = db.GetCollection<TEntity>().Update(entity);
                if (!updateResult)
                {
                    throw new Exception("Entity not found");
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (var db = new LiteDatabase(_databaseFilePath))
            {
                var deleteResult = db.GetCollection<TEntity>().Delete(entity.Id);
                if (!deleteResult)
                {
                    throw new Exception("Entity not found");
                }
            }
        }
    }
}
