C# 7.2 introduced `ref struct` to support byref-like types such as `Span<T>` and `ReadOnlySpan<T>`. The compiler enforces stack-only rules so these types cannot outlive the memory they point at.

That sounds specialized, but the pattern is practical whenever you want a tiny parser, formatter, or buffer helper to work directly over existing memory without heap allocations.
