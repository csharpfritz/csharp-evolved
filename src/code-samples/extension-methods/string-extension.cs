public static class StringExtensions
{
    public static bool IsNullOrEmptyTrimmed(this string value) =>
        string.IsNullOrWhiteSpace(value?.Trim());
}
