
# Instructions - DOCKER 


1**Run Docker Compose**: Open a terminal and navigate to the directory where your `docker-compose.yml` file is located. Run the following command to start your services:

    ```bash
    docker-compose up -d
    ```

2**Access SQL Server**: You can access SQL Server using your favorite SQL client with the connection string:

    ```plaintext
    Server=localhost;Database=dasigno;User Id=sa;Password=Password1234;TrustServerCertificate=true;
    ```

This will set up a SQL Server instance in a Docker container for your Dasigno project.



# Creating Migrations in .NET Core with Entity Framework (EF)

This guide explains how to create Entity Framework (EF) Core migrations for the `Dasigno` project using `dotnet ef` commands.

## Prerequisites

Before creating migrations, ensure that the following prerequisites are met:

1. **EF Core Tools**: Make sure you have installed the EF Core CLI tools. You can install it globally by running:

    ```bash
    dotnet tool install --global dotnet-ef
    ```

2. **Valid Configuration**: Ensure your connection strings and DbContext configurations are set up correctly in the `appsettings.json` and in your DI container.

## Steps to Create a Migration

### 1. Navigate to the Project Root

Open a terminal or command prompt and navigate to the root of your solution where the `.sln` file is located.

### 2. Create a Migration

Run the following command to create a new migration. This example assumes you want to create the initial migration for the `UserContext` DbContext.

```bash
dotnet ef migrations add --project "Infrastructure/Dasigno.Infrastructure.Persistence/Dasigno.Infrastructure.Persistence.csproj" \\
    --startup-project "Presentation/Dasigno.User.Api/Dasigno.User.Api.csproj" \\
    --context "Dasigno.Infrastructure.Persistence.Context.UserContext" \\
    --configuration Debug Initial --output-dir Migrations
  ```


# Update the Database
Once you have created the migration, you can apply it to the database by running the following command:

```bash
dotnet ef database update --project "Infrastructure/Dasigno.Infrastructure.Persistence/Dasigno.Infrastructure.Persistence.csproj" \\
    --startup-project "Presentation/Dasigno.User.Api/Dasigno.User.Api.csproj"
  ```