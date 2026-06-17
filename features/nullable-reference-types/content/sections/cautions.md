Nullable annotations do not change runtime behavior. They only improve compile-time analysis, so older APIs may still return `null` even when the type system says otherwise.

Treat warnings as design feedback. If you silence too many of them, you lose most of the safety benefit.
