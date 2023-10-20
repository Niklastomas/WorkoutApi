Create migrations
```
 dotnet ef migrations add {Migration name} --project .\Infrastructure\ --startup-project .\WebApi\WebApi.csproj -o .\Persistence\Migrations --context WorkoutDbContext
 ```


Update database
```
 dotnet ef database update --startup-project .\WebApi\WebApi.csproj --context WorkoutDbContext
```
