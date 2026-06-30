The restrictions are real: a `ref struct` cannot be boxed, cannot usually be stored in class fields, and cannot cross `await` or `yield` suspension points. That means it is for tight synchronous scopes, not long-lived domain objects.

When a plain `struct` or class is sufficient, prefer the simpler option. Reach for `ref struct` only when the stack-only rule is the actual safety boundary you need.
