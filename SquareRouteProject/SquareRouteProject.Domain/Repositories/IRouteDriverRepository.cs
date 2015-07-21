using SquareRouteProject.Domain.Entities;
using System;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IRouteDriverRepository
    {
        RouteDriver GetRouteDriverByRouteId(int routeId);
        RouteDriver GetRouteDriverByUserId(Guid userId);
        RouteDriver GetRouteDriverByMobileDeviceId(string mobileDeviceId);
        RouteDriver GetRouteDriverByRouteNum(int routeNum);
        IRepository<RouteDriver> Repo { get; }
    }
}
