using CodingChallenge.Classes.Processing.Tasks;

namespace CodingChallenge.Classes.Processing.Base;

public abstract class TextProcessBase(ITextTaskFactory taskFactory) : ITextProcess
{
    protected ITextTaskFactory AvailableTasks { get; } = taskFactory;

    public List<ITextProcessTask> Workflow { get; } = [];
    
    public string Process(params string[] args)
    {
        BuildWorkflow(args);
        return ProcessTasks();
    }
    
    private string ProcessTasks()
    {
        var result = "";

        Workflow.ForEach(task => {
            result = task.Process(result);
        });
        
        return result;
    }


    public abstract void BuildWorkflow(params string[] args);
}