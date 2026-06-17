Use `await` all the way through the call chain when possible. Mixing async and blocking calls (`.Result`, `.Wait()`) can cause deadlocks or thread starvation.

Also make the method name tell the truth. In .NET code, asynchronous methods usually end with `Async`.
