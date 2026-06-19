using System;

public interface ISpanParsableValue<TSelf> where TSelf : ISpanParsableValue<TSelf>
{
    static abstract TSelf Parse(ReadOnlySpan<char> value);
}

public readonly record struct ProductCode(string Value) : ISpanParsableValue<ProductCode>
{
    public static ProductCode Parse(ReadOnlySpan<char> value) => new(value.ToString().Trim().ToUpperInvariant());
}

static T ParseValue<T>(ReadOnlySpan<char> input) where T : ISpanParsableValue<T>
{
    return T.Parse(input);
}

var code = ParseValue<ProductCode>(" abc-42 ");
Console.WriteLine(code.Value); // ABC-42
