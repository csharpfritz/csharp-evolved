C# 4.0 added two small features that show up everywhere in modern code: named arguments and optional parameters. Together they make method calls self-documenting and help library authors avoid overload explosions for straightforward customization points.

They work especially well for logging, formatting, configuration, and interop-heavy APIs where the method signature is stable but most callers use only a couple of non-default settings.
