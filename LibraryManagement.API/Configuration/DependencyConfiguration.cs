using FluentValidation.AspNetCore;
using LibraryManagement.Core.Contract;
using LibraryManagement.Core.Domain.CustomValidations;
using LibraryManagement.Core.Services;
using LibraryManagement.Infra.Contract;
using LibraryManagement.Infra.Repositories;

namespace LibraryManagement.API.Configuration;

public static class DependencyConfiguration
{
    public static void AddDependency(this IServiceCollection services)
    {
        services.AddTransient<IStudentServices, StudentServices>();
        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<IValidationServices, ValidationServices>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidation>());
    }
}
