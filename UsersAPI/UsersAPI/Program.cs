using Microsoft.EntityFrameworkCore;
using UsersAPI.Database.Context;
using UsersAPI.Database.Validators;

namespace UsersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabaseContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add validator
            builder.Services.AddScoped<UserInputValidator>();

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

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}