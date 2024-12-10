using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.Filters;

public class LetterTFilterTests : UnitTest<LetterTFilter>
{
    protected override LetterTFilter CreateSystemUnderTest()
    {
        return new LetterTFilter();
    }
    
    // Should be Ignored....
    
    [TestCase("this")]
    [TestCase("street")]
    [TestCase("tenant")]
    [TestCase("t")]
    [TestCase("t!")]
    [TestCase("This")]
    [TestCase("That")]
    [TestCase("TNT")]
    [Test]
    public void FilterValidIgnoreScenarios_ShouldBeIgnored_ReturnsTrue(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.True);
    }

    [TestCase("his")]
    [TestCase("elsewhere")]
    [TestCase("a")]
    [Test]
    public void FilterValidKeepScenarios_ShouldBeIgnored_ReturnsFalse(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.False);
    }

    [TestCase("(this)")]
    [TestCase("'street'")]
    [TestCase("[tenant]")]
    [TestCase("<at>")]
    [TestCase("((this))")]
    [Test]
    public void FilterValidIgnoreEdgeScenarios_ShouldBeIgnored_ReturnsTrue(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.True);
    }

    // Filter Process...
    
    [TestCase("this is a test sentence","is a")]
    [TestCase("no words will be removed","no words will be removed")]
    [TestCase("one word will be removed at","one word will be removed")]
    [TestCase("to","")]
    [TestCase("t","")]
    [TestCase("","")]
    [Test]
    public void FilterScenarios_Process_FiltersTextCorrectly(string testString, string expectedResult)
    {
        var result = Sut.Process(testString);
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}