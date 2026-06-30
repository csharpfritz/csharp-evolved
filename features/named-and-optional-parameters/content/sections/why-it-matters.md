Named arguments improve call-site clarity when positional arguments start to blur together, especially with multiple `bool`, `string`, or numeric values. Optional parameters let you expose sensible defaults once instead of maintaining a ladder of near-duplicate overloads.

That combination is a good fit for utility methods, client SDKs, and formatting helpers where most callers follow the common path but a few need to opt into extra behavior.
