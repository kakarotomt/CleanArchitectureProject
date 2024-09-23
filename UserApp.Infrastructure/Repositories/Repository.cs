using Microsoft.EntityFrameworkCore;
using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users;

namespace UserApp.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken )
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(Guid id)
        {
            _context.Remove(id);
        }

        public void Update(T user)
        {
            _context.Update(user);
        }
    }
}
