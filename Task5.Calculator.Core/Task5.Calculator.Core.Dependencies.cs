using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Task5.Calculator.Core.Interfaces;

namespace Task5.Calculator.Core
{
    [ExcludeFromCodeCoverage]
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICalculator, CalculatorClass>();
            services.AddScoped<IConverter, RPNConverter>();
            services.AddScoped<IStringProcessor, Processors>();
            services.AddScoped<IFileProcessor, Processors>();
            services.AddScoped<ITokenizer, Tokenizer>();
            services.AddScoped<IUserInput, UserInterface>();
            services.AddScoped<IUserInterface, UserInterface>();
            services.AddScoped<IValueValidator, ValueValidator>();
            services.AddScoped<IStartPoint, StartPoint>();
            
            return services;

        }

    }
}
