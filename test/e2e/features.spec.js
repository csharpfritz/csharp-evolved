const { test, expect } = require("@playwright/test");

test.describe("Website navigation and features experience", () => {
  test("navigates between key pages", async ({ page }) => {
    await page.goto("/");

    await expect(page.getByRole("heading", { level: 1, name: "C# Evolved" })).toBeVisible();
    await page.getByRole("navigation", { name: "Primary" }).getByRole("link", { name: "Features" }).click();
    await expect(page).toHaveURL(/\/features\/\?/);
    await expect(page.getByRole("heading", { level: 1, name: "C# feature map" })).toBeVisible();

    await page.locator(".feature-card h2 a").first().click();
    await expect(page).toHaveURL(/\/features\/[^/]+\/$/);
    await expect(page.getByRole("heading", { level: 1 })).toBeVisible();

    await page.getByRole("link", { name: "← Back to all features" }).click();
    await expect(page).toHaveURL(/\/features\/\?/);

    await page.getByRole("navigation", { name: "Primary" }).getByRole("link", { name: "Snippets" }).click();
    await expect(page).toHaveURL(/\/snippets\/$/);
    await expect(page.getByRole("heading", { level: 1, name: "Snippets" })).toBeVisible();
  });

  test("searches features by text", async ({ page }) => {
    await page.goto("/features/");

    const tuplesCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "Tuples and Deconstruction" })
    });
    const recordsCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "Records" })
    });

    await page.getByLabel("Search").fill("tuples");

    await expect(tuplesCard).toBeVisible();
    await expect(recordsCard).toBeHidden();
    await expect(page).toHaveURL(/search=tuples/);
    await expect(page.locator("#feature-filter-summary")).toContainText('matching "tuples"');
  });

  test("hides C# 12 cards when filtering up to C# 6.0", async ({ page }) => {
    await page.goto("/features/");
    const filterForm = page.locator("#feature-filter-form");
    await expect(page.getByRole("button", { name: "Apply filters" })).toHaveCount(0);

    await filterForm.getByLabel("Version family").selectOption("csharp");
    await filterForm.getByLabel("Mode").selectOption("upToIncluding");
    await filterForm.getByLabel("Version", { exact: true }).selectOption({ label: "C# 6.0" });

    const collectionExpressionsCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "Collection Expressions" })
    });
    const stringInterpolationCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "String Interpolation" })
    });

    await expect(collectionExpressionsCard).toBeHidden();
    await expect(stringInterpolationCard).toBeVisible();
    await expect(page).toHaveURL(/target=csharp/);
    await expect(page).toHaveURL(/mode=upToIncluding/);
    await expect(page).toHaveURL(/version=6.0/);
    await expect(page.locator("#feature-filter-summary")).toContainText(
      "up to and including C# 6.0."
    );
  });

  test("filters features by version", async ({ page }) => {
    await page.goto("/features/");
    const filterForm = page.locator("#feature-filter-form");

    await filterForm.getByLabel("Version family").selectOption("dotnet");
    await expect(page.locator("#version option:checked")).toHaveText(".NET 8.0");
    await filterForm.getByLabel("Mode").selectOption("after");
    await filterForm.getByLabel("Version", { exact: true }).selectOption({ label: ".NET 7.0" });
    await expect(page.locator("#version option:checked")).toHaveText(".NET 7.0");

    const collectionExpressionsCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "Collection Expressions" })
    });
    const recordsCard = page.locator(".feature-card", {
      has: page.getByRole("link", { name: "Records" })
    });

    await expect(collectionExpressionsCard).toBeVisible();
    await expect(recordsCard).toBeHidden();
    await expect(page).toHaveURL(/target=dotnet/);
    await expect(page).toHaveURL(/mode=after/);
    await expect(page).toHaveURL(/version=7.0/);
    await expect(page.locator("#feature-filter-summary")).toContainText("after .NET 7.0.");
  });
});
