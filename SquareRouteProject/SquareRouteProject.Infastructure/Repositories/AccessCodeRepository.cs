using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class AccessCodeRepository : Repository<AccessCode>, IAccessCodeRepository
    {
        internal AccessCodeRepository(ApplicationDbContext context)
            : base(context)
        { 
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<AccessCode> Repo
        {
            get { return this; }
        }        

        //GET AccessCode by AccessCodeId
        public AccessCode GetAccessCodeById(int accessCodeId)
        {
            return Set.FirstOrDefault(x => x.AccessCodeId == accessCodeId);
        }

        //GET AccessCode by AccessCodeName
        public AccessCode GetAccessCodeByName(string accessCodeName)
        {
            return Set.FirstOrDefault(x => x.AccessCodeName == accessCodeName);
        }

        //GET AccessCode by RouteId
        public AccessCode GetAccessCodeByRouteId(int routeId)
        {
            return Set.FirstOrDefault(x => x.RouteId == routeId);
        }

        //DELETE AccessCode by AccessCodeId
        public void DeleteAccessCodeById(int accessCodeId) 
        {
            AccessCode accessCodeToBeDeleted = Set.FirstOrDefault(x => x.AccessCodeId == accessCodeId);
            Set.Remove(accessCodeToBeDeleted);
        }
    }
}
