namespace SuperPoc.BuildingBlocks.Domain.Events
{
    public abstract record DomainEvent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime OccuredOn { get; init; } = DateTime.UtcNow;
    }
}
