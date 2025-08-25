using SuperPoc.BuildingBlocks.Contracts.Enums;

namespace SuperPoc.BuildingBlocks.Contracts.DTOs
{
    public record OrderDto(Guid Id, Guid CustomerId, decimal TotalAmount, OrderStatus OrderStatus, DateTime CreatedAt, IReadOnlyList<OrderItemDto> Items);
}
