using System;

public ref struct CsvFieldReader
{
    private ReadOnlySpan<char> _remaining;

    public CsvFieldReader(ReadOnlySpan<char> line)
    {
        _remaining = line;
    }

    public bool TryRead(out ReadOnlySpan<char> field)
    {
        if (_remaining.IsEmpty)
        {
            field = default;
            return false;
        }

        var commaIndex = _remaining.IndexOf(',');
        if (commaIndex < 0)
        {
            field = _remaining;
            _remaining = default;
            return true;
        }

        field = _remaining.Slice(0, commaIndex);
        _remaining = _remaining.Slice(commaIndex + 1);
        return true;
    }
}

public static class Program
{
    public static void Main()
    {
        CsvFieldReader reader = new CsvFieldReader("Ada Lovelace,Mathematician,London".AsSpan());

        ReadOnlySpan<char> field;
        while (reader.TryRead(out field))
        {
            Console.WriteLine(field.ToString());
        }
    }
}
