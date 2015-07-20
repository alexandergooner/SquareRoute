using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class RouteDriverRepository : Repository<RouteDriver>, IRouteDriverRepository
    {
        internal RouteDriverRepository(ApplicationDbContext context)
            : base(context)
        { 
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<RouteDriver> Repo
        {
            get { return this; }
        }

        //GET RouteDriver by userId
        public RouteDriver GetRouteDriverByUserId(Guid userId)
        { 
            return Set.Where(x => x.UserId == userId).FirstOrDefault();
        }

        //GET RouteDriver by routeID
        public RouteDriver GetRouteDriverByRouteId(int routeId)
        {
            return Set.Where(x => x.RouteId == routeId).FirstOrDefault();
        }

        public RouteDriver GetRouteDriverByMobileDeviceId(string mobileDeviceId) 
        {
            return Set.Where(x => x.MobileDeviceId == mobileDeviceId).FirstOrDefault();
        }

    }
}
