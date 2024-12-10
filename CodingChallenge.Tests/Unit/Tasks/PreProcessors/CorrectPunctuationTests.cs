using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.PreProcessors;

public class CorrectPunctuationTests : UnitTest<CorrectPunctuation>
{
    protected override CorrectPunctuation CreateSystemUnderTest()
    {
        return new CorrectPunctuation();
    }
    
    [TestCase("No Punctuation", "No Punctuation")]
    [TestCase("Full.Stop.", "Full. Stop.")]
    [TestCase("Comma,Stop,", "Comma, Stop,")]
    [TestCase("Exclamation!Mark!", "Exclamation! Mark!")]
    [TestCase("Question?Mark?", "Question? Mark?")]
    [TestCase("Semi;Colon;", "Semi; Colon;")]
    [TestCase("Full:Colon:", "Full: Colon:")]
    [Test]
    public void CorrectPunctuation_Process_CorrectsPunctuation(string testString, string expectedResult)
    {
        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}