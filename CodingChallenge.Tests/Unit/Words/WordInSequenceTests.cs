using CodingChallenge.Classes.Processing.Words;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Words;

public class WordInSequenceTests : UnitTest<WordInSequence>
{
    
    private static string PunctuationCharacters => WordInSequence.PunctuationCharacters;

    private static string WordStub => "Word";

    protected override WordInSequence CreateSystemUnderTest()
    {
        return new WordInSequence(1, "");
    }

    // Generated Test Cases...

    public static TestCaseData[] TrailingPunctuationSingleCases
    {
        get
        {
            return PunctuationCharacters.ToCharArray()
                .Select(c => $"{WordStub}{c}")
                .Select((testWord, index) => new TestCaseData(index, testWord, WordStub))
                .ToArray();
        }
    }

    public static TestCaseData[] TrailingPunctuationDoubleCases
    {
        get
        {
            return PunctuationCharacters.ToCharArray()
                .Select(c => $"{WordStub}{c}{c}")
                .Select((testWord, index) => new TestCaseData(index, testWord, WordStub))
                .ToArray();
        }
    }

    public static TestCaseData[] LeadingPunctuationSingleCases
    {
        get
        {
            return PunctuationCharacters.ToCharArray()
                .Select(c => $"{c}{WordStub}")
                .Select((testWord, index) => new TestCaseData(index, testWord, WordStub))
                .ToArray();
        }
    }

    public static TestCaseData[] LeadingPunctuationDoubleCases
    {
        get
        {
            return PunctuationCharacters.ToCharArray()
                .Select(c => $"{c}{c}{WordStub}")
                .Select((testWord, index) => new TestCaseData(index, testWord, WordStub))
                .ToArray();
        }
    }

    public static TestCaseData[] EmbeddedPunctuationCases
    {
        get
        {
            return PunctuationCharacters.ToCharArray()
                .Select(c => $"{WordStub}{c}{WordStub}")
                .Select((testWord, index) => new TestCaseData(index, testWord, testWord))
                .ToArray();
        }
    }
    
    private void AssertWord(WordInSequence result, int index, string original, string sanitised)
    {
        Assert.That(result.Index, Is.EqualTo(index));
        Assert.That(result.Original, Is.EqualTo(original));
        Assert.That(result.SanitisedWord, Is.EqualTo(sanitised));
        Assert.That(result.Ignore, Is.False);
    }

    [TestCase(1, "", "")]
    [TestCase(2, "a", "a")]
    [TestCase(3, "in", "in")]
    [TestCase(4, "word", "word")]
    [TestCase(5, "o'clock", "o'clock")]
    [TestCase(6, "1234Numbers4321", "1234Numbers4321")]
    [Test]
    public void WordInSequence_CleanWords_NoSanitizationPerformed(int index, string word, string expectedSanitisedText)
    {
        Sut = new WordInSequence(index, word);

        AssertWord(Sut, index, word, expectedSanitisedText);
    }

    [TestCaseSource(nameof(TrailingPunctuationSingleCases))]
    [TestCaseSource(nameof(TrailingPunctuationDoubleCases))]
    [TestCaseSource(nameof(LeadingPunctuationSingleCases))]
    [TestCaseSource(nameof(LeadingPunctuationDoubleCases))]
    [TestCaseSource(nameof(EmbeddedPunctuationCases))]
    [Test]
    public void WordInSequence_SurroundingPunctuation_SanitisesWordRemovingSurroundingPunctuation(int index, string word, string expectedSanitisedText)
    {
        Sut = new WordInSequence(index, word);

        AssertWord(Sut, index, word, expectedSanitisedText);
    }

}