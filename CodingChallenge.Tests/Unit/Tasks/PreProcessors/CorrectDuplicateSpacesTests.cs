using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.PreProcessors;

public class CorrectDuplicateSpacesTests : UnitTest<CorrectDuplicateSpaces>
{
    protected override CorrectDuplicateSpaces CreateSystemUnderTest()
    {
        return new CorrectDuplicateSpaces();
    }
    
    [TestCase("Single Space", "Single Space")]
    [TestCase("Double  Space", "Double Space")]
    [TestCase("Triple   Space", "Triple Space")]
    [TestCase("Trailing Space Untouched ", "Trailing Space Untouched ")]
    [TestCase(" Leading Space Untouched", " Leading Space Untouched")]
    [TestCase("Trailing Spaces Trimmed to one   ", "Trailing Spaces Trimmed to one ")]
    [TestCase("   Leading Spaces Trimmed to one", " Leading Spaces Trimmed to one")]
    [Test]
    public void CorrectDuplicateSpaces_Process_RemovesDuplicateSpaces(string testString, string expectedResult)
    {
        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}