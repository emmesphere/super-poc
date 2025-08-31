using SuperPoc.BuildingBlocks.Contracts.Enums;

namespace SuperPoc.BuildingBlocks.Contracts.DTOs
{
    public record NotificationDto(Guid Id, NotificationType Type, string Recipient, string Message, DateTime SentAtUtc);
}
