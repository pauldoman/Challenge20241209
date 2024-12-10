using CodingChallenge.Classes.Processing.Tasks.Filters.Base;

namespace CodingChallenge.Classes.Processing.Tasks.Filters;

public interface ILessThanThreeLettersFilter : ITextFilterTask;

public class LessThanThreeLettersFilter : TextFilterTaskBase, ILessThanThreeLettersFilter
{
    public override bool ShouldBeIgnored(string text)
    {
        return (text.Length < 3);
    }

}