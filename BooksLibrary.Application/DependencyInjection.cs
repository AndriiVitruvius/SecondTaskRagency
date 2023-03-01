using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;
using FluentValidation;
using BooksLibrary.Application.Command.Behaviors;

namespace BooksLibrary.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));


            return services;

        }
    }
}
