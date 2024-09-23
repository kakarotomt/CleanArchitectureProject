using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Users;

namespace UserApp.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public Task<List<User?>> GetByNameOrLastnameAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<User?>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
