using System.Security.Cryptography;
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
        Assert.That(Calculator.Program.Add(5, 5), Is.EqualTo(10));
    }

    [Test]
    public void Does_SHA1_ReturnCorrectHash()
    {
        string input = "Hello World!";
        using (SHA1 SHADotnet = SHA1.Create())
        {
            
            //Assert.That(Calculator.Cryptography.SHA_1.SHA1(H), Is.EqualTo());
        }
    }

    [Test]
    public void Does_PrepareMessageScheduleSHA1_ReturnCorrectResult()
    {
        //List<uint> input;
        //uint[] expectedResult;
        //uint[] returnedResult = Calculator.Cryptography.SHA_1.PrepareMessageScheduleSHA1();
        //Assert.That(returnedResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Does_PaddingMessageSHA1_ReturnCorrectlyPaddedMessage()
    {
        List<byte> input =
        [
            104, 97, 108, 108, 111, 44, 32, 104,
            111, 101, 32, 103, 97, 97, 116, 32,
            104, 101, 116, 32, 101, 114, 109, 101,
            101,
        ];

        List<uint> resultUint =
        [
            1751215212, 1865162856, 1868898407, 1633776672,
            1751479328, 1701997925, 1702887424, 0,
            0, 0, 0, 0,
            0, 0, 0, 200
        ];

        Assert.That(Calculator.Cryptography.SHA_1.PaddingMessageSHA1(input), Is.EqualTo(resultUint));
    }
}


