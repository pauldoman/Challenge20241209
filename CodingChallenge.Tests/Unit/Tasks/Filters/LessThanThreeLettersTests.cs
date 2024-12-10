using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.Filters;

public class LessThanThreeLettersTests : UnitTest<LessThanThreeLettersFilter>
{
    protected override LessThanThreeLettersFilter CreateSystemUnderTest()
    {
        return new LessThanThreeLettersFilter();
    }
    
    // Should be Ignored....

    [TestCase("a")]
    [TestCase("in")]
    [TestCase("on")]
    [Test]
    public void FilterValidIgnoreScenarios_ShouldBeIgnored_ReturnsTrue(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.True);
    }
    
    [TestCase("are")]
    [TestCase("not")]
    [TestCase("keep")]
    [Test]
    public void FilterValidKeepScenarios_ShouldBeIgnored_ReturnsFalse(string testString)
    {
        var result = Sut.ShouldBeIgnored(testString);
        
        Assert.That(result, Is.False);
    }
    
    
    // Filter Process...
    
    [TestCase("this is a test sentence","this test sentence")]
    [TestCase("words aren't removed","words aren't removed")]
    [TestCase("one word will bee removed oh!","one word will bee removed")]
    [TestCase("In on a an oh","")]
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