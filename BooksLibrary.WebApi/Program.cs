using BooksLibrary.Persistence;
using System.Reflection;
using BooksLibrary.Application.Command.Mapping;
using BooksLibrary.Application;
using BooksLibrary.Application.Interfaces;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using BooksLibrary.WebApi.Middleware;

internal class Program
{


    private static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        ConfigurationManager configuration = builder.Configuration;



        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IBooksDbContext).Assembly));
        });

   



        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(BooksLibrary.Application.DependencyInjection).Assembly);
        });

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });



        builder.Services.AddApplication();
        builder.Services.AddPersistence(configuration);
        builder.Services.AddControllers();


        var app = builder.Build();

        app.UseCustomExceptionHandler();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<BooksLibDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception exception)
            {

            }
        }

        app.UseRouting();
        app.UseCors("AllowAll");

        app.UseEndpoints(p =>
        {
            p.MapControllers();
        });




        app.Run();
    }
}