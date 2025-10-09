# Design Patterns (.NET 8 Solution)

This repository demonstrates the implementation of common design patterns in C# using .NET 8. The solution is organized into multiple projects to promote clean architecture and separation of concerns.

## Solution Structure

- **UI**: Console application entry point. Demonstrates usage of design patterns.
- **Application**: Application layer for business logic and services.
- **Domain**: Contains core domain entities and interfaces.
- **Infrastructure**: Implementation details, such as singletons, data access, and configuration management.

## Example Pattern: Singleton
The solution includes a thread-safe Singleton implementation in `Infrastructure.Singleton.ConfigurationManager`.

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
