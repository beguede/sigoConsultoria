using Microsoft.Extensions.DependencyInjection;
using ConsultoriasService.Application;
using ConsultoriasService.Application.Interfaces;
using ConsultoriasService.Domain.Repositories;
using ConsultoriasService.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IEmpresaApplication, EmpresaApplication>();
            services.AddScoped<IConsultoriaApplication, ConsultoriaApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IConsultoriaRepository, ConsultoriaRepository>();
        }
    }
}