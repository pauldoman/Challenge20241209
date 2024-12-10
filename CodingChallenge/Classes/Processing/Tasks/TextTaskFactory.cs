using CodingChallenge.Classes.Processing.Base;
using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Classes.Processing.Tasks.Inputs;
using CodingChallenge.Classes.Processing.Tasks.Outputs;
using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Classes.Processing.Tasks;



public class TextTaskFactory(IServiceProvider services) : ITextTaskFactory
{
    private T Resolve<T>()
    where T : ITextProcessTask
    {
        return services.GetService<T>()
               ?? throw new InvalidOperationException($"Could not resolve {typeof(T).Name}");  
    }

    public IInputFromFile InputFromFile => Resolve<IInputFromFile>();

    public ICorrectPunctuation CorrectPunctuation => Resolve<ICorrectPunctuation>();

    public ICorrectTabs CorrectTabs => Resolve<ICorrectTabs>();
    
    public ICorrectSingleQuotes CorrectSingleQuotes => Resolve<ICorrectSingleQuotes>();
    
    public ICorrectDuplicateSpaces CorrectDuplicateSpaces => Resolve<ICorrectDuplicateSpaces>();

    public IMiddleVowelFilter FilterOutWordsWithMiddleVowels => Resolve<IMiddleVowelFilter>();

    public ILessThanThreeLettersFilter FilterOutLessThanThreeLetters => Resolve<ILessThanThreeLettersFilter>();

    public ILetterTFilter FilterOutWordsContainingT => Resolve<ILetterTFilter>();
    
    public IOutputToConsole OutputToConsole => Resolve<IOutputToConsole>();


}