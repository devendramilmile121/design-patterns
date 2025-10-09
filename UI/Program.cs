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
    }
}

