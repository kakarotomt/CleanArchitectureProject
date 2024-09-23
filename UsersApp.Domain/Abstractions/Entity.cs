using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _events = new();
        protected Entity()
        {
            
        }
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents() => _events; 
        public void ClearDomainEvents()=> _events.Clear();
        protected void RiseDomainEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);
    }
}
