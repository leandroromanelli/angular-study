using MeetingService.Contexts;
using MeetingService.Interfaces.Services;
using MeetingService.Interfaces.UnitiesOfWork;
using MeetingService.Services;
using MeetingService.UnitiesOfWork;
using Examroom.SSV3.Microservices.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeetingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();
            builder.Services.AddCors();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Meeting Service",
                        Version = "v1"
                    });
            });

            builder.Services.AddDbContext<Context>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("DummyData"));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IParticipantRoleService, ParticipantRoleService>();
            builder.Services.AddScoped<IScenarioService, ScenarioService>();

            builder.Services.AddSingleton(new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var app = builder.Build();

            app.UseRouting();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                       .WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting Service");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotifyHub>("/notify");
            });

            app.Run();
        }
    }
}