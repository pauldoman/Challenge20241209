using System.Text.RegularExpressions;
using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.PreProcessors;

public interface ICorrectTabs : ITextProcessTask;

public class CorrectTabs : ICorrectTabs
{
    public string Process(string text)
    {
        // Find any Tab character, and replace
        // it with a space...

        return Regex.Replace(text, "\t", " ");
    }
}