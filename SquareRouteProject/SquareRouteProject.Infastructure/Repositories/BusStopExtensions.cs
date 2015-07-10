using SquareRouteProject.Presentation.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    public class BusStopExtensions
    {
        //GET BusStop by BusStopId
        public static BusStop GetStopById(this GenericRepository repo, int id)
        {
            return repo.Query<BusStop>().Where(s => s.BusStopId == id).Select(s => new BusStop
            {
                BusStopId = s.BusStopId,
                Location = s.Location,
                Route = s.Route,
                RouteId = s.RouteId
            })
            .FirstOrDefault();
        }

        //GET BusStop By RouteId
        public static List<BusStop> GetStopsByRouteId(this GenericRepository repo, int id)
        {
            return repo.Query<BusStop>().Where(s => s.RouteId == id).ToList();
        }

        //UPDATE BusStop By BusStop
        public static void UpdateBusStopById(this GenericRepository repo, BusStop stop)
        {
            var stopToUpdate = repo.Query<BusStop>().Where(s => s.BusStopId == stop.BusStopId).Select(r => r.RouteId).FirstOrDefault();
            if (stopToUpdate != null)
            {
                repo.Delete<BusStop>(stopToUpdate);
                repo.SaveChanges();
            }

            repo.Add<BusStop>(stop);
            repo.SaveChanges();
        }

        //DELETE BusStop by Id
        public static void DeleteBusStopById(this GenericRepository repo, int id)
        {
            var stopToBeDeleted = repo.Query<BusStop>().Where(s => s.RouteId == id).Select(s => s.RouteId).FirstOrDefault();
            repo.Delete<BusStop>(stopToBeDeleted);
        }
    }
}
