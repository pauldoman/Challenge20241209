using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.Filters.Base;

public interface ITextFilterTask : ITextProcessTask
{
    bool ShouldBeIgnored(string text);
}
