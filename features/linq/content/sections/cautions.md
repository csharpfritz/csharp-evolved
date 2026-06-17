Not every loop should become LINQ. If the code relies on side effects, early exits, or complex branching, a simple `foreach` can be clearer.

Also remember that deferred execution can delay work until enumeration time, which is useful but easy to forget when debugging.
