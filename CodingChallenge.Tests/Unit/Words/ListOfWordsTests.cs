using CodingChallenge.Classes.Processing.Words;
using CodingChallenge.Classes.Processing.Words.Extensions;
using CodingChallenge.Tests.Base;

namespace CodingChallenge.Tests.Unit.Words;

public class ListOfWordsTests : UnitTest<List<WordInSequence>>
{
    private static string Word1 => "Here";
    private static string Word2 => "are";
    private static string Word3 => "some";
    private static string Word4 => "words";
    private static string Word5 => "alert!";
    
    protected override List<WordInSequence> CreateSystemUnderTest()
    {
        return [];
    }
    
    private static void AssertWord(WordInSequence result, int index, string original, string sanitised)
    {
        Assert.That(result.Index, Is.EqualTo(index));
        Assert.That(result.Original, Is.EqualTo(original));
        Assert.That(result.SanitisedWord, Is.EqualTo(sanitised));
        Assert.That(result.Ignore, Is.False);
    }

    // Splitting Strings into Words...
    
    [Test]
    public void SplitIntoWords_EmbeddedSpaces_ReturnsListOfWords()
    {
        var testString = $"{Word1} {Word2} {Word3} {Word4}";

        Sut = testString.SplitIntoWords();
        
        Assert.That(Sut, Has.Count.EqualTo(4));
        AssertWord(Sut[0], 0, Word1, Word1);
        AssertWord(Sut[1], 1, Word2, Word2);
        AssertWord(Sut[2], 2, Word3, Word3);
        AssertWord(Sut[3], 3, Word4, Word4);
    }

    [Test]
    public void SplitIntoWords_EmbeddedNewLines_ReturnsListOfWords()
    {
        var testString = $"{Word1}\n{Word2}\n{Word3}\n{Word4}";

        Sut = testString.SplitIntoWords();
        
        Assert.That(Sut, Has.Count.EqualTo(4));
        AssertWord(Sut[0], 0, Word1, Word1);
        AssertWord(Sut[1], 1, Word2, Word2);
        AssertWord(Sut[2], 2, Word3, Word3);
        AssertWord(Sut[3], 3, Word4, Word4);
    }

    // Rebuilding Strings from Words...

    [Test]
    public void RebuildIntoString_ListOfWords_RebuildsStringCorrectly()
    {
        Sut.Add(new WordInSequence(0, Word1));
        Sut.Add(new WordInSequence(1, Word2));
        Sut.Add(new WordInSequence(2, Word3));
        Sut.Add(new WordInSequence(3, Word4));

        var result = Sut.RebuildIntoString();
        
        Assert.That(result, Is.EqualTo($"{Word1} {Word2} {Word3} {Word4}"));
    }

    [Test]
    public void RebuildIntoString_ListOfWordsOutOfOrder_RebuildsStringCorrectly()
    {
        Sut.Add(new WordInSequence(3, Word4));
        Sut.Add(new WordInSequence(2, Word3));
        Sut.Add(new WordInSequence(1, Word2));
        Sut.Add(new WordInSequence(0, Word1));

        var result = Sut.RebuildIntoString();
        
        Assert.That(result, Is.EqualTo($"{Word1} {Word2} {Word3} {Word4}"));
    }

    [Test]
    public void RebuildIntoString_ListOfWordsSomeIgnored_RebuildsStringCorrectlyOmittingIgnored()
    {
        Sut.Add(new WordInSequence(0, Word1));
        Sut.Add(new WordInSequence(1, Word2));
        Sut.Add(new WordInSequence(2, Word3));
        Sut.Add(new WordInSequence(3, Word4));
        Sut[0].Ignore = true;
        Sut[2].Ignore = true;
        
        var result = Sut.RebuildIntoString();
        
        Assert.That(result, Is.EqualTo($"{Word2} {Word4}"));
    }

    [Test]
    public void RebuildIntoString_ListOfWordsSomeSanitised_RebuildsOriginalStringsCorrectly()
    {
        Sut.Add(new WordInSequence(0, Word1));
        Sut.Add(new WordInSequence(1, Word2));
        Sut.Add(new WordInSequence(2, Word3));
        Sut.Add(new WordInSequence(3, Word4));
        Sut.Add(new WordInSequence(4, Word5));
        
        var result = Sut.RebuildIntoString();

        Assert.That(Sut[4].Original, Is.EqualTo(Word5));
        Assert.That(Sut[4].SanitisedWord, Is.Not.EqualTo(Word5));
        Assert.That(result, Is.EqualTo($"{Word1} {Word2} {Word3} {Word4} {Word5}"));
    }


}