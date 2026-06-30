Exception filters add a `when` clause to `catch`, so the runtime evaluates a condition before it commits to that handler. That makes the catch block more honest: it runs only for the specific state you expect, while other failures continue searching for a better handler.

This is especially useful for transient errors, status-code-specific recovery, and lightweight logging where you want more precision than a broad `catch` followed by `if` statements.
