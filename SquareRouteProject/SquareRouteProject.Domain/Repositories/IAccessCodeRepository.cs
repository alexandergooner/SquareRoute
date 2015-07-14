using SquareRouteProject.Domain.Entities;
using System;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IAccessCodeRepository
    {
        void DeleteAccessCodeById(int accessCodeId);
        AccessCode GetAccessCodeById(int accessCodeId);
        AccessCode GetAccessCodeByValue(string accessCodeValue);
        AccessCode GetAccessCodeByRouteId(int routeId);
        IRepository<AccessCode> Repo { get; }
    }
}
