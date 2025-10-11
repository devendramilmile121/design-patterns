using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DI;
using Infrastructure.Factory;
using Infrastructure.Repositories;
using Infrastructure.Singleton;
using static System.Net.Mime.MediaTypeNames;

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

        Console.WriteLine("====== Dependency Injection Design Pattern Start ======");
        Console.WriteLine("There is nothing to see any output");
        Console.WriteLine("Add debugger while executing and go through code");
        var container = new SimpleContainer();
        var repo = new PatientRepository();
        container.RegisterInstance<IRepository<Patient>>(repo);

        // Register a simple implementation of IPatientService inline for demo
        container.Register<IPatientService, SimplePatientService>();
        var patientService = container.Resolve<IPatientService>();
        patientService.Register(new Patient { Id = 1, Name = "John Deo", InsuranceProvider = "IH" });
        Console.WriteLine("====== Dependency Injection Design Pattern End ======\n");
    }
}

