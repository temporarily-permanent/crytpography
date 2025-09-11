using Calculator;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        Assert.That(Calculator.Program.Add(5,5), Is.EqualTo(10));
    }
}