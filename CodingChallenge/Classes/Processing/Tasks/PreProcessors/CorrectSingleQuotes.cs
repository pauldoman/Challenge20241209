using System.Text.RegularExpressions;
using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.PreProcessors;


public interface ICorrectSingleQuotes : ITextProcessTask; 

public class CorrectSingleQuotes : ICorrectSingleQuotes
{
    public string Process(string text)
    {
        // Finds any text within enclosing single
        // quotes, that doesn't contain a single quote
        // inside it...
        
        return Regex.Replace(text, @"'([^']*)'", " '$1' ");
    }
}