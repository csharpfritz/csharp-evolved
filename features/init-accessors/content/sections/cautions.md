An `init` property can still be assigned from code running during construction or object initialization, so it is not the same thing as a truly frozen object.

Keep constructors and initializers aligned. If you need required data, use `required` or a constructor instead of assuming callers will remember every field.
