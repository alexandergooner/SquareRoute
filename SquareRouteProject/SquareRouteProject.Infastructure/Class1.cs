using SquareRouteProject.Infastructure.Models;
using SquareRouteProject.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure
{
    public class RouteDbcontext:DbContext
    {
        DbSet<Route> Routes { get; set; }
        DbSet<AccessCode> AccessCodes { get; set; }
        DbSet<BusStop> BusStops { get; set; }


    }
}
