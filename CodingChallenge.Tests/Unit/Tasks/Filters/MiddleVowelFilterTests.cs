using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.Filters;

public class MiddleVowelFilterTests : UnitTest<MiddleVowelFilter>
{
    protected override MiddleVowelFilter CreateSystemUnderTest()
    {
        return new MiddleVowelFilter();
    }
    
    // Should be Ignored Tests...
    
    [TestCase("a")]
    [TestCase("toe")]
    [TestCase("pot")]
    [TestCase("clean")]
    [Test]
    public void FilterWithSingleMiddleCharIgnoreScenarios_ShouldBeIgnored_ReturnsTrue(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.True);
    }
    
    [TestCase("ha")]
    [TestCase("that")]
    [TestCase("then")]
    [TestCase("thin")]
    [TestCase("plot")]
    [TestCase("shun")]
    [TestCase("street")]
    [Test]
    public void FilterWithTwoMiddleCharsIgnoreScenarios_ShouldBeIgnored_ReturnsTrue(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.True);
    }
    
    [TestCase("h")]
    [TestCase("ice")]
    [TestCase("eke")]
    [TestCase("iciness")]
    [Test]
    public void FilterWithSingleMiddleCharKeepScenarios_ShouldBeIgnored_ReturnsFalse(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.False);
    }
    
    [TestCase("tt")]
    [TestCase("abba")]
    [TestCase("ochre")]
    [Test]
    public void FilterWithTwoMiddleCharsKeepScenarios_ShouldBeIgnored_ReturnsFalse(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.False);
    }
    
    // Filter Process...

    [TestCase("Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice","beginning tired sitting by sister the and nothing once")]
    [TestCase("she had peeped into the book her sister was reading, but it had no pictures or conversations in it, 'and what is the","she into the sister reading, conversations 'and the")]
    [Test]
    public void FilterScenarios_Process_FiltersTextCorrectly(string testString, string expectedResult)
    {
        var result = Sut.Process(testString);
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
}