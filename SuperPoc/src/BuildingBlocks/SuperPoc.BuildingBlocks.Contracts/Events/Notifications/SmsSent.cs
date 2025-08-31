namespace SuperPoc.BuildingBlocks.Contracts.Events.Notifications
{
    public record SmsSent(Guid NotificationId, string PhoneNumber, string Message, DateTime SentAtUtc);
}
