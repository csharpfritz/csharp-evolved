using System;

public sealed class NotificationService
{
    public void Send(string recipient, string subject, string body, bool highPriority, bool saveCopy)
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
            "team@contoso.com",
            "Deployment complete",
            "The new release is live.",
            true,
            false);
    }
}
