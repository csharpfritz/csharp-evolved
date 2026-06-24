# GitHub Pages Migration Plan

## Target URL
`https://csharpevolved.github.io`

## Steps to complete the migration

1. **Create the `csharpevolved` GitHub organization** (if not already done)
   - https://github.com/organizations/new

2. **Transfer the repository**
   - Current: `csharpfritz/csharp-evolved`
   - Target: `csharpevolved/csharpevolved.github.io`
   - Via: Repository Settings → Danger Zone → Transfer ownership
   - Then rename the repo to `csharpevolved.github.io`

3. **Enable GitHub Pages**
   - Repository Settings → Pages
   - Source: GitHub Actions
   - The `deploy.yml` workflow is already in place

4. **Verify the deployment**
   - Push to `main` — the Actions workflow will build and deploy
   - Visit `https://csharpevolved.github.io`

## Notes
- No `pathPrefix` is required — the site serves from `/`
- The GitHub Actions workflow handles `npm ci && npm run build` automatically
- The `_site/` directory is the artifact — never committed to the repo
- Future custom domain (e.g. `csharpevolved.dev`) would require a CNAME file and DNS setup
