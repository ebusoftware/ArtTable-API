using ArtTableWeb.Application.Pipelines.Validation;
using ArtTableWeb.Application.Rules.Category;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());
            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            collection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            collection.AddScoped<CategoryBusinessRules>();
        }
    }
}
