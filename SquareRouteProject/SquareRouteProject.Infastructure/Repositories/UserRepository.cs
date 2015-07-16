using SquareRouteProject.Domain.Entities;
using SquareRouteProject.Domain.Repositories;
using System.Collections.Generic;
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

        //Property Provides access to base Repository<TEntity> members
        public IRepository<User> Repo
        {
            get { return this; }
        }

        #region Universal UserMethods
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
        #endregion

        #region Custom User Methods
        //Find user by RoleType 1-2-3-4
        public IList<User> GetUserByRoleType(int roleType) 
        {
            return Set.Where(u => u.RoleType == roleType).ToList();
        }      
        #endregion
    }
}
