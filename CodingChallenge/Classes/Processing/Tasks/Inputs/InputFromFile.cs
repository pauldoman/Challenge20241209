using CodingChallenge.Classes.Processing.Base;

namespace CodingChallenge.Classes.Processing.Tasks.Inputs;

public interface IInputFromFile : ITextProcessTask
{
    InputFromFile WithPath(string filePath);
}

public class InputFromFile : IInputFromFile
{
    private string _filePath  = "";
    
    public InputFromFile WithPath(string filePath)
    {
        _filePath = filePath;
        return this;
    }
    
    public string Process(string text = "")
    {
        try
        {
            return File.ReadAllText(_filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to Read Text File: {e.Message}");
            throw;
        }
    }
    
}