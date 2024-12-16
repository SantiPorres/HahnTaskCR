secrets documentation .net9:
https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux

ConnectionString Example
Server=localhost,1433;Database=CRapi;User Id=sa;Password=MyStrongPassword123;TrustServerCertificate=True;Encrypt=False;

Create migrations
dotnet ef migrations add InitialMigration --project Persistence --startup-project WebAPI

Run migrations
dotnet ef database update --project Persistence --startup-project WebAPI


SQL Server

Pull image
docker pull mcr.microsoft.com/mssql/server:2022-latest

Create volume
docker volume create sql-server-data

Run container
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MyStrongPassword123" -p 1433:1433 -v sql-server-data:/var/opt/mssql mcr.microsoft.com/mssql/server:2022-latest
