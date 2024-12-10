using CodingChallenge.Classes.Processing.Base;
using CodingChallenge.Classes.Processing.Tasks;

namespace CodingChallenge;

public class MainChallenge(ITextTaskFactory taskFactory) : TextProcessBase(taskFactory)
{
    public override void BuildWorkflow(params string[] args)
    {
        Workflow.Add(AvailableTasks.InputFromFile.WithPath(args[0]));
        Workflow.Add(AvailableTasks.CorrectTabs);
        Workflow.Add(AvailableTasks.CorrectSingleQuotes);
        Workflow.Add(AvailableTasks.CorrectPunctuation);
        Workflow.Add(AvailableTasks.CorrectDuplicateSpaces);
        Workflow.Add(AvailableTasks.FilterOutWordsWithMiddleVowels);
        Workflow.Add(AvailableTasks.FilterOutLessThanThreeLetters);
        Workflow.Add(AvailableTasks.FilterOutWordsContainingT);
        Workflow.Add(AvailableTasks.OutputToConsole);
    }
}