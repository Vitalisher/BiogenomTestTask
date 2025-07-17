using BiogenomNutrition.Application.Services;
using BiogenomNutrition.Domain.Interfaces;
using BiogenomNutrition.Infrastructure.Data;
using BiogenomNutrition.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Nutrition.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();

        builder.Services.AddDbContext<NutritionDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddTransient<INutritionReportRepository, NutritionReportRepository>();
        builder.Services.AddTransient<INutritionReportService, NutritionReportService>();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
      
        app.UseRouting();
        app.MapControllers();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        app.Run();
    }
}