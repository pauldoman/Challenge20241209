using System.Text.RegularExpressions;
using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.PreProcessors;

public interface ICorrectPunctuation : ITextProcessTask; 

public class CorrectPunctuation : ICorrectPunctuation
{
    public string Process(string text)
    {
        // Find Common Punctuation immediately followed by
        // a non-whitespace and non-single quote character
        // and add space between the two groups...

        return Regex.Replace(text, @"([.,!?;:])([^\s^'])", "$1 $2");
    }
}