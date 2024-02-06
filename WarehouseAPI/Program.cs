using FluentValidation.AspNetCore;
using Serilog;
using WarehouseAPI.Middleware;
using WarehouseBAL.Interfaces;
using WarehouseBAL.Services;
using WarehouseBAL.Validators;
using WarehouseDAL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IWorkerService, WorkerService>();
builder.Services.AddTransient<IWorkerDepartmentService, WorkerDepartmentService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DepartmentDTOValidator>())
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductDTOValidator>())
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<WorkerDTOValidator>())
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<WorkerDepartmentDTOValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
