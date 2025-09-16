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

    [Test]
    public void Does_PaddingMessageSHA1_ReturnCorrectlyPaddedMessage()
    {
        List<byte> result =
        [
            104, 97, 108, 108, 111, 44, 32, 104,
            111, 101, 32, 103, 97, 97, 116, 32,
            104, 101, 116, 32, 101, 114, 109, 101,
            101, 128, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 200
        ];

        List<byte> input =
        [
            104, 97, 108, 108, 111, 44, 32, 104,
            111, 101, 32, 103, 97, 97, 116, 32,
            104, 101, 116, 32, 101, 114, 109, 101,
            101, 
        ];

        List<uint> resultUint = 
        [
            1751477356, 1869573992, 1869779303, 1633908512, 
            1752461600, 1701995621, 1701343232, 0, 
            0, 0, 0, 0, 
            0, 0, 0, 200
        ];
        
        Assert.That(Calculator.Cryptography.SHA_1.PaddingMessageSHA1(input), Is.EqualTo(resultUint));
    }
}