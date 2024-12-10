using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.PreProcessors;

public class CorrectTabsTests : UnitTest<CorrectTabs>
{
    protected override CorrectTabs CreateSystemUnderTest()
    {
        return new CorrectTabs();
    }
    
    private string Space => " ";
    private char Tab => ((char)9);
    
    [Test]
    public void CorrectTabs_Process_ReplacesTabWithSpace()
    {
        var testString = $"Single{Tab}Tab";
        var expectedResult = $"Single{Space}Tab";

        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectTabs_Process_ReplacesLeadingAndTrailingTabsWithSpaces()
    {
        var testString = $"{Tab}Surrounding Tabs{Tab}";
        var expectedResult = $"{Space}Surrounding Tabs{Space}";

        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectTabs_Process_ReplacesTabsWithSpaces()
    {
        var testString = $"Tab{Tab}In{Tab}between";
        var expectedResult = $"Tab{Space}In{Space}between";
        
        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CorrectTabs_Process_ReplacesMultipleTabsWithMultipleSpaces()
    {
        var testString = $"{Tab}Tab{Tab}{Tab}{Tab}In{Tab}{Tab}{Tab}between{Tab}";
        var expectedResult = $"{Space}Tab{Space}{Space}{Space}In{Space}{Space}{Space}between{Space}";
        
        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}