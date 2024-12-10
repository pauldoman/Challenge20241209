using CodingChallenge.Classes.Processing.Tasks.Filters.Base;
// ReSharper disable StringLiteralTypo

namespace CodingChallenge.Classes.Processing.Tasks.Filters;

public interface IMiddleVowelFilter : ITextFilterTask;

public class MiddleVowelFilter : TextFilterTaskBase, IMiddleVowelFilter
{
    private static string Vowels => "aeiouAEIOU";

    public override bool ShouldBeIgnored(string text)
    {
        var middleChars = ExtractMiddleCharacters(text);
        return middleChars.Any(x => Vowels.Contains(x));
    }

    private static string ExtractMiddleCharacters(string text)
    {
        if (text.Length == 0) return "";

        var isEvenLength = (text.Length % 2 == 0);
        var extractStartPos = (text.Length / 2) - (isEvenLength ? 1 : 0);
        var extractLength = isEvenLength ? 2 : 1;
        
        return text.Substring(extractStartPos, extractLength);
    }
}