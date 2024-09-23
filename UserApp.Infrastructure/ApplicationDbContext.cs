using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Abstractions;

namespace UserApp.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {

        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var res = await base.SaveChangesAsync(cancellationToken);
                await PublishDomainEventAsync();
                return res;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbUpdateConcurrencyException("Error en concurrencia", ex);
            }
        }

        private async Task PublishDomainEventAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(m => m.Entity)
                .SelectMany(e =>
                {
                    var domainEvents = e.GetDomainEvents();
                    e.ClearDomainEvents();
                    return domainEvents;
                });
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);

            }
        }
    }
}
