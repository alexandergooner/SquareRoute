using SquareRouteProject.Domain.Entities;
using System;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IRouteDriverRepository
    {
        RouteDriver GetRouteDriverByRouteId(int routeId);
        RouteDriver GetRouteDriverByUserId(Guid userId);
        IRepository<RouteDriver> Repo { get; }
    }
}
