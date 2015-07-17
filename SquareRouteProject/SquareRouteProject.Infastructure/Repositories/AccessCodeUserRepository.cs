using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class AccessCodeUserRepository : Repository<AccessCodeUser>
    {
        internal AccessCodeUserRepository(ApplicationDbContext context)
            :base(context)
        {
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<AccessCodeUser> Repo
        { 
            get { return this; }
        }

        //GET        
        public IList<AccessCodeUser> GetAllAccessCodeEntriesForUser(Guid userId)
        {
            return Set.Where(u => u.UserId == userId).ToList();
        } 
    }
}
