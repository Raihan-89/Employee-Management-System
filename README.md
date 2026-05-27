# Employee Management System

A comprehensive web application for managing employee data, leave requests, salaries, and tasks. Built with .NET 8.0 ASP.NET Core MVC and styled with the AdminLTE template.

## Features

### Admin Module
- **Dashboard:** Overview of the system.
- **User Management:** Register and manage application users.
- **Employee Management:** Full CRUD operations for employee records.
- **Salary Management:** Track and update employee salary details.
- **Leave Management:** 
  - Define Leave Types.
  - Review and manage Leave Applications.

### Manager Module
- **Dashboard:** Manager-specific overview.
- **Employee Oversight:** Access to employee information relevant to the manager.
- **Task Management:** Assign and track tasks for employees.

## Tech Stack
- **Framework:** .NET 8.0 (ASP.NET Core MVC)
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **UI Template:** [AdminLTE 3.2.0](https://adminlte.io/)
- **Authentication:** Custom authentication logic with ASP.NET Core Identity integration.

## Project Structure
- `Controllers/`: Handles incoming requests and coordinates logic between Models and Views.
- `Models/`: Contains data structures and business entities (Employee, Manager, Salary, etc.).
- `Views/`: Razor views for the user interface, organized by controller and module (Admin/Manager).
- `Data/`: Database context and migrations.
- `wwwroot/`: Static assets including CSS, JS, and the AdminLTE library.

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or Express)
- Visual Studio 2022 or VS Code

### Setup
1. Clone the repository.
2. Update the connection string in `appsettings.json` if necessary.
3. Run migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
4. Build and run the project:
   ```bash
   dotnet run
   ```

## License
This project is for educational purposes as part of the Web & Internet Programming Course.
