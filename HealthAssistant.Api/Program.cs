using HealthAssistant.Application.Others.Mappers;
using HealthAssistant.Application.UseCases.Products.Commands.CreateProduct;
using HealthAssistant.Application.UseCases.Products.Commands.DeleteProduct;
using HealthAssistant.Application.UseCases.Products.Commands.UpdateProduct;
using HealthAssistant.Application.UseCases.Products.Queries.GetAllProducts;
using HealthAssistant.Application.UseCases.Products.Queries.GetByName;
using HealthAssistant.Domain.Abstractions;
using HealthAssistant.Domain.Entities;
using HealthAssistant.Infrastructure;
using HealthAssistant.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HealthAssistantDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("HealthAssistantDbContext"));
});

builder.Services.AddAutoMapper(typeof(CreateProductCommandToProduct));
builder.Services.AddAutoMapper(typeof(UpdateProductCommandToProduct));
builder.Services.AddAutoMapper(typeof(ProductToProductDto));



builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteProductCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductByNameQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQueryHandler).Assembly));

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
