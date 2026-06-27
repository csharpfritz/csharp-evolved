# Sprint 1 Pre-Publish Checklist

**Use this checklist before merging any new feature to `main`.**

---

## Feature: _____________ 
**Author:** Clark Kent  
**Date Submitted:** ___________  
**Tested By:** Jimmy Olsen

---

## ✓ Code Sample Validation (Jimmy)

- [ ] **Location:** Code samples exist at `src/code-samples/{feature}/*.cs`
- [ ] **Manifest Reference:** All samples listed in `features/{feature}/feature.json` → `examples[].snippets.code` exist
- [ ] **No Critical Syntax Errors:** Samples use valid C# syntax demonstrating the feature
- [ ] **Version Alignment:** Sample language version (`sampleLanguageVersion` in feature.json) matches declared C# version
- [ ] **Naming Conventions:** Sample files follow pattern `{feature}/{descriptive-name}.cs`

**Notes/Issues:** ________________________________________________

---

## ✓ Mobile Rendering Validation (Lois / Jimmy)

- [ ] **Code Blocks:** Render without horizontal scroll on iPhone 12 viewport (390px)
- [ ] **Copy Button:** "Copy" button visible and touchable on mobile
- [ ] **Typography:** Text readable; no overflow or clipping
- [ ] **Navigation:** Feature navigation menu opens/closes correctly on mobile
- [ ] **Touch Targets:** All interactive elements have sufficient touch padding (≥48px)
- [ ] **Images:** All inline images load correctly and scale responsively

**Tested On:**
- [ ] iPhone 12 (390×844) — Chrome/Safari
- [ ] Android (360×800) — Chrome/Firefox
- [ ] iPad (768×1024) — Safari

**Notes/Issues:** ________________________________________________

---

## ✓ Content & Narrative Review (Cat)

- [ ] **Accuracy:** Feature description is technically correct
- [ ] **Clarity:** Explanation is easy to understand for intermediate C# developers
- [ ] **Practical Value:** Examples demonstrate real-world use cases
- [ ] **Tone:** Matches site voice (clear, practical, educational)
- [ ] **Links:** All cross-references within the site work (`/features/`, `/snippets/`)

**Notes/Issues:** ________________________________________________

---

## ✓ Link Audit (Jimmy)

- [ ] **"Learn More" Link Valid:** Microsoft Learn URL resolves (HTTP 200/301/302)
- [ ] **Link Label:** Accurate description of the resource
- [ ] **No Broken Cross-References:** Internal feature links work

**Learn More URL Tested:**
```
https://learn.microsoft.com/...
```

**Status:** ☐ Pass  ☐ Fail (Fix and retest)

---

## ✓ Regression Check (Jimmy)

- [ ] **No Breaking Changes:** All 30 existing features still compile and render correctly
- [ ] **Site Build Passes:** `npm run build` completes with no errors
- [ ] **No New Warnings:** Build output includes no new CSS/JS/compilation warnings
- [ ] **E2E Tests Pass:** Playwright e2e tests pass: `npm test`

**Build Command Output:**
```
$ npm run build
...
✅ All checks passed
```

---

## ✓ Feature Manifest (Jimmy / Clark)

- [ ] **Valid JSON:** `features/{feature}/feature.json` is valid JSON (can parse)
- [ ] **Required Fields:** All fields present:
  - `slug` (matches folder name)
  - `title` and `shortTitle`
  - `versions.csharp` and `versions.dotnet` (correct values)
  - `summary` (path to markdown file)
  - `learnMore.label` and `learnMore.url`
  - `examples[]` array with at least 1 example
- [ ] **Example Structure:** Each example has:
  - `id` (kebab-case identifier)
  - `title`
  - `description`
  - `sampleLanguageVersion`
  - `snippets.code` (valid file reference)

---

## ✅ Final Sign-Off

**Clark Kent (Backend Dev)**
- Code samples complete and ready
- Signature: ________________  
- Date: ________________

**Lois Lane (Frontend Dev)**
- Mobile rendering verified
- Signature: ________________  
- Date: ________________

**Cat Grant (DevRel)**
- Content reviewed and approved
- Signature: ________________  
- Date: ________________

**Jimmy Olsen (Tester)**
- All validations passed ✅
- Ready for merge: YES / NO
- Signature: ________________  
- Date: ________________

---

## 🔴 If Any Check Fails

1. **Stop** — Do not merge until resolved
2. **Log Issue** — Create GitHub issue or comment with details
3. **Escalate** — Notify responsible party (Clark/Lois/Cat)
4. **Re-Test** — After fix, Jimmy re-validates the failed check
5. **Update Checklist** — Initial, date, and move to "Re-Test" section

### Re-Test Record

| Date | Issue | Fix | Tester | Status |
|------|-------|-----|--------|--------|
| | | | | ☐ Pass ☐ Fail |
| | | | | ☐ Pass ☐ Fail |

---

## 📋 Related Documents

- **Test Strategy:** `.squad/agents/jimmy/sprint-1-test-plan.md`
- **Baseline Audit:** `.squad/agents/jimmy/baseline-audit-report.md`
- **Feature Template:** `features/{feature}/feature.json` structure
- **Build Commands:** See project `package.json` scripts

---

**Template Status:** 🟢 Active  
**Last Updated:** 2026-06-27  
**Owner:** Jimmy Olsen (Tester)

