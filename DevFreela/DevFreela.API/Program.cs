
using DevFreela.Infrastructure.Persistance;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DevFreelaDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });            

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ISkillService, SkillService>();

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
        }
    }
}
