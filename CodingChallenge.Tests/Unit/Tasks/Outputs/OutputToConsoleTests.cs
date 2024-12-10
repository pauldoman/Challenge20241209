using CodingChallenge.Classes.Processing.Tasks.Outputs;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.Outputs;

public class OutputToConsoleTests : UnitTest<OutputToConsole>
{
    private const string TestConsoleMessage = "This is a test Log Message";

    private TextWriter DefaultConsole { get; set; } = Console.Out;
    
    protected override OutputToConsole CreateSystemUnderTest()
    {
        return new OutputToConsole();
    }

    private StringWriter RedirectConsole()
    {
        var redirectedOutput = new StringWriter();
        Console.SetOut(redirectedOutput);
        return redirectedOutput;
    }
    
    private void RestoreConsole()
    {
        Console.SetOut(DefaultConsole);
    }
    
    [Test]
    public void OutputToConsole_Process_OutputsTextToTheConsole()
    {
        using var surrogate = RedirectConsole();

        Sut.Process(TestConsoleMessage);

        RestoreConsole();
        Assert.That(surrogate.ToString(), Does.Contain(TestConsoleMessage));
    }
}