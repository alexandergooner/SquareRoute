using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IRouteRepository
    {
        void DeleteRouteById(int routeId);
        Route GetRouteByAccessCodeId(int accessCodeId);
        Route GetRouteById(int routeId);
        Route GetRouteByRouteNum(int routeNum);
        IList<Route> GetRoutesByDistrictId(int districtId);
        IRepository<Route> Repo { get; }
    }
}
