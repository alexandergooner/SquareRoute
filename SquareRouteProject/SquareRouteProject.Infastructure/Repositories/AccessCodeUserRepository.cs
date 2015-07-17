using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class AccessCodeUserRepository : Repository<AccessCodeUser>, IAccessCodeUserRepository
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

        //GET All AccessCodeUser entries for a given userId
        public IList<AccessCodeUser> GetAllAccessCodeUsersByUserId(Guid userId)
        {
            return Set.Where(u => u.UserId == userId).ToList();
        } 

        //GET All AccessCodeUser entries for a given accessCodeId
        public IList<AccessCodeUser> GetAllAccessCodeUsersByAccessCodeId(int accesssCodeId)
        {
            return Set.Where(a => a.AccessCodeId == accesssCodeId).ToList();
        }
    }
}
