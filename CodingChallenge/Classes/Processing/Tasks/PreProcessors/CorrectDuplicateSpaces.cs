using System.Text.RegularExpressions;
using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.PreProcessors;

public interface ICorrectDuplicateSpaces : ITextProcessTask;

public class CorrectDuplicateSpaces : ICorrectDuplicateSpaces
{
    public string Process(string text)
    {
        // Replace 2 or more consecutive
        // spaces with a single space...
        
        return Regex.Replace(text, @" {2,}", " ");
    }
}