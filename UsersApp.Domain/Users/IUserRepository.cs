using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<User?>> GetByNameOrAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<User?>> GetUsersAsync(CancellationToken cancellationToken = default);
        void Add(User user);
        void Update(User user);
        void Delete(Guid id);
    }
}
