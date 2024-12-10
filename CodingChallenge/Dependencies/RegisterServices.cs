using CodingChallenge.Classes.Processing.Tasks;
using CodingChallenge.Classes.Processing.Tasks.Filters;
using CodingChallenge.Classes.Processing.Tasks.Inputs;
using CodingChallenge.Classes.Processing.Tasks.Outputs;
using CodingChallenge.Classes.Processing.Tasks.PreProcessors;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Dependencies;

public static class RegisterServices
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        // Register Workflows...
        services.AddScoped<MainChallenge, MainChallenge>();
        
        // Register Factories...
        services.AddScoped<ITextTaskFactory, TextTaskFactory>();
        
        // Register Text Inputs...
        services.AddTransient<IInputFromFile, InputFromFile>();

        // Register Text Corrections...
        services.AddScoped<ICorrectPunctuation, CorrectPunctuation>();
        services.AddScoped<ICorrectSingleQuotes, CorrectSingleQuotes>();
        services.AddScoped<ICorrectTabs, CorrectTabs>();
        services.AddScoped<ICorrectDuplicateSpaces, CorrectDuplicateSpaces>();
        
        // Register Text Filters... 
        services.AddScoped<ILetterTFilter, LetterTFilter>();
        services.AddScoped<IMiddleVowelFilter, MiddleVowelFilter>();
        services.AddScoped<ILessThanThreeLettersFilter, LessThanThreeLettersFilter>();
        
        // Register Text Outputs...
        services.AddScoped<IOutputToConsole, OutputToConsole>();
        
        return services;
    }
    
}


