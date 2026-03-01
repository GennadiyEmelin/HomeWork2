
using HomeWork2.Data;
using HomeWork2.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace HomeWork2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IProductRepository, ProductsRepository>();
            builder.Services.AddSingleton<ICartsRepository, CartsRepository>();
            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("SqLiteConnection"));
            });

            var app = builder.Build();

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
}
