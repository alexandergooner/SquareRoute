using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SquareRouteProject.Domain.Repositories
{
    public interface IUserRepository
    {
        User FindByEmail(string usernameEmail);
        Task<User> FindByEmailAsync(string usernameEmail);
        Task<User> FindByEmailAsync(System.Threading.CancellationToken cancellationToken, string usernameEmail);
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username);
        IList<User> GetUserByRoleType(int roleType);
        IRepository<User> Repo { get; }
    }
}
