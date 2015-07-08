using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SquareRouteProject.Infastructure.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }

        public User FindByEmail(string usernameEmail)
        {
            return Set.FirstOrDefault(x => x.UserName == usernameEmail);
        }

        public Task<User> FindByEmailAsync(string usernameEmail)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == usernameEmail);
        }

        public Task<User> FindByEmailAsync(System.Threading.CancellationToken cancellationToken, string usernameEmail)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == usernameEmail, cancellationToken);
        }
    }
}
