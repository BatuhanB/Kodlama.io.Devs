using System.Reflection;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddScoped<ProgrammingLanguageBusinessRules>();
            return services;
        }
    }
}
