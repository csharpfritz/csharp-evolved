Optional parameter defaults are baked in at the call site at compile time. If you ship a library and later change a default value, older compiled callers keep using the original value until they are rebuilt.

Also avoid turning every knob into an optional parameter. When a method grows too many options, a dedicated options object or builder usually scales better and reads more clearly.
