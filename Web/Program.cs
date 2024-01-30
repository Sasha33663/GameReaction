using Application;
using Infrastructure.Repositories;
using Infrastructure.Repositories.GameRepository;
using Infrastructure.Rerositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace Web
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
            builder.Services.AddDbContext<Database>((options) => options.UseNpgsql("Server=localhost;Port=5432;Database=GameReactions; UserId=postgres;Password=Batonbatonbaton123;"));
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IGameRepository, GameRepository>();
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