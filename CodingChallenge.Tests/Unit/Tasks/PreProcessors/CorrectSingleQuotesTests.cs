using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Tasks.PreProcessors;

public class CorrectSingleQuotesTests : UnitTest<CorrectSingleQuotes>
{
    protected override CorrectSingleQuotes CreateSystemUnderTest()
    {
        return new CorrectSingleQuotes();
    }
    
    [TestCase("'Quoted Combinations'", " 'Quoted Combinations' ")]
    [TestCase("'Quoted Unbalanced", "'Quoted Unbalanced")]
    [TestCase("Quoted Unbalanced'", "Quoted Unbalanced'")]
    [TestCase("it's left alone", "it's left alone")]
    [Test]
    public void CorrectSingleQuotes_Process_CorrectsSingleQuotesWithSpacing(string testString, string expectedResult)
    {
        var result = Sut.Process(testString);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    
}