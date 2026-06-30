A ref return can remove repeated lookups and extra copies when you are working with arrays, buffers, and other performance-sensitive storage. It pairs well with ref locals, which let the caller keep a stable alias to that returned location.

Used carefully, it gives you targeted in-place updates without forcing the rest of the API surface into unsafe code.
