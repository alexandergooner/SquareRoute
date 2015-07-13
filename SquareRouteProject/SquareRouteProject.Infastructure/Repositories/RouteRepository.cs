using SquareRouteProject.Domain.Models;
using SquareRouteProject.Domain.Repositories;
using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class RouteRepository : Repository<Route>, IRouteRepository
    {
        internal RouteRepository(ApplicationDbContext context) 
            : base(context) 
        { 
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<Route> Repo
        {
            get { return this; }
        }

        //GET Route by RouteAccessCodeId
        public Route GetRouteByAccessCodeId(int accessCodeId)
        {
            return Set.FirstOrDefault(x => x.AccessCodeId == accessCodeId);
        }

        //GET Route by RouteId
        public Route GetRouteById(int routeId)
        {
            return Set.FirstOrDefault(x => x.RouteId == routeId);
        }

        //GET Route by RouteNum
        public Route GetRouteByRouteNum(int routeNum)
        {
            return Set.FirstOrDefault(x => x.RouteNum == routeNum);
        }
        
        //GET List of Routes by DistrictId
        public IList<Route> GetRoutesByDistrictId(int districtId)
        {
            return Set.Where(x => x.DistrictId == districtId).ToList();
        }

        //DELETE Route by Id
        public void DeleteRouteById(int routeId)
        {
            var routeToBeDeleted = Set.FirstOrDefault(x => x.RouteId == routeId);
            Set.Remove(routeToBeDeleted);
        }
    }
    
}
