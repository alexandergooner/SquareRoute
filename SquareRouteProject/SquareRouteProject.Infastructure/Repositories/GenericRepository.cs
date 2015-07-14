using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareRouteProject.Domain.Models;

namespace SquareRouteProject.Infastructure.Repositories
{
    class GenericRepository : IGenericRepository 
    {
        private DbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        //Generic 'Query'
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }


        //Non-Generic Query
        public IQueryable Query(string entityTypeName)
        {
            var entityType = Type.GetType(entityTypeName);
            return _db.Set(entityType).AsQueryable();
        }

        //Find row by id
        public T Find<T>(params object[] keyValues) where T : class
        {
            return _db.Set<T>().Find(keyValues);
        }

        //Add
        public void Add<T>(T entityToCreate) where T : class
        {
            _db.Set<T>().Add(entityToCreate);
        }

        //Delete
        public void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = this.Find<T>(keyValues);
            _db.Set<T>().Remove(entity);
        }

        //save changes and throw validation exceptions
        public void SaveChanges()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbValEx)
            {
                var firstError = dbValEx.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        //stored procedure and dynamic SQL
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this._db.Database.SqlQuery<T>(sql, parameters);
        }

        //dispose
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
