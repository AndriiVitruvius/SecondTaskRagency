using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BooksLibrary.Application.Interfaces;

namespace BooksLibrary.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BooksLibDbContext>(options =>
            {
                options.UseSqlite(connectionString);

            });

            services.AddScoped<IBooksDbContext>(provider => provider.GetService<BooksLibDbContext>());

            return services;
        }


    }
}
