`Span<T>` is a `ref struct`, so it cannot be stored on the heap, captured by lambdas, or used across `await` boundaries. Keep span-based logic synchronous and scoped to the current stack frame.
