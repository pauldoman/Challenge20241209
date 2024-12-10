using CodingChallenge.Tests.Base;
using CodingChallenge.Tests.Integration.TestClasses;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Tests.Integration;


public class TextProcessBaseTests : IntegrationTest<TestWorkflow>
{
    protected override void RegisterLocalServices(IServiceCollection services)
    {
        services.AddScoped<TestWorkflow>();
    }

    [Test]
    public void TestWorkflow_Process_ProcessesTasksInSequence()
    {
        var nl = Environment.NewLine;
        var expectedResult = $"{TestWorkflow.Task2Id}{nl}{TestWorkflow.Task3Id}{nl}{TestWorkflow.Task1Id}{nl}";
        
        var result = Sut?.Process();
        
        Assert.That(Sut, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}


