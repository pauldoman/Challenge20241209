using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Classes.Processing.Tasks.Inputs;
using CodingChallenge.Classes.Processing.Tasks.Outputs;
using CodingChallenge.Classes.Processing.Tasks.PreProcessors;

namespace CodingChallenge.Classes.Processing.Tasks;

public interface ITextTaskFactory
{
    public IInputFromFile InputFromFile { get; }

    public ICorrectPunctuation CorrectPunctuation { get; }
    
    public ICorrectTabs CorrectTabs { get; }
    
    public ICorrectSingleQuotes CorrectSingleQuotes { get; }
    
    public ICorrectDuplicateSpaces CorrectDuplicateSpaces { get; }

    public IMiddleVowelFilter FilterOutWordsWithMiddleVowels { get; }

    public ILessThanThreeLettersFilter FilterOutLessThanThreeLetters { get; }

    public ILetterTFilter FilterOutWordsContainingT { get; }
    
    public IOutputToConsole OutputToConsole { get; }
    
}

