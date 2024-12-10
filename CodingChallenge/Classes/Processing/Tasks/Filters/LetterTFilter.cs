using CodingChallenge.Classes.Processing.Tasks.Filters.Base;

namespace CodingChallenge.Classes.Processing.Tasks.Filters;

public interface ILetterTFilter : ITextFilterTask;

public class LetterTFilter : TextFilterTaskBase, ILetterTFilter
{
    public override bool ShouldBeIgnored(string text)
    {
        return (text.ToUpper().Contains('T'));
    }
}