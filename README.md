# MIM Loan Application Portal

This project is a web application portal for managing loan applications, built with Blazor Server and backed by a .NET 9, Entity Framework Core and a MySQL database. It provides a platform for users to apply for loans and for administrators to manage the application process.

## Installation and Setup

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (running locally or in Docker)

### 1. Clone the Repository:

```bash
git clone https://github.com/IEdiong/MIMLoan.git
cd MIMLoan
```

### 2. Setup User-Secrets:

The application uses dotnet User-Secrets to manage secrets during development. You need to set the database configuration string by running the following commands:

```bash
dotnet user-secrets -p src/MimLoan.Web/ init

dotnet user-secrets -p src/MimLoan.Web/ set "ConnectionStrings:DefaultConnection" "server=localhost;user=root;password=your-db-password;database=MIMLoanDb"

```

Run this next command to see that the secret has been added successfully:

```bash
dotnet user-secrets -p src/MimLoan.Web/ list
```

### 3. Apply Migrations (Automatically on Startup):

The application is configured to run:

```csharp
 using (var scope = app.Services.CreateScope())
 {
     var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
     dbContext.Database.Migrate();
 }
```

This ensures that the MySQL database and required tables are created when the application starts.

### 4. Run the Application:

```bash
dotnet run --project src/MimLoan.Web
```

Once running, navigate to `http://localhost:5226` (or the configured port) to access the Blazor application.
