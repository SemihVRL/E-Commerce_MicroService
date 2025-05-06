using E_Commerce.Catalog.Services.CategoryServices;
using E_Commerce.Catalog.Services.ProductDetailServices;
using E_Commerce.Catalog.Services.ProductImageServices;
using E_Commerce.Catalog.Services.ProductServices;
using E_Commerce.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container,

//ctor i�in konfigrasyonlar�
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductServiceImage>();

//auto mapper i�in konfigrasyon
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//appsettings i�in konfigrasyon

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

//database setting i�indeki de�erlere ula��cak
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
