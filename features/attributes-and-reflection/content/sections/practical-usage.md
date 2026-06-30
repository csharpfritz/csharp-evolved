A good default is to reflect once, near application startup, and convert the results into plain objects, delegates, or lookup tables that the hot path can use cheaply. That approach keeps the flexibility while avoiding repeated assembly scans.

It is also a strong fit for developer-facing features like help screens, diagnostics pages, and admin tooling where clarity matters more than raw throughput.
