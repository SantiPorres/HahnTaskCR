## Dotnet Secrets Documentation .NET 9
https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux

## Commands

### Install dotnet EF Core CLI
```bash
dotnet tool install --global dotnet-ef
```

### Create migrations
```bash
dotnet ef migrations add InitialMigration --project Persistence --startup-project WebAPI
```

### Run migrations
```bash
dotnet ef database update --project Persistence --startup-project WebAPI
```

## SQL Server

### Pull image
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

### Create volume
```bash
docker volume create sql-server-data
```

### Run container
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MyStrongPassword123" -p 1433:1433 -v sql-server-data:/var/opt/mssql mcr.microsoft.com/mssql/server:2022-latest
```