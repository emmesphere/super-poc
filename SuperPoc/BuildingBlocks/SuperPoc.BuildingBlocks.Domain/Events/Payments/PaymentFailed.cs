namespace SuperPoc.BuildingBlocks.Domain.Events.Payments
{
    public record PaymentFailed(Guid PaymentId, Guid OrderId, string Reason) : DomainEvent;

}
