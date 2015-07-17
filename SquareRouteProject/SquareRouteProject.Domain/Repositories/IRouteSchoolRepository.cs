using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
namespace SquareRouteProject.Infastructure.Repositories
{
    public interface IRouteSchoolRepository
    {
        IList<RouteSchool> GetAllRouteSchoolsByRouteId(int routeId);
        IList<RouteSchool> GetAllRouteSchoolsBySchoolId(int schoolId);
        IRepository<RouteSchool> Repo { get; }
    }
}
