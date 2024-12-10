namespace CodingChallenge.Classes.Processing.Words;

public class WordInSequence(int index, string word)
{
    public const string PunctuationCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^`{|}}";

    public int Index { get; init; } = index;

    public string Original { get; init; } = word;

    public string SanitisedWord { get; init; } = SanitiseWord(word);

    public bool Ignore { get; set; }
    
    private static string SanitiseWord(string word)
    {
        return word.Trim(PunctuationCharacters.ToCharArray());
    }
    
}

