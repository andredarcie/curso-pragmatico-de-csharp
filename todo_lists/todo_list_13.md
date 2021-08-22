dotnet ef migrations add InitialCreate
docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 postgres
dotnet ef database update