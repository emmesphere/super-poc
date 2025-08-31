using SuperPoc.BuildingBlocks.Domain.Events;

namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
        protected Entity() { }
        protected Entity(TId id) => Id = id;

        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public void MarkAsDeleted()
        {
            if (IsDeleted) return;

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        public static bool operator == (Entity<TId> a, Entity<TId> b) => Equals(a, b);
        public static bool operator != (Entity<TId> a, Entity<TId> b) => !Equals(a, b);

        public override int GetHashCode() => Id!.GetHashCode();
    }
}
