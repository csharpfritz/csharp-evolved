Lambdas are the glue between data and behavior. They power LINQ queries, event handlers, predicates, projections, and most modern .NET APIs that accept `Func<>` or `Action<>`.

They also keep code local to the place where it is used, which helps when the logic is small and the surrounding context matters more than a method name.
