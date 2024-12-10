using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.Outputs;

public interface IOutputToConsole : ITextProcessTask;

public class OutputToConsole : IOutputToConsole
{
    public string Process(string text)
    {
        Console.WriteLine(text);
        return text;
    }
}