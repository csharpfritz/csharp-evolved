`ref struct` is one of the building blocks behind modern high-performance .NET APIs. It lets you bundle together a little bit of behavior and a span-backed view of memory while preserving safety rules that a normal `struct` cannot express.

If you are reading from buffers, slicing text, or doing short-lived formatting work, it often produces clearer code than passing several spans and indexes around separately.
