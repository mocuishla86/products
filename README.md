# products

If you get a "Your connection is not private", follow [these instructions](https://stackoverflow.com/a/44126123).



Architecture: Hexagonal.
- For this specifc example, perhaps a bit overkilling, but just to show that Iknow it . 
- One project for API (starts the application and wires dependencies)
- One project for domain (Project class)
- One project for application layer (use cases)
- One project for persistence (spefic adapter for output port). 

TODO: Include diagram. 
TODO: Validation? For example, name should be filled, not repeated, etc. 


# how to run

- Docker must be installed.


Start Sql Server container

```shell
docker-compose up -d
```

Stop sql container

```shell
docker-compose down
```

Install EF Globally

```shell
dotnet tool install --global dotnet-ef --version 8.*
````

Apply all migrations:

```shell
dotnet ef database update --project ProductsSqlServer/ProductsSqlServer.csproj --startup-project ProductsAPI/ProductsAPI.csproj  --context ProductsSqlServer.Context.AppDbContext
```


# how to add migrations

From root:

```shell
dotnet ef migrations add Initial --project ProductsSqlServer/ProductsSqlServer.csproj --startup-project ProductsAPI/ProductsAPI.csproj --context ProductsSqlServer.Context.AppDbContext
````

# Sources

  - [Functional tests](https://ilovedotnet.org/blogs/functional-testing-your-asp-net-webapi/)
  - [Test containers](https://medium.com/codenx/integration-testing-using-testcontainers-in-net-8-520e8911d081)
  - [Docker-compose and SqlServer](https://samuelbarrerabastidas.medium.com/ms-sql-server-con-docker-compose-2a3213266be3)
  - [Entity Framework](https://medium.com/@lucas.and227/step-by-step-guide-to-entity-framework-in-net-c629faf9f322)