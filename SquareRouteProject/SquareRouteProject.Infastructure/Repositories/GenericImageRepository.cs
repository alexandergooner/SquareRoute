using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    class GenericImageRepository : SquareRouteProject.Infastructure.Repositories.IGenericImageRepository
    {
          private ImageDbContext _db;

        public GenericImageRepository(ImageDbContext imgdb)
        {
            _db = imgdb;
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

