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

        //01101000 01100001 01101100 01101100 01101111 00101100 00100000 01101000
        //01101111 01100101 00100000 01100111 01100001 01100001 01110100 00100000
        //01101000 01100101 01110100 00100000 01100101 01110010 01101101 01100101
        //01100101 10000000 00000000 00000000 00000000 00000000 00000000 00000000
        //00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000
        //00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000
        //00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000
        //00000000 00000000 00000000 00000000 00000000 00000000 00000000 11001000
        
        List<byte> input =
        [
            104, 97, 108, 108, 111, 44, 32, 104,
            111, 101, 32, 103, 97, 97, 116, 32,
            104, 101, 116, 32, 101, 114, 109, 101,
            101, 
        ];

        
        // this is from chatgpt and inaccurate 
        List<uint> resultUint = 
        [
            1751477356, 1869573992, 1869779303, 1633908512, 
            1752461600, 1701995621, 1701343232, 0, 
            0, 0, 0, 0, 
            0, 0, 0, 200
        ];
        
        Assert.That(Calculator.Cryptography.SHA_1.PaddingMessageSHA1(input), Is.EqualTo(resultUint));
    }

    [Test]
    public void LByteToUintTest()
    {
        List<byte> Input =
        [
            //10011010 11001011 11100101 10100101
            0b10011010,
            0b11001011,
            0b11100101,
            0b10100101
        ];
        
        uint Output = Calculator.Cryptography.SHA_1.L_ByteToUint(Input);
        uint CompareResult = 2597053861;
        Assert.That(Output, Is.EqualTo(CompareResult));
    }
}