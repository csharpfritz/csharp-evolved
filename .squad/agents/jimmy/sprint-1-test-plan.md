# Sprint 1 Test Plan — Jimmy Olsen (QA & Validation)

**Branch:** `sprint/1-foundation-gaps`  
**Period:** Sprint 1  
**Baseline:** 26 existing features (audited & validated)  
**New Features:** Up to 7 (pending Clark's authoring)

---

## I. Test Strategy Overview

### Core Mission
Ensure every feature passes **compilation + mobile readiness** before publishing. All code samples are runnable, regressions are caught early, and mobile users see consistent, readable content.

### Quality Gates
- ✅ **Compilation**: All `.cs` samples compile with zero warnings
- ✅ **Mobile**: Code blocks render, navigation works, images load on iOS/Android
- ✅ **Regression**: Existing 26 features remain stable
- ✅ **Links**: All Microsoft Learn references resolve and are current

---

## II. Test Categories

### A. Code Sample Validation (Clark's Samples)

**Responsibility:** Validate each new feature's code samples at submission.

**Note:** Code samples in `src/code-samples/` are educational snippets meant to demonstrate specific language features in isolation, not standalone compilable programs. They may be fragment code or examples without full context.

#### Test Process
1. **Locate samples:** `src/code-samples/{feature}/*.cs`
2. **Verify syntax validity:**
   - Check for obvious parse errors using Roslyn analyzer (`CSharpEvolved.Analyzers`)
   - Validate that samples reference declared C# features correctly
   - Ensure no critical syntax errors that would confuse readers
3. **Cross-reference:** Verify all samples listed in `features/{feature}/feature.json` examples exist
4. **Document:** Pass/fail checklist in test report

#### Success Criteria
- No critical syntax errors that indicate incomplete/broken samples
- All samples referenced in feature manifests exist on disk
- Code samples reflect the C# version claimed in `feature.json`
- Sample metadata (language version, feature tags) are accurate

#### Coverage
- Baseline: 30 existing features (52+ `.cs` files audited per decision 2026-06-24)
- Sprint 1: Up to 7 new features (~14-21 new `.cs` files)

#### Validation Tools
- Visual inspection of sample content
- Roslyn analyzer checks via `CSharpEvolved.Analyzers`
- Cross-reference checks between manifest and file system

---

### B. Mobile Smoke Tests

**Responsibility:** Verify feature pages render correctly on mobile devices and browsers.

#### Test Scope
- **Browsers:**
  - Chrome (Android)
  - Safari (iOS)
  - Firefox (Android/iOS)
- **Viewports:**
  - iPhone 12 (390×844)
  - iPad (768×1024)
  - Android std (360×800)

#### Test Checklist
- [ ] Code blocks render without horizontal scroll
- [ ] Code block copy-to-clipboard button is touchable
- [ ] Navigation menu opens/closes properly
- [ ] Feature cards display and filter correctly
- [ ] Images load (including inline code samples)
- [ ] Links are clickable and not too close together
- [ ] Typography is readable (no text overflow)
- [ ] Syntax highlighting displays correctly on small screens

#### Tools
- Playwright E2E (per decision 2026-06-19) via `test/e2e/features.spec.js`
- Chrome DevTools device emulation (manual spot checks)
- BrowserStack or Safari on physical devices (if needed)

#### Acceptance
- No rendering bugs, no missing content, no unreadable text
- All interactive elements functional on touch

---

### C. Existing Feature Audit (26 Features)

**Responsibility:** Run basic smoke test on all published features to catch regressions.

#### Test Checklist per Feature
1. **Compilation**
   - [ ] All `.cs` samples still compile (no regressions from refactoring)
2. **Links**
   - [ ] "Learn More" Microsoft Learn link is valid (HEAD request)
   - [ ] Internal navigation links work
3. **Content Rendering**
   - [ ] Code blocks render with syntax highlighting
   - [ ] Markdown sections display correctly
   - [ ] Version pills show correct labels (NETFx, NETCore, .NET)
4. **Mobile** (sampling basis)
   - [ ] 5 features spot-checked on mobile viewport
   - [ ] No regressions in layout/readability

#### Regression Matrix
| Feature | Compile | Links | Rendering | Mobile |
|---------|---------|-------|-----------|--------|
| async-await | ✓ | ✓ | ✓ | — |
| collection-expressions | ✓ | ✓ | ✓ | — |
| ... (22 more) | | | | |
| var (spot-check mobile) | ✓ | ✓ | ✓ | ✓ |

---

### D. Pre-Publish Checklist

**Responsibility:** Gate feature publication with Clark & Lois.

#### Pre-Publish Requirements
Before Clark's feature folder is merged, it must pass:

```
FEATURE: [Name]
─────────────────────

Compilation (Jimmy)
  [ ] All .cs files compile with zero warnings
  [ ] Code targets declared C# version
  [ ] No undefined references or duplicate namespaces
  
Mobile Rendering (Lois/Jimmy)
  [ ] Code blocks render on iOS/Android
  [ ] Copy button is touchable
  [ ] Navigation functions on mobile
  [ ] Typography readable at mobile scale
  
Content Review (Cat)
  [ ] Narrative is clear and accurate
  [ ] Migration advice is current
  
Link Audit (Jimmy)
  [ ] "Learn More" link valid (HTTP HEAD succeeds)
  [ ] Internal cross-references work
  
Regression Check (Jimmy)
  [ ] Existing 26 features still compile
  [ ] No broken links in existing content
  [ ] Sample changes don't break other features' examples

Sign-off
  [ ] Clark: Code samples ready
  [ ] Lois: Layout & mobile verified
  [ ] Cat: Content reviewed
  [ ] Jimmy: All tests pass
```

---

## III. Test Execution Plan

### Phase 1: Baseline Audit (Week 1)
- [ ] Run compilation check on all 26 existing features
- [ ] Verify all Microsoft Learn links are current
- [ ] Spot-check 5 features on mobile (Chrome/Safari)
- [ ] Document baseline regression matrix

### Phase 2: New Feature Validation (Ongoing)
- [ ] As Clark publishes feature folders, compile each `.cs` sample
- [ ] Lois coordinates mobile rendering review
- [ ] Log any failures with actionable reproduction steps
- [ ] Gate merge with pre-publish checklist (above)

### Phase 3: Sprint Closure Validation (End of Sprint)
- [ ] Full regression run on all 26 + new features
- [ ] E2E coverage via Playwright for features filter & search
- [ ] Mobile validation on final 7 features
- [ ] Sign off on sprint readiness

---

## IV. Test Environment & Tools

### Build/Compile
- **Language:** C# / .NET
- **Compilers:** `dotnet`, `csc.exe`
- **Target:** Latest LangVersion (12+), netstandard2.0+ output
- **Command:** `dotnet build` (features or individual `.cs` files)

### E2E & Mobile
- **Tool:** Playwright (configured in `playwright.config.js`)
- **Config:** `webServer: { command: 'npm run serve:e2e', port: 4173 }`
- **Browsers:** Chromium (local/CI standard)
- **Mobile Emulation:** Playwright device presets

### Link Verification
- **Tool:** PowerShell `Invoke-WebRequest -Method HEAD`
- **Scope:** All Microsoft Learn URLs in `learnMore` fields
- **Threshold:** HTTP 200, 301, 302 (success); 404, 5xx (failure)

### Regression Tracking
- **Format:** CSV/JSON matrix (feature × test area)
- **Tool:** Manual logging + Playwright assertions
- **Baseline:** Decision 2026-06-24 (52 samples audited, 7 fixed)

---

## V. Reporting & Hand-off

### Daily Status
- **Log failures immediately** in shared Slack/issue with:
  - Feature name & sample file
  - Error message (compile warning/error, rendering issue, link failure)
  - Reproduction command or steps
  - Recommended action (Clark/Lois/Cat)

### Sprint Report
- **Deliverable:** `sprint-1-test-report.md` (at sprint close)
  - Summary: # features tested, # passed, # failed
  - Regression matrix (26 features × 4 test areas)
  - New feature results (7 features × compilation + mobile)
  - Issues and recommendations
  - Sign-off: Ready / Needs work

### Acceptance Gate
- ✅ **All new features** pass compilation + mobile + link checks
- ✅ **No regressions** in existing 26 features
- ✅ **Regression matrix** shows green across the board
- ❌ Feature blocked if any gate fails; escalate to Perry (Lead)

---

## VI. Risk Factors & Mitigation

| Risk | Likelihood | Impact | Mitigation |
|------|------------|--------|-----------|
| Code samples have version mismatches (C# 7 sample in C# 12 feature) | Medium | High | Compile with declared LangVersion; log warnings |
| Microsoft Learn links become stale | Low | Medium | Monthly HEAD request audit; escalate if 404 |
| Mobile layout breaks on new features | Medium | Medium | Test on actual devices; Playwright mobile presets |
| Existing features break when Clark refactors samples | Low | High | Regression compile run before merge |
| Time spent on manual testing | High | Low | Automate via Playwright; focus manual on mobile |

---

## VII. Success Metrics

### Quality Gates (Hard Stops)
- 100% compilation success (all samples must compile)
- 0 broken Microsoft Learn links
- 0 regression failures in existing features

### Efficiency Metrics
- **Compilation check:** < 5 min per feature (7 features × 5 min = 35 min)
- **Link audit:** < 2 min (parallel HEAD requests)
- **Mobile smoke test:** < 15 min per feature (automated + spot-check)
- **Total pre-publish time:** < 30 min per feature

### Coverage Goals
- 100% of new feature samples compiled
- 100% of new feature pages tested on mobile
- 100% of existing feature regression checks passed
- 50% mobile device coverage (iPhone + Android)

---

## VIII. Appendix: Test Commands

### Compile All Samples in Feature
```powershell
# Option 1: dotnet
cd features/my-feature
dotnet build

# Option 2: csc (direct)
csc /target:library /langversion:latest /nowarn:CS0162 samples/*.cs
```

### Link Audit (All Features)
```powershell
$features = Get-ChildItem features -Directory
foreach ($f in $features) {
  $json = Get-Content "features/$($f.Name)/feature.json" | ConvertFrom-Json
  $url = $json.learnMore.url
  Write-Host "Testing $($f.Name): $url"
  Invoke-WebRequest -Method HEAD -Uri $url -ErrorAction SilentlyContinue |
    Select-Object @{N="Status"; E={$_.StatusCode}} |
    Out-Host
}
```

### Playwright E2E (Features Page)
```bash
npm run build
npm test -- test/e2e/features.spec.js
```

### Mobile Rendering (Manual)
```bash
# Start dev server
npm run dev

# Test on device simulator or BrowserStack
# Verify: code block overflow, button touch target, nav responsiveness
```

---

## IX. Handoff & Escalation

### Success Path
1. ✅ Feature samples compile
2. ✅ Mobile rendering verified
3. ✅ Links audit passes
4. ✅ Pre-publish checklist signed off by Clark + Lois + Cat
5. ✅ Feature merged to main

### Failure Path
1. ❌ Sample fails to compile → **Escalate to Clark**
2. ❌ Mobile rendering broken → **Escalate to Lois**
3. ❌ Link 404 → **Escalate to Cat** (content update)
4. ❌ Regression in existing feature → **Escalate to Perry** (blocker review)

---

**Document Owner:** Jimmy Olsen (Tester)  
**Last Updated:** 2026-06-27  
**Status:** Ready for Sprint 1 Kickoff
