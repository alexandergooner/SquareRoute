using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IBusStopRepository
    {
        void DeleteBusStopById(int busStopId);
        BusStop GetStopById(int busStopId);
        BusStop GetStopByLocation(string location);
        IList<BusStop> GetStopsByRouteId(int routeId);
        IRepository<BusStop> Repo { get; }
    }
}
