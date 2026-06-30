using System;

public ref struct AsciiScratchBuffer
{
    private Span<byte> _buffer;

    public AsciiScratchBuffer(Span<byte> buffer)
    {
        _buffer = buffer;
    }

    public int WriteUppercase(ReadOnlySpan<char> text)
    {
        var written = 0;

        foreach (var character in text)
        {
            _buffer[written++] = (byte)char.ToUpperInvariant(character);
        }

        return written;
    }
}

public static class Program
{
    public static void Main()
    {
        Span<byte> bytes = stackalloc byte[32];
        AsciiScratchBuffer scratch = new AsciiScratchBuffer(bytes);
        int length = scratch.WriteUppercase("ok-42".AsSpan());

        for (int index = 0; index < length; index++)
        {
            Console.Write((char)bytes[index]);
        }
    }
}
