using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System;
using System.Collections.Generic;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IRouteUserRepository
    {
        IList<RouteUser> GetAllRouteUsersByUserId(Guid userId);
        IList<RouteUser> GetAllRouteUsersByUsername(string username);
        IRepository<RouteUser> Repo { get; }
    }
}
