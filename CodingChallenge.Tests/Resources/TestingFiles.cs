namespace CodingChallenge.Tests.Resources;

public static class TestingFiles
{
    public static string MainChallengeTestFile => GetFilePath(@"Resources/MainChallengeTestFile.txt");

    public static string MainChallengeExpectedResults => GetFilePath(@"Resources/MainChallengeExpectedResults.txt");

    private static string GetFilePath(string relativePath)
    {
        return Path.Combine(TestContext.CurrentContext.TestDirectory, relativePath);
    }
}