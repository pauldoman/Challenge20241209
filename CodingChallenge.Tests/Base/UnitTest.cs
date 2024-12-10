namespace CodingChallenge.Tests.Base;

public abstract class UnitTest<TSystemUnderTest>
{
    protected TSystemUnderTest Sut { get; set; } = default!;

    [SetUp]
    public void UnitTestSetUp()
    {
        Sut = CreateSystemUnderTest() ?? throw new Exception("System Under Test not Instantiated");
    }


    
    protected abstract TSystemUnderTest? CreateSystemUnderTest();

    
    [Test]
    public void Instantiates_Correctly()
    {
        Assert.That(Sut, Is.Not.Null);
        Assert.That(Sut, Is.InstanceOf<TSystemUnderTest>());
    }
}