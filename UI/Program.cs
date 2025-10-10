using Infrastructure.Factory;
using Infrastructure.Singleton;

namespace UI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("====== Singleton Design Pattern Start ======\n");
        var config = ConfigurationManager.Instance;
        Console.WriteLine($"[Singleton] Loaded config: {config.ConnectionString}\n");
        Console.WriteLine("====== Singleton Design Pattern End ======\n");

        Console.WriteLine("====== Factory Design Pattern Start ======\n");
        var emailFactory = new EmailFactory();
        var email = emailFactory.CreateNotification();
        email.Send($"Your appointment is schedule at {DateTime.UtcNow.AddMinutes(-10).ToString()}");
        var smsFactory = new SMSFactory();
        var sms = smsFactory.CreateNotification();
        sms.Send($"Your appointment is Started at {DateTime.UtcNow.ToString()}");
        Console.WriteLine("====== Factory Design Pattern End ======\n");
    }
}

