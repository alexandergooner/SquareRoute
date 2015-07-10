using SquareRouteProject.Presentation.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    public class RouteExtensions
    {
        //GET route by RouteAccessCode
        public static Route GetRouteByAccessCode(this GenericRepository repo, AccessCode code)
        {
            return repo.Query<Route>().Where(r => r.AccessCode == code).Select(r => new Route 
            { 
                AccessCode = r.AccessCode,
                AccessCodeId = r.AccessCodeId,
                BusStops = r.BusStops,
                District = r.District,
                DistrictId = r.DistrictId,
                RouteId = r.RouteId,
                RouteNum = r.RouteNum,
                Users = r.Users
            })
            .FirstOrDefault();
        }
        //GET route by RouteNum
        public static Route GetRouteId(this GenericRepository repo, int routeNum)
        {
            return repo.Query<Route>().Where(r => r.RouteNum == routeNum).Select(r => new Route
            {
                AccessCode = r.AccessCode,
                AccessCodeId = r.AccessCodeId,
                BusStops = r.BusStops,
                District = r.District,
                DistrictId = r.DistrictId,
                RouteId = r.RouteId,
                RouteNum = r.RouteNum,
                Users = r.Users
            })
            .FirstOrDefault();
        }

        //UPDATE route (by RouteNum)
        public static void UpdateRoute(this GenericRepository repo, Route route)
        {
            var routeToEditById = repo.Query<Route>().Where(r => r.RouteNum == route.RouteNum).Select(r => r.RouteId).FirstOrDefault();
            if (routeToEditById != null)
            {
                repo.Delete<Route>(routeToEditById);
                repo.SaveChanges();
            }

            repo.Add<Route>(route);
            repo.SaveChanges();

        }

        //ADD route
        public static void AddRoute(this GenericRepository repo, Route route)
        {
            repo.Add<Route>(route);
        }

        //DELETE route(by Id)

        public static void DeleteRoute(this GenericRepository repo, int routeId)
        {
            var routeToBeDeleted = repo.Query<Route>().Where(r => r.RouteId == routeId).Select(r => r.RouteId).FirstOrDefault();
            repo.Delete<Route>(routeToBeDeleted);
        }
    }
    }
}
