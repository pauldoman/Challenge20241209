using CodingChallenge.Tests.Base;
using CodingChallenge.Tests.Resources;

namespace CodingChallenge.Tests.Integration;

public class MainChallengeTests : IntegrationTest<MainChallenge>
{
    private readonly string _testFile = TestingFiles.MainChallengeTestFile;
    private readonly string _expectedResultFile = TestingFiles.MainChallengeExpectedResults;
    
    [Test]
    public void MainChallenge_Process_ProcessesFileCorrectly()
    {
        var expectedResult = File.ReadAllText(_expectedResultFile);
        
        var result = Sut?.Process(_testFile) ?? "";
        
        Assert.That(Sut, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Length, Is.EqualTo(expectedResult.Length));
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    
}