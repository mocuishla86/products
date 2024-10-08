using Microsoft.EntityFrameworkCore;
using ProductsApplication.Inbound;
using ProductsApplication.Outbound;
using ProductsSqlServer.Context;
using ProductsSqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<GetAllProductsUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<DeleteProductByIdUseCase>();
builder.Services.AddScoped<IProductRepository, SqlServerProductRepository>();
builder.Services.AddScoped<IOrderRepository, SqlServerOrderRepository>();

if(!"Test".Equals(builder.Environment.EnvironmentName))
{
    var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProductsSqlServer")));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public partial class Program { }
