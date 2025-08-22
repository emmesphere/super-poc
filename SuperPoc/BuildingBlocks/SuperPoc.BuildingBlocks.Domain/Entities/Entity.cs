using SuperPoc.BuildingBlocks.Domain.Events;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent) =>
            _domainEvents.Add(domainEvent);

        public void ClearDomainEvents() => _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator == (Entity a, Entity b) => Equals(a, b);
        public static bool operator != (Entity a, Entity b) => !Equals(a, b);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
