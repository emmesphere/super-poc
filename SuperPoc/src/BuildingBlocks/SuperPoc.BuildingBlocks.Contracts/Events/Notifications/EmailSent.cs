namespace SuperPoc.BuildingBlocks.Contracts.Events.Notifications
{
    public record EmailSent(Guid NotificationId, string Recipient, string Subject, DateTime SentAtUtc);
}
