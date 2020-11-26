using AutoMapper;
using DDD.Application.APP;
using DDD.Application.APP.Interface;
using DDD.Domain.Interface.EmployeeRepository;
using DDD.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DDD.CrossCutting.DI
{
    public static class DIModule
    {
       public static void ConfigureClassesDI(IServiceCollection service)
        {
            service.AddScoped<IEmployeeApplication, EmployeeApplication>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();

            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "DDD.CrossCutting.Mapper");

            Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
            {
                return
                  assembly.GetTypes()
                          .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                          .ToArray();
            }

            service.AddAutoMapper(typelist);
        }
    }
}
