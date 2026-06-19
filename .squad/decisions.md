# Squad Decisions

## Active Decisions

### 2026-06-17 — Directive: add version-aware feature filtering
**Source:** `decisions/inbox/copilot-directive-2026-06-17T10-22-23-592-04-00.md`

We need a filtered view so visitors can see features up to and including a specific version, or after a specific version; tagging language/.NET version on each feature is required.

### 2026-06-17 — First feature content model (`var`) is data-driven
**Source:** `decisions/inbox/clark-var-sample.md`

- Canonical feature metadata lives in `src/_data/features.js` as feature objects.
- Canonical C# snippets live under `src/code-samples/<feature>/` and are loaded with `readSnippet(...)`.
- Detail pages are generated from `src/features/feature.njk` via pagination.
- `src/features/index.md` iterates shared `features` data.

### 2026-06-17 — `var` discoverability and UI integration
**Source:** `decisions/inbox/lois-var-ui.md`

- Keep `src/_data/features.js` as source of truth for feature cards/nav generation.
- Use reusable `/features/{slug}/` page generation from `src/features/feature.njk`.
- Keep `src/features/index.md` card rendering data-driven with first-sample callout.
- Add primary nav link to first feature from `layout.njk`.

### 2026-06-17 — `var` educational content posture
**Source:** `decisions/inbox/cat-var-content.md`

- Add dedicated page at `src/features/var/index.md`.
- Explain `var` as compile-time inference (not dynamic typing).
- Provide readability-first usage guidance and misuse cautions.
- Add feature-map entry linking to `/features/var/`.

### 2026-06-17 — Build validation for `var` feature
**Source:** `decisions/inbox/jimmy-var-validation.md`

- Add `scripts/check-var-feature.mjs` and run through `npm run build` (`eleventy && npm run --silent check:var`).
- Verify source wiring, route/index references, and rendered output expectations for `/features/var/`.

### 2026-06-17 — Version tagging baseline model
**Source:** `decisions/inbox/perry-version-filtering.md`

- Adopt per-feature `versions` metadata for both `csharp` and `dotnet` with `{id,label,order}`.
- Add `src/_data/featureFilters.js` with filter modes and unique sorted version options by family.
- Filter semantics:
  - upToIncluding: `feature.versions[target].order <= selected.order`
  - after: `feature.versions[target].order > selected.order`

### 2026-06-17 — Version filter UX and URL behavior
**Source:** `decisions/inbox/lois-version-filter-ui.md`

- Drive filter state with query params on `/features/`: `target`, `mode`, `version`.
- Keep Eleventy output static; apply filtering via small client-side JS.
- Defaults/resilience: `target=csharp`, `mode=upToIncluding`, `version=latest available C# option` when params are invalid/missing.
- Accessibility: explicit labels, status summary, and empty-state messaging.

### 2026-06-17 — Deterministic validation for version filtering
**Source:** `decisions/inbox/jimmy-version-filter-validation.md`

- Extend existing `check:var` harness for version-filter metadata and rendered controls.
- Validate filter model shape (`versionFamilies`, defaults, options).
- Validate rendered controls and default script state in generated HTML.
- Keep checks deterministic and lightweight; dynamic browser interaction remains out of scope.

### 2026-06-17 — Directive: version-accurate samples and markdown content architecture
**Source:** `decisions/inbox/copilot-directive-2026-06-17T10-51-04-654-04-00.md`

Feature samples must stay accurate to the feature’s introduction-era versions unless explicitly labeled as newer capability. Feature narrative content should live in markdown files under a dedicated `features/` content folder with indexed references.

### 2026-06-17 — Feature content architecture migrated to `features/index.json`
**Source:** `decisions/inbox/clark-content-architecture.md`

- Canonical feature content moved to `features/index.json` and `features/<slug>/article.md` assets.
- `src/_data/features.js` resolves index entries into render-ready objects while preserving template-facing shape.
- Examples now carry `sampleLanguageVersion` and optional `newerCapabilityNote`.

### 2026-06-17 — `var` narrative aligned to C# 3.0 baseline
**Source:** `decisions/inbox/cat-var-version-accuracy.md`

- `features/var/article.md` is canonical narrative and now teaches C# 3.0/.NET 3.5-era baseline first.
- Baseline examples avoid newer-only syntax (e.g., target-typed `new`).
- Newer syntax is allowed only in clearly labeled optional callouts.

### 2026-06-17 — Feature page markdown-segment rendering model
**Source:** `decisions/inbox/lois-markdown-rendering.md`

- Feature content index supports segmented markdown references (`summary`, `intro`, `article`, `sections[]`, `callouts[]`).
- Detail template renders markdown segments and accessible note callouts while preserving existing list/filter and code rendering behavior.

### 2026-06-17 — Fix quick sample entity double-escaping
**Source:** `decisions/inbox/lois-escape-fix.md`

- Home quick sample expression is marked safe so markdown/highlight performs the single required escaping pass.
- Prevents `&amp;lt;`/`&amp;gt;` regressions in rendered snippets.

### 2026-06-17 — C# highlighting pipeline for feature samples
**Source:** `decisions/inbox/lois-csharp-highlighting.md`

- Feature sample rendering now uses shared `highlightCode` pipeline instead of raw escaped output.
- Added narrow C# decoration for missing token classes (type/operator/punctuation) and matching high-contrast CSS support.

### 2026-06-17 — Deterministic checks: version-structure constraints
**Source:** `decisions/inbox/jimmy-version-structure-validation.md`

- `scripts/check-var-feature.mjs` asserts markdown-backed structure and version-valid sample constraints.
- Includes explicit newer-capability labeling checks.

### 2026-06-17 — Deterministic checks: quick sample escaping
**Source:** `decisions/inbox/jimmy-escape-validation.md`

- Validation now fails on double-escaped entities in generated var feature output.

### 2026-06-17 — Deterministic checks: C# highlighting coverage
**Source:** `decisions/inbox/jimmy-highlighting-validation.md`

- Validation now asserts required highlight token spans in generated var page HTML and corresponding CSS class support.

### 2026-06-17 — Explicit newer-capabilities contract for feature pages
**Source:** `decisions/inbox/lois-newer-capabilities-list.md`

- Add a dedicated end-of-page **Newer capabilities** section on feature pages.
- Represent each entry with `title`, `csharpVersion`, and `path`.
- Sort entries by ascending C# version before rendering.
- Render as an ordered list of cards for deterministic, accessible presentation.

### 2026-06-17 — Deterministic validation for newer-capabilities section and ordering
**Source:** `decisions/inbox/jimmy-newer-capabilities-validation.md`

- Extend `scripts/check-var-feature.mjs` to verify newer-capabilities source metadata and markdown references.
- Validate rendered output includes the **Newer capabilities** section and expected entries.
- Enforce ascending C# version ordering in rendered output when multiple entries exist.
- Enforce source-shape and sortable-key contracts when only one entry exists.

### 2026-06-17 — Reorganize feature model to per-feature manifest + content subfolders
**Source:** `decisions/inbox/clark-feature-structure-reorg.md`

- Adopt `features/<slug>/feature.json` as the canonical per-feature manifest.
- Move narrative files under `features/<slug>/content/` with required paths for summary, intro, sections, callouts, and optional newer-capabilities.
- Update loader behavior to auto-discover `features/*/feature.json` and resolve markdown paths relative to each feature folder.
- Supersedes prior centralized `features/index.json` contract.

### 2026-06-17 — Add Copilot skill for website feature authoring
**Source:** `decisions/inbox/cat-feature-skill.md`

- Add `.copilot/skills/add-website-feature/SKILL.md` to codify feature authoring workflow.
- Require version metadata, content files, snippet wiring, and build validation in skill instructions.
- Encode version-accuracy guidance and explicit newer-capability labeling.

### 2026-06-17 — Align add-website-feature skill to per-feature manifest structure
**Source:** `decisions/inbox/cat-feature-skill-alignment.md`

- Update skill guidance from centralized index references to `features/<slug>/feature.json`.
- Require `features/<slug>/content/...` paths for summary/intro/sections/callouts/newer-capabilities.
- Keep snippet contract under `src/code-samples/<slug>/` via `examples[].snippets` references.
- Preserve `npm run build` as required validation.

## Governance

- All meaningful changes require team consensus.
- Document architectural decisions here.
- Keep history focused on work, decisions focused on direction.

### 2026-06-17 — String interpolation feature scaffold and intro-era metadata
**Source:** `decisions/inbox/clark-string-interpolation-scaffold.md`

- Mark internal plan `var` item complete and scaffold `features/string-interpolation/feature.json`.
- Set baseline metadata to `versions.csharp = 6.0` and `versions.dotnet = 4.6`.
- Wire feature manifest to markdown content and sample snippets under `src/code-samples/string-interpolation/`.
- Isolate post-baseline guidance via `newerCapabilities` entry (C# 10.0) instead of baseline examples.

### 2026-06-17 — String interpolation educational content baseline
**Source:** `decisions/inbox/cat-string-interpolation-content.md`

- Author string-interpolation narrative in markdown with concise, practical framing.
- Keep baseline guidance centered on C# 6.0 syntax/behavior.
- Structure content into `summary`, `intro`, and practical sections (`why-it-matters`, `baseline-usage`, `cautions`).
- Keep newer syntax in a dedicated, explicitly labeled newer-capabilities markdown segment.

### 2026-06-17 — Deterministic validation coverage for string interpolation
**Source:** `decisions/inbox/jimmy-string-interpolation-validation.md`

- Extend `scripts/check-var-feature.mjs` to validate `string-interpolation` structure, references, and rendering.
- Preserve existing `var` assertions while adding baseline/newer-version guards for string interpolation.
- Assert intro-era version alignment, metadata shape, output markers, and newer-capability ordering/constraints.
- Keep validation deterministic and integrated with existing `npm run build` flow.

### 2026-06-17 — Remove in-body Version note callout for `var`
**Source:** `decisions/inbox/lois-remove-version-note-callout.md`

- Remove the `Version note` callout from `features/var/feature.json` article-body flow.
- Keep newer-version guidance in the dedicated end-of-page **Newer capabilities** section.
- Update deterministic checks to require newer-capabilities presence and forbid removed callout text in rendered output.
- Preserve build validation through existing `npm run build` workflow.

### 2026-06-17 — Landing feature snippets + nav simplification + tiled feature cards
**Source:** `decisions/inbox/lois-layout-and-nav-fixes.md`

- Home page now renders all feature snippet cards in deterministic pseudo-random order via `homeFeatures` shuffle metadata.
- Global header nav is constrained to Home, Features, and Snippets (feature-detail shortcut removed).
- `/features/` card layout now uses a consistent tiled grid/card structure with balanced snippet sizing.

### 2026-06-17 — Deterministic validation for nav, landing snippets, and tiled-card layout
**Source:** `decisions/inbox/jimmy-layout-nav-validation.md`

- Extended deterministic checks to require primary nav links exactly `/, /features/, /snippets/` and forbid feature-detail nav coupling.
- Added landing-page assertions for feature-snippet section presence, per-card title+snippet structure, and deterministic slug order parity with `homeFeatures`.
- Added `/features/` tiled-card structure assertions for grid classes and required header/body/footer card anatomy.
- Validation executed through `npm run build` with successful `check:var` result.


### 2026-06-17 — Widen home feature snippet cards and prevent snippet clipping
**Source:** `decisions/inbox/lois-home-snippet-width.md`

- Added `home-feature-snippet-grid` hook on `src/index.md` for scoped home-section layout control.
- Expanded desktop layout with a wider centered container and larger card minimum width.
- Removed snippet clipping constraints in `.feature-snippet-card` and enabled readable code wrapping.
- Added responsive fallback so the section collapses cleanly on tablet/mobile.
- Updated deterministic guard checks to align with the new section class contract.

### 2026-06-17 — Deterministic validation for home snippet wide-layout contract
**Source:** `decisions/inbox/jimmy-home-snippet-width-validation.md`

- Extended `scripts/check-var-feature.mjs` to require `home-feature-snippet-grid` on the home snippet section.
- Added CSS contract checks for wide columns (`minmax(520px, 1fr)`) and mobile fallback (`minmax(260px, 1fr)`).
- Added deterministic checks for wrapped snippet formatting hooks on `.feature-snippet-card pre` and `.feature-snippet-card code`.
- Kept validations lightweight and integrated with the existing `npm run build` path.


### 2026-06-17 — Repair home snippet layout to full-width stacked cards
**Source:** `decisions/inbox/lois-home-layout-repair.md`

- Use a single-column, full-width stacked layout for Home feature snippet cards across desktop and mobile.
- Keep `.home-feature-snippet-grid` with `grid-template-columns: minmax(0, 1fr)` and force full-width cards.
- Preserve readability/no-clipping by keeping horizontal snippet scroll and non-wrapping code behavior.
- Scope changes to Home snippet markup/CSS only (`src/index.md`, `src/assets/site.css`).

### 2026-06-17 — Deterministic validation for repaired home snippet layout
**Source:** `decisions/inbox/jimmy-home-layout-repair-validation.md`

- Update `scripts/check-var-feature.mjs` to require repaired Home snippet classes and title-link hooks.
- Assert CSS contract for single-column layout (`minmax(0, 1fr)`) across default and mobile breakpoints.
- Keep lightweight readability guards for snippet overflow/non-wrapping behavior.
- Preserve existing deterministic `npm run build` (`check:var`) validation flow.

### 2026-06-17 — Features page tile-wall layout ordering and alignment fix
**Source:** `decisions/inbox/lois-feature-tile-wall.md`

- Updated `.feature-grid` to enforce row-major, left-aligned tile flow.
- Added explicit alignment and margin rules to prevent centered column offset behavior.
- Normalized direct child tile sizing with `.feature-grid > .feature-card { width: 100%; margin: 0; }`.
- Scoped changes to features layout CSS only; filtering markup/logic unchanged.

### 2026-06-17 — Deterministic validation for features tile-wall contract
**Source:** `decisions/inbox/jimmy-feature-tile-wall-validation.md`

- Added deterministic checks in `scripts/check-var-feature.mjs` for tile-wall template/CSS/output contracts.
- Enforced required grid flow hooks and rejected regressions to single-column/centered layout behavior.
- Added rendered `/features/` checks for tile count/order parity with `src/_data/features.js` and per-card structure/data attributes.
- Kept validation lightweight in existing `npm run build` (`check:var`) path.

### 2026-06-17 — Home snippet overflow guardrails for container-bounded rendering
**Source:** `decisions/inbox/lois-home-overflow-fix.md`

- Constrain `.home-feature-snippet-grid` to container bounds with `width: 100%` and `max-width: 100%`.
- Bound home snippet cards/code blocks to prevent intrinsic-width overflow (`max-width: 100%`, `min-width: 0`, bounded `pre`).
- Add safe wrapping for home snippet titles and inline code to avoid right-side bleed while preserving snippet readability and existing ordering/data flow.
- Verification completed via `npm run build` (Eleventy + deterministic `check:var`).

### 2026-06-17 — Features tile-wall layout hardening
**Source:** `decisions/inbox/lois-features-layout-not-applied-fix.md`

- Keep high-specificity selector `.grid.feature-grid` and harden child sizing for reliable tile-wall behavior.
- Add `min-width: 0` and `max-width: none` to `.grid.feature-grid > .card.feature-card` so intrinsic card width cannot force single-column collapse.
- Preserve existing filter behavior and compatibility with deterministic checks while restoring left-to-right tile flow.

### 2026-06-17 — Deterministic validation for applied features layout selectors
**Source:** `decisions/inbox/jimmy-features-layout-applied-validation.md`

- Require `.grid.feature-grid` and `.grid.feature-grid > .card.feature-card` selector contracts in CSS.
- Validate rendered `_site/features/index.html` direct-child card structure (`card tiled-card feature-card`) under the feature-grid section.
- Expand forbidden-pattern checks to reject centered single-column fallback CSS regressions.
- Keep checks static, deterministic, and integrated with existing `npm run build` / `check:var` path.


### 2026-06-17 — Feature card footer version-pill badges
**Source:** `decisions/inbox/lois-feature-version-pills.md`

- Move version labels from card body copy into reusable footer pill badges.
- Keep card body focused on title and summary; keep CTA plus C#/.NET pills in the bottom footer region.
- Preserve existing feature filtering/data attributes and tiled-card behavior while improving scanability.

### 2026-06-17 — Deterministic validation for feature-card version pills
**Source:** `decisions/inbox/jimmy-feature-version-pills-validation.md`

- Extend `scripts/check-var-feature.mjs` with deterministic assertions for version-pill template hooks, rendered footer pills, and CSS contracts.
- Require explicit C#/.NET pill markers (`feature-pill-csharp`, `feature-pill-dotnet`) in template/CSS/rendered output.
- Keep validation lightweight and integrated in existing `npm run build` / `check:var` workflow.

### 2026-06-17 — Homepage snippet cleanup preserves valid code-block structure with highlighting
**Source:** `decisions/inbox/lois_lane-kept-homepage-snippet-markup-while-adding-syntax-h.md`

- Keep homepage snippet markup in the existing `<pre><code>...</code></pre>` structure to preserve renderer/check compatibility.
- Apply syntax highlighting via a dedicated `highlightCodeInline` Eleventy filter that returns highlighted inner HTML.
- Preserve snippet indentation/tab behavior while improving readability through token highlighting.

### 2026-06-17 — P1 Feature Validation: Readiness and Wait Status
**Source:** `decisions/inbox/clark_kent-p1-feature-validation-readiness-and-wait-status.md`

- Scope: Validate P1 samples for tuples/deconstruction (C# 7), switch expressions (C# 8), global using directives (C# 10), file-scoped namespaces (C# 10), required members (C# 11), and raw string literals (C# 11).
- Current state: Validation is queued pending Cat Grant draft delivery.
- Validation contract: confirm snippet wiring, compile/version correctness, and feature-accuracy with pass/fail notes.

### 2026-06-19 — Standardized Playwright E2E harness for static Eleventy site
**Source:** `decisions/inbox/Jimmy_Olsen-standardized-playwright-e2e-harness-for-static-ele.md`

- Standardize Playwright on deterministic local server execution (`npm run serve:e2e`, port 4173) via `webServer` in `playwright.config.js`.
- Run Chromium-only E2E for stable, fast local/CI behavior.
- Ensure `/features/` search behavior is user-visible and query-string driven so navigation/search/filter scenarios are testable end-to-end.


### 2026-06-19 — Fix feature filter version selector to avoid cross-family value collisions
**Source:** `decisions/inbox/lois-lane-fix-feature-filter-version-selector-to-avoid-cross.md`

- Fixed `/features/` version selector logic to resolve selected option by `(family + value)` so C#/.NET options sharing values (for example `7.0`, `8.0`) cannot cross-select hidden options.
- Updated `src/features/index.md` state application and event handlers to use family-aware selection/read helpers.
- Added Playwright coverage in `test/e2e/features.spec.js` asserting .NET selections display the correct option text and prevent regression.

### 2026-06-19 — Enforce true hiding for filtered feature cards
**Source:** `decisions/inbox/lois-lane-enforced-true-hiding-for-filtered-feature-cards.md`

- Keep filter logic and URL behavior unchanged; enforce hidden-card display at presentation layer with `.feature-card[hidden] { display:none; }`.
- Update e2e assertions to check user-visible hiding (`toBeHidden`) and add regression coverage for C# up-to-including 6.0 so C# 12 cards are not shown.

### 2026-06-19 — Remove redundant Apply Filters button from features page
**Source:** `decisions/inbox/lois_lane-removed-redundant-apply-filters-button-from-featur.md`

- Removed redundant **Apply filters** button from `src/features/index.md`; filtering now applies immediately on control changes and search input.
- Kept reset behavior and URL query synchronization while removing submit-only handling.
- Updated E2E coverage in `test/e2e/features.spec.js` and styling in `src/assets/site.css` to validate immediate filter application.

### 2026-06-19 — Theme contrast refresh for the C# Evolved site
**Source:** `decisions/inbox/lois-theme-contrast-refresh.md`

- Elevated the default palette with a deeper midnight-blue base, brighter violet accents, and cyan highlights to keep the existing cool blue/purple identity while increasing contrast.
- Applied the refreshed tokens to the body background, header/footer shell, hero panel, cards, and link/hover states without changing content structure or page behavior.
- Kept the styling focused on visual polish so the site feels more energetic while remaining readable and consistent.
