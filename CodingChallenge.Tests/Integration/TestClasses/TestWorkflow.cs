using CodingChallenge.Classes.Processing.Base;
using CodingChallenge.Classes.Processing.Tasks;

namespace CodingChallenge.Tests.Integration.TestClasses;


public class TestWriteLineStep(Guid identifier) : ITextProcessTask
{
    public string Process(string text)
    {
        return text + identifier + Environment.NewLine;       
    }
}

public class TestWorkflow(ITextTaskFactory taskFactory) : TextProcessBase(taskFactory)
{
    public static readonly Guid Task1Id = Guid.NewGuid();
    public static readonly Guid Task2Id = Guid.NewGuid();
    public static readonly Guid Task3Id = Guid.NewGuid();
    
    public override void BuildWorkflow(params string[] args)
    {
        Workflow.Add(new TestWriteLineStep(Task2Id));
        Workflow.Add(new TestWriteLineStep(Task3Id));
        Workflow.Add(new TestWriteLineStep(Task1Id));
    }
}
