using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class RouteUserRepository : Repository<RouteUser>, IRouteUserRepository
    {
        internal RouteUserRepository(ApplicationDbContext context)
            : base(context)
        { 
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<RouteUser> Repo
        {
            get { return this; }
        }

        //GET all RouteUsers by Id
        public IList<RouteUser> GetAllRouteUsersByUserId(Guid userId)
        {
            return Set.Where(x => x.UserId == userId).ToList();
        }

        //GET all RouteUsers by Username
        public IList<RouteUser> GetAllRouteUsersByUsername(string username)
        {
            return Set.Where(x => x.User.UserName == username).ToList();
        }
    }
}
