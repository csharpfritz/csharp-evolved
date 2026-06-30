Ref returns arrived in C# 7.0 as part of the language's lower-level performance toolset. Instead of returning a value copy, a method can return an alias to an existing variable, array element, or field.

That is powerful when the caller genuinely needs to mutate or inspect the original storage location, but it also means the method is exposing part of its internal memory model directly.
