
using System;
using System.Collections.Generic;
using System.Linq;
namespace SquareRouteProject.Domain.Models
{
    public interface IGenericRepository : IDisposable
    {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        //void Dispose();
        T Find<T>(params object[] keyValues) where T : class;
        System.Linq.IQueryable Query(string entityTypeName);
        System.Linq.IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
        System.Collections.Generic.IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
    }
}