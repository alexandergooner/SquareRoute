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
    internal class BusStopRepository : Repository<BusStop>, IBusStopRepository
    {
        internal BusStopRepository(ApplicationDbContext context)
            : base(context) 
        { 
        }

        //GET BusStop by BusStopId
        public BusStop GetStopById(int busStopId)
        {
            return Set.FirstOrDefault(x => x.BusStopId == busStopId);
        }

        //GET BusStop By RouteId
        public IList<BusStop> GetStopsByRouteId(int routeId)
        {
            return Set.Where(x => x.RouteId == routeId).ToList();
        }

        //GET BusStop By Location
        public BusStop GetStopByLocation(string location)
        {
            return Set.FirstOrDefault(x => x.Location == location);
        }

        //DELETE BusStop by Id
        public void DeleteBusStopById(int busStopId)
        {
            BusStop stopToBeDeleted = Set.FirstOrDefault(x => x.BusStopId == busStopId);
            Set.Remove(stopToBeDeleted);            
        }
    }
}
