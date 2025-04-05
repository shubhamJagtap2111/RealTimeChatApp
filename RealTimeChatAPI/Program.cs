
using Microsoft.EntityFrameworkCore;
using RealTimeChatAPI.Business;
using RealTimeChatAPI.Data;
using RealTimeChatAPI.Hubs;
using RealTimeChatAPI.Repositories;
using RealTimeChatAPI.Service;

namespace RealTimeChatAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Dependency Injection
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<IChatManager, ChatManager>();
            builder.Services.AddScoped<IChatService, ChatService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<ChatHub>("/chathub");

            app.Run();
        }
    }
}
