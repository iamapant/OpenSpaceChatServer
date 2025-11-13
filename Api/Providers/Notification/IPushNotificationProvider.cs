using Api.Database.Models;
using Api.DTO;

namespace Api.Providers.Notification;

public interface IPushNotificationProvider {
    void RegisterUser(Guid userId);
    void UnregisterUser(Guid userId);
    Task<ValidationResult> SendNotification(NotificationMessage message, params Guid[] userIds);
}

public abstract record NotificationMessage(string Message);
public abstract record MessageReceived(string Message, MessageMetadata metadata) : NotificationMessage(Message);
public record PublicMessageReceived(string Message, MessageMetadata metadata) : MessageReceived(Message, metadata);
public record PrivateMessageReceived(string Message, MessageMetadata metadata) :  MessageReceived(Message, metadata);
