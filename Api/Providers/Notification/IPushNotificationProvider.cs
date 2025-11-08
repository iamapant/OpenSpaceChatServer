using Api.Database.Models;

namespace Api.Providers.Notification;

public interface IPushNotificationProvider {
    void RegisterUser(Guid userId);
    void UnregisterUser(Guid userId);
    Task<ValidationResult> SendNotification(NotificationMessage message, params Guid[] userIds);
}

public abstract record NotificationMessage(string Message);
public abstract record MessageReceived(User sender, string Message) : NotificationMessage(Message);
public record PublicMessageReceived(User sender, string Message) : MessageReceived(sender, Message);
public record PrivateMessageReceived(User sender, string Message) :  MessageReceived(sender, Message);