using SuperPoc.BuildingBlocks.Domain.Events;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        private readonly List<DomainEvent> _domainEvents = new();

        protected AggregateRoot() { }

        protected AggregateRoot(TId id) : base(id) { }

        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
