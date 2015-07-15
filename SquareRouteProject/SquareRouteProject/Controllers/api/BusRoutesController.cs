using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SquareRouteProject.Presentation.Controllers.api
{
    public class BusRoutesController : ApiController
    {
        // TEST CONTROLLER ONLY; NOT FOR ACTUAL USE
        static BusRoutesController()
        {

        }

        public IList<Route> Get()
        {
            var routes = new List<Route>
            {
                new Route {
                    RouteId = 1,
                    RouteNum = 100,
                    RouteStart = "6351 Pinemont, Houston, TX",
                    RouteEnd = "5100 Maple St, Bellaire, TX",
                    DistrictId = 1,
                    AccessCodeId = 1,
                    BusStops = new List<BusStop>
                    {
                        new BusStop {
                            BusStopId = 1,
                            Location = "4049 Woodshire St, Houston, TX",
                            RouteId = 1
                        },
                        new BusStop {
                            BusStopId = 2,
                            Location = "10401 WOODWIND DR, Houston, TX",
                            RouteId = 1
                        },
                        new BusStop {
                            BusStopId = 3,
                            Location = "4134 MCDERMED DR, Houston, TX",
                            RouteId = 1
                        },
                        new BusStop {
                            BusStopId = 4,
                            Location = "10113 BASSOON DR, Houston, TX",
                            RouteId = 1
                        },
                        new BusStop {
                            BusStopId =5,
                            Location = "10114 WOODWIND DR, Houston, TX",
                            RouteId = 1
                        },
                        new BusStop {
                            BusStopId = 6,
                            Location = "4081 SILVERWOOD DR, Houston, TX",
                            RouteId = 1
                        }
                    }

                }
            };

            return routes;
        }

        
    }
}
