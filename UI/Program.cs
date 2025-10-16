using Application.Commands;
using Application.Interfaces;
using Application.Services;
using Application.Strategy;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Command;
using Infrastructure.Chain;
using Infrastructure.Decorator;
using Infrastructure.DI;
using Infrastructure.Factory;
using Infrastructure.Observer;
using Infrastructure.Repositories;
using Infrastructure.Singleton;
using static System.Net.Mime.MediaTypeNames;

namespace UI;

internal class Program
{
    static void Main(string[] args)
    {
        // Domain entities
        var patient = new Patient { Id = 1, Name = "John Doe", InsuranceProvider = "HealthPlus" };
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialty = "Cardiology" };
        var appointment = new Appointment { Id = 1, Patient = patient, Doctor = doctor, Date = DateTime.Now.AddDays(1) };

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
        patientService.Register(patient);
        Console.WriteLine("====== Dependency Injection Design Pattern End ======\n");

        Console.WriteLine("====== Strategy Design Pattern Start ======");
        IBillingStrategy insured = new InsuredBilling();
        Console.WriteLine($"[Strategy] Insured bill for $1000: {insured.CalculateBill(1000):C}");
        IBillingStrategy uninsured = new UninsuredBilling();
        Console.WriteLine($"[Strategy] Insured bill for $1000: {uninsured.CalculateBill(1000):C}");
        Console.WriteLine("====== Strategy Design Pattern End ======\n");

        Console.WriteLine("====== Observer Design Pattern Start ======");
        var notifier = new AppointmentNotifier();
        notifier.AppointmentUpdated += msg => Console.WriteLine($"[Observer] Listener1: {msg}");
        notifier.AppointmentUpdated += msg => Console.WriteLine($"[Observer] Listener2: {msg}");
        notifier.Notify($"Appointment for {patient.Name} scheduled on {appointment.Date:d}.");
        Console.WriteLine("====== Observer Design Pattern End ======\n");

        Console.WriteLine("====== Observer Design Pattern Start ======");
        ICommand createAppointment = new CreateAppointmentCommand(appointment);
        createAppointment.Execute();
        Console.WriteLine("====== Observer Design Pattern End ======\n");

        Console.WriteLine("====== Observer Design Pattern Start ======");
        IBilling basic = new BasicBilling(500);
        IBilling discounted = new DiscountBillingDecorator(basic);
        Console.WriteLine($"[Decorator] Basic: {basic.GetAmount():C}, Discounted: {discounted.GetAmount():C}");
        Console.WriteLine("====== Observer Design Pattern End ======\n");

        Console.WriteLine("====== Chain of Responsibility Design Pattern Start ======");
        var insuranceCheckHandler = new InsuranceCheckHandler();
        var doctorApprovalHandler = new DoctorApprovalHandler();
        insuranceCheckHandler.SetNext(doctorApprovalHandler);
        insuranceCheckHandler.Handle(patient);
        Console.WriteLine("====== Chain of Responsibility Design Pattern End ======\n");
    }
}

