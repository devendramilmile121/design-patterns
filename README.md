# Design Patterns (.NET 8 Solution) 

This repository demonstrates the implementation of common design patterns in C# using .NET 8. The solution is organized into multiple projects to promote clean architecture and separation of concerns.

## Solution Structure

- **UI**: Console application entry point. Demonstrates usage of design patterns.
- **Application**: Application layer for business logic and services.
- **Domain**: Contains core domain entities and interfaces.
- **Infrastructure**: Implementation details, such as singletons, factories, data access, configuration management, and dependency injection.

## Implemented Design Patterns

### Singleton
#### Overview
The Singleton pattern ensures a class has only one instance and provides a global point of access to it. This is useful for shared resources like configuration settings.

#### Implementation
- `ConfigurationManager`: Thread-safe singleton implementation in `Infrastructure.Singleton.ConfigurationManager`.

#### Example Usage
```csharp
var config = ConfigurationManager.Instance;
Console.WriteLine($"[Singleton] Loaded config: {config.ConnectionString}");
```

#### Benefits
- Ensures a single instance throughout the application.
- Useful for shared resources.
- Thread-safe implementation prevents race conditions.

### Factory
#### Overview
The Factory pattern provides a way to create objects without specifying the exact class of object that will be created. It promotes loose coupling and scalability.

#### Implementation
- Factories in `Infrastructure.Factory` create notification objects (e.g., Email, SMS) via `EmailFactory` and `SMSFactory`.
- Notification types implement the `INotification` interface.

#### Example Usage
```csharp
var emailFactory = new EmailFactory();
var email = emailFactory.CreateNotification();
email.Send("Your appointment is scheduled.");

var smsFactory = new SMSFactory();
smsFactory.CreateNotification().Send("Your appointment is started.");
```
#### Benefits
- Decouples object creation from usage.
- Easily extendable for new notification types.
- Promotes the Open/Closed Principle.

### Dependency Injection
#### Overview
Dependency Injection (DI) is a technique for achieving loose coupling between objects and their dependencies. It allows dependencies to be injected at runtime rather than hardcoded.

#### Implementation
- `SimpleContainer` in `Infrastructure.DI` provides basic DI functionality.
- Demonstrates constructor injection by resolving and injecting dependencies (e.g., `IRepository<Patient>` into `IPatientService`).

#### Example Usage
```csharp
var container = new SimpleContainer();
var repo = new PatientRepository();
container.RegisterInstance<IRepository<Patient>>(repo);
container.Register<IPatientService, SimplePatientService>();
var patientService = container.Resolve<IPatientService>();
patientService.Register(new Patient { Id = 1, Name = "John Deo", InsuranceProvider = "IH" });
```

#### Benefits
- Promotes loose coupling and testability.
- Simplifies object creation and dependency management.
- Makes it easier to swap implementations for testing or extension.

### Strategy Design Pattern

#### Overview
The Strategy pattern enables selecting an algorithm's behavior at runtime. It defines a family of algorithms, encapsulates each one, and makes them interchangeable. This promotes the Open/Closed Principle and allows the behavior to be changed without modifying the client code.

#### Implementation
- `IBillingStrategy`: Interface for billing calculation.
- `InsuredBilling`: Calculates bill for insured patients.
- `UninsuredBilling`: Calculates bill for uninsured patients.

#### Example Usage
```csharp
IBillingStrategy insured = new InsuredBilling();
Console.WriteLine($"[Strategy] Insured bill for $1000: {insured.CalculateBill(1000):C}");
IBillingStrategy uninsured = new UninsuredBilling();
Console.WriteLine($"[Strategy] Uninsured bill for $1000: {uninsured.CalculateBill(1000):C}");
```

#### Benefits
- Easily add new billing strategies without changing existing code.
- Promotes separation of concerns and testability.

### Observer Design Pattern

#### Overview
The Observer pattern allows objects (observers) to subscribe to and receive notifications from another object (subject) when its state changes. This promotes loose coupling and event-driven programming.

#### Implementation
- `AppointmentNotifier` in `Infrastructure.Observer` exposes an `AppointmentUpdated` event.
- Observers subscribe to this event and are notified via the `Notify` method.

#### Example Usage
```csharp
var notifier = new AppointmentNotifier();
notifier.AppointmentUpdated += msg => Console.WriteLine($"[Observer] Listener1: {msg}");
notifier.AppointmentUpdated += msg => Console.WriteLine($"[Observer] Listener2: {msg}");
notifier.Notify($"Appointment for {patient.Name} scheduled on {appointment.Date:d}.");
```

#### Benefits
- Decouples the subject from its observers.
- Supports multiple listeners for the same event.
- Promotes event-driven architecture and scalability.

### Command Design Pattern

#### Overview
The Command pattern encapsulates a request as an object, thereby allowing for parameterization of clients with queues, requests, and operations. It also provides support for undoable operations and logging.

#### Implementation
- `ICommand` interface in `Application.Commands` defines the contract for command execution.
- `CreateAppointmentCommand` in `Infrastructure.Command` implements the `ICommand` interface and encapsulates the logic for creating an appointment.

#### Example Usage
```csharp
ICommand createAppointment = new CreateAppointmentCommand(appointment);
createAppointment.Execute();
```

#### Benefits
- Decouples the object that invokes the operation from the one that knows how to perform it.
- Supports undo/redo functionality and logging.
- Makes it easy to add new commands without changing existing code.

### Decorator Design Pattern

#### Overview
The Decorator pattern allows behavior to be dynamically added to individual objects without affecting the behavior of other objects from the same class. It promotes flexibility by enabling runtime composition of features.
In the billing context, the decorator pattern allows adding additional functionality (like discounts) to billing objects without modifying their existing structure.

#### Implementation
- `IBilling`: Defines the contract for billing operations.
- `BasicBilling`: Provides the base billing implementation.
- `DiscountBillingDecorator`: Adds discount behavior by wrapping an existing IBilling instance.

#### Example Usage
```csharp
IBilling basic = new BasicBilling(500);
IBilling discounted = new DiscountBillingDecorator(basic);
Console.WriteLine($"[Decorator] Basic: {basic.GetAmount():C}, Discounted: {discounted.GetAmount():C}");
```

#### Benefits
- Extends object behavior without modifying existing code.
- Supports composition over inheritance.
- Promotes flexibility and adherence to the Open/Closed Principle.

### Chain of Responsibility Design Pattern

#### Overview
The Chain of Responsibility pattern passes a request along a chain of handlers where each handler decides either to process the request or to pass it to the next handler in the chain. This removes tight coupling between the sender and specific receivers and makes the request processing pipeline easy to extend or reorder.

#### Implementation
- `ApprovalHandler`: Abstract base defining `SetNext(ApprovalHandler)` and `Handle(Patient)` to build the chain and process the request.
- `InsuranceCheckHandler`: Verifies whether a `Patient` has an `InsuranceProvider`. If the check passes, forwards to the next handler.
- `DoctorApprovalHandler`: Simulates a doctor approval step and forwards to the next handler, if any.

#### Example Usage
```csharp
// Build the chain
var insuranceCheckHandler = new InsuranceCheckHandler();
var doctorApprovalHandler = new DoctorApprovalHandler();
insuranceCheckHandler.SetNext(doctorApprovalHandler);

// Execute the chain
insuranceCheckHandler.Handle(patient);
```

#### Benefits
- Decouples request sender from concrete handlers.
- Flexible runtime composition and reordering of steps.
- Easy to add new approval steps without modifying existing handlers (Open/Closed Principle).
- Reduces complex conditional logic by splitting responsibilities across handlers.

---

For more details, see the source files in their respective folders and usage in `UI/Program.cs`.

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later / VS Code

## Build and Run

1. Clone the repository:
   ```sh
   git clone https://github.com/devendramilmile121/design-patterns.git
   cd design-patterns
   ```
2. Build the solution:
   ```sh
   dotnet build
   ```
3. Run the UI project:
   ```sh
   dotnet run --project UI/UI.csproj
   ```

## Contributing
Feel free to fork the repository and submit pull requests for improvements or new design pattern examples.

## License
This project is licensed under the MIT License.
