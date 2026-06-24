const features = require("./features");

const SPOTLIGHT = [
  { slug: "var",                    description: "Let the compiler infer types at compile time — cleaner code without losing static safety." },
  { slug: "async-await",            description: "Write asynchronous code that reads like synchronous code, without callbacks or manual threading." },
  { slug: "string-interpolation",   description: "Embed expressions directly in string literals — goodbye, string.Format." },
  { slug: "records",                description: "Declare immutable data types in one line, with value equality and non-destructive mutation built in." },
  { slug: "pattern-matching",       description: "Test and destructure data in a single expression — if/else chains become concise match arms." },
  { slug: "collection-expressions", description: "Create and combine any collection type with a unified [1, 2, 3] literal syntax." },
];

module.exports = SPOTLIGHT.map(({ slug, description }) => {
  const feature = features.find(f => f.slug === slug);
  return feature ? { ...feature, spotlightDescription: description } : null;
}).filter(Boolean);
