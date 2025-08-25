namespace SuperPoc.BuildingBlocks.Contracts.Events.Payments
{
    public record PaymentFailed(Guid PaymentId, Guid OrderId, string Reason, DateTime FailedAtUtc);


}
