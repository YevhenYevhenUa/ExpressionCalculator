using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Task5.Calculator.Core;
using Task5.Calculator.Core.Interfaces;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddDependencies();
        var serviceProvider = services.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<IStartPoint>();
        app.Run();

    }
}