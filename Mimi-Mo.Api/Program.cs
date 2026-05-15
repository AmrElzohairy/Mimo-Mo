using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mimo_Mo.Application.Features.Common.Behavior;
using Mimo_Mo.Application; 
using Mimi_Mo.Api.Middlewares;
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
        builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationAssemblyReference).Assembly));
        
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        // ============================================================
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseExceptionHandler();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}