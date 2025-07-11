
// Program.cs: Entry point for the EshopApp API application.
// Configures services, dependency injection, middleware, and endpoints for the ASP.NET Core Web API.
// Sets up database context, repositories, use cases, Swagger, and controller routing.
using EshopApp.Application.Interfaces;
using EshopApp.Application.UseCase;
using EshopApp.Infrastructure.Repositories;
using EshopApp.Persistence;
using Microsoft.EntityFrameworkCore;
using EshopApp.Application.UseCases;
using EshopApp.Infrastructure.EFCore.UnitOfWork;
using EshopApp.Application.UseCase.Invoice;



// Create a WebApplication builder instance
var builder = WebApplication.CreateBuilder(args);


// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository and use case services to the DI container
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductQueryHelper, ProductQueryHelper>();






builder.Services.AddScoped<GetInvoicesUseCase>();
builder.Services.AddScoped<CreateInvoiceUseCase>();
builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<CreateCategoryUseCase>();
builder.Services.AddScoped<GetCategoriesUseCase>();
builder.Services.AddScoped<GetCustomersUseCase>();
builder.Services.AddScoped<GetProductsUseCase>();
builder.Services.AddScoped<DeleteCategoryUseCase>();
builder.Services.AddScoped<DeleteInvoiceItemUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();
builder.Services.AddScoped<DeleteInvoiceUseCase>();
builder.Services.AddScoped<UpdateCategoryUseCase>();
builder.Services.AddScoped<UpdateCustomerUseCase>();
builder.Services.AddScoped<UpdateInvoiceItemUseCase>();
builder.Services.AddScoped<UpdateInvoiceUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<RegisterUserByAdminUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<GetStoreInfoUseCase>();
builder.Services.AddScoped<UpdateStoreInfoUseCase>();
builder.Services.AddScoped<CreateStoreInfoUseCase>();
builder.Services.AddScoped<GetUserUseCase>();
builder.Services.AddScoped<GetFilteredInvoicesUseCase>();
builder.Services.AddScoped<GetCustomerTotalInvoiceUseCase>();
builder.Services.AddScoped<GetInvoiceItemsByInvoiceIdUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<AssignProductToCategoryUseCase>();









// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Build the WebApplication
var app = builder.Build();


// Enable authorization and map controller routes
app.UseAuthorization();
app.MapControllers();



// Configure the HTTP request pipeline for development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


// Example endpoint for weather forecast (for demonstration purposes)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// Start the application
app.Run();

// WeatherForecast record for the example endpoint
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
