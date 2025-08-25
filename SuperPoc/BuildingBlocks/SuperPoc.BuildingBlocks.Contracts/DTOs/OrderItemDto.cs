namespace SuperPoc.BuildingBlocks.Contracts.DTOs
{
    public record OrderItemDto(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity);
}
