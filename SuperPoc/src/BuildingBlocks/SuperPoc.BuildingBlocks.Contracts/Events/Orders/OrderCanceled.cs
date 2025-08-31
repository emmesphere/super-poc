namespace SuperPoc.BuildingBlocks.Contracts.Events.Orders
{
    public record OrderCanceled(Guid OrderId, Guid CustomerId, string Reason, DateTime CanceledAtUtc);
}
