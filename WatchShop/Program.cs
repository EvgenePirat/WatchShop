
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WatchShop_Core.DependencyResolvers;
using WatchShop_Infrastructure.DbContext;
using WatchShop_Infrastructure.DependencyResolvers;
using WatchShop_UI.DependencyResolve;
using WatchShop_UI.Utilities.Middleware.ExceptionsHandlers;

namespace WatchShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionBaseDate")));

            builder.Services.AddControllers();

            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                cors =>
                {
                    cors.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((_) => true)
                        .AllowCredentials();
                }));

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(
                containerBuilder => containerBuilder.RegisterModule(new BusinessModule()));

            builder.Host.ConfigureContainer<ContainerBuilder>(
                containerBuilder => containerBuilder.RegisterModule(new MappersModules()));

            builder.Host.ConfigureContainer<ContainerBuilder>(
                containerBuilder => containerBuilder.RegisterModule(new DataModule()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
