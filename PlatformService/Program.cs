using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Data.Repository;
using PlatformService.Data.Seeder;
using PlatformService.HttpClients;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDBContext>(opt =>
            {
                opt.UseInMemoryDatabase("PlatformDB");
            });
            builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpClient<ICommandHttpClient,CommandHttpClient>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            SeedData.PopulateDb(app);
            app.Run();
        }
    }
}
