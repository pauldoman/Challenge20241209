using CodingChallenge.Classes.Processing.Tasks.Inputs;
using CodingChallenge.Tests.Base;
using CodingChallenge.Tests.Resources;

namespace CodingChallenge.Tests.Unit.Tasks.Inputs;

public class InputFromFileTests : UnitTest<InputFromFile>
{
    private string TestFilePath => TestingFiles.MainChallengeTestFile;

    protected override InputFromFile CreateSystemUnderTest()
    {
        return new InputFromFile();
    }
    
    [Test]
    public void WithText_Process_ReturnsProvidedText()
    {
        var expectedData = File.ReadAllText(TestFilePath);
        Sut.WithPath(TestFilePath);

        var result = Sut.Process();

        Assert.That(result, Is.Not.Empty);
        Assert.That(expectedData, Is.Not.Empty);
        Assert.That(result, Is.EqualTo(expectedData));
    }
    
}