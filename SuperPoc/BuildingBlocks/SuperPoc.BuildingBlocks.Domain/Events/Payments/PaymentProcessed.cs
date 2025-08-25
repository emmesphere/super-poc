using SuperPoc.BuildingBlocks.Domain.Enums;

namespace SuperPoc.BuildingBlocks.Domain.Events.Payments
{
    public record PaymentProcessed(Guid PaymentId, Guid OrderId, decimal Amount, PaymentMethod PaymentMethod) : DomainEvent;

}
