using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Mimo_Mo.Core.Interfaces;
using Mimo_Mo.Infrastructure.Data;
using Mimo_Mo.Infrastructure.Repositories;

namespace Mimi_Mo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        // 3. تسجيل الـ MediatR (CQRS)
        // بنخليه يعمل سريالايز/Scan للـ Assembly اللي فيها الـ Command بتاعنا عشان يلقط كل الـ Handlers تلقائياً
        var applicationAssembly = typeof(Mimo_Mo.Application.Features.Products.Commands.CreateProductCommand).Assembly;
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        // 4. تسجيل الـ AutoMapper
        // بيعمل Scan للـ Profiles اللي في طبقة الـ Application
        builder.Services.AddAutoMapper(cfg => {}, applicationAssembly);

        // 5. تسجيل الـ FluentValidation
        // بيسجل كل الـ Validators (زي الـ CreateProductCommandValidator) اللي في الـ Application تلقائياً
        builder.Services.AddValidatorsFromAssembly(applicationAssembly);

        // ============================================================
        
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
    }
}