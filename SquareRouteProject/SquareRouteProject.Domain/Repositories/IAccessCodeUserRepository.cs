using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IAccessCodeUserRepository
    {
        IList<AccessCodeUser> GetAllAccessCodeUsersByAccessCodeId(int accesssCodeId);
        IList<AccessCodeUser> GetAllAccessCodeUsersByUserId(Guid userId);
        IRepository<AccessCodeUser> Repo { get; }
    }
}
