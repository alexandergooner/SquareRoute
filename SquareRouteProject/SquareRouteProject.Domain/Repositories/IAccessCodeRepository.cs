using SquareRouteProject.Presentation.Models.Data;
using System;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IAccessCodeRepository
    {
        void DeleteAccessCodeById(int accessCodeId);
        AccessCode GetAccessCodeById(int accessCodeId);
        AccessCode GetAccessCodeByName(string accessCodeName);
        AccessCode GetAccessCodeByRouteId(int routeId);
    }
}
