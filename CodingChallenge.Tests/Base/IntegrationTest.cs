using CodingChallenge.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CodingChallenge.Tests.Base;

public class IntegrationTest<TSystemUnderTest>
{
    protected TSystemUnderTest? Sut { get; private set; }
    
    
    [SetUp]
    public void IntegrationTestSetup()
    {
        var registrations = new ServiceCollection();
        registrations.AddLogging(builder => builder.AddConsole());
        registrations.RegisterAppServices();
        
        RegisterLocalServices(registrations);

        var serviceProvider = registrations.BuildServiceProvider();

        Sut = ResolveSut(serviceProvider);
    }

    
    protected virtual void RegisterLocalServices(IServiceCollection services)
    {
    }
    
    private TSystemUnderTest ResolveSut(IServiceProvider serviceProvider)
    {
        var resolvedSut = serviceProvider.GetService<TSystemUnderTest>();
        if (resolvedSut == null) throw new Exception($"Could not Resolve System Under Test: {typeof(TSystemUnderTest).Name}");
        return resolvedSut;
    }

}