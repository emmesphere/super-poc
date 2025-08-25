using SuperPoc.BuildingBlocks.Contracts.Enums;

namespace SuperPoc.BuildingBlocks.Contracts.Events.Payments
{
    public record PaymentProcessed(Guid PaymentId, Guid OrderId, decimal Amount, PaymentMethod Method, DateTime ProcessedAtUtc);


}
