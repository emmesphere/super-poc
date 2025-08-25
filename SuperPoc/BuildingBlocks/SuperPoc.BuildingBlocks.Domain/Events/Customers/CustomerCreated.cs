namespace SuperPoc.BuildingBlocks.Domain.Events.Customers
{
    public record CustomerCreated(Guid CustomerId, string Name, string Email) : DomainEvent;
}
