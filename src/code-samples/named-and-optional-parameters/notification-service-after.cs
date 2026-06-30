using System;

public sealed class NotificationService
{
    public void Send(
        string recipient,
        string subject,
        string body,
        bool highPriority = false,
        bool saveCopy = true)
    {
        Console.WriteLine("To: " + recipient);
        Console.WriteLine("Subject: " + subject);
        Console.WriteLine(
            string.Format(
                "Priority: {0} | Save copy: {1}",
                highPriority ? "high" : "normal",
                saveCopy));
        Console.WriteLine(body);
    }
}

public static class Program
{
    public static void Main()
    {
        var service = new NotificationService();
        service.Send(
            recipient: "team@contoso.com",
            subject: "Deployment complete",
            body: "The new release is live.",
            highPriority: true,
            saveCopy: false);
    }
}
