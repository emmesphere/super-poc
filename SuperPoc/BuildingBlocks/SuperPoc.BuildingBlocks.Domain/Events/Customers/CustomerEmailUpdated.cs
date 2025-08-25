namespace SuperPoc.BuildingBlocks.Domain.Events.Customers
{

    public record CustomerEmailUpdated(Guid CustomerId, string OldEmail, string NewEmail) : DomainEvent;
}
