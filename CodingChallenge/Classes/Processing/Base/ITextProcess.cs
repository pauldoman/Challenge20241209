namespace CodingChallenge.Classes.Processing.Base;


public interface ITextProcess
{
    List<ITextProcessTask> Workflow { get; }
    
    string Process(params string[] args);
    
    void BuildWorkflow(params string[] args);
}