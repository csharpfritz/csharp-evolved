Reflection is more fragile and more expensive than direct code paths, so avoid sprinkling it inside tight loops or per-request critical paths. Cache what you discover.

If you publish trimmed or Native AOT apps, be careful: reflection over members discovered only at runtime can require explicit annotations or a different design. Keep the scope bounded and predictable.
