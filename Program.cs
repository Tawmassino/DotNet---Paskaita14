
using Microsoft.EntityFrameworkCore;
using Paskaita14.BusinessLogic;
using Paskaita14.DataLayer;

namespace Paskaita14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ShoppingListDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
                });

            builder.Services.AddScoped<IDbRepository, DbRepository>();
            builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
            builder.Services.AddScoped<IShoppingListMapper, ShoppingListMapper>();

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
}
