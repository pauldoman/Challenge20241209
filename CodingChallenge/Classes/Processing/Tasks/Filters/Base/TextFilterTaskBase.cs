using CodingChallenge.Classes.Processing.Words.Extensions;

namespace CodingChallenge.Classes.Processing.Tasks.Filters.Base;

public abstract class TextFilterTaskBase : ITextFilterTask
{
    public virtual string Process(string text)
    {
        var words = text.SplitIntoWords();

        words.ForEach(word =>
        {
            word.Ignore = ShouldBeIgnored(word.SanitisedWord) || word.Ignore;
        });

        return words.RebuildIntoString();
    }

    public abstract bool ShouldBeIgnored(string text);
    
}