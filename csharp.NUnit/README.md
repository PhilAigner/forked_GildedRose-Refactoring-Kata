# Gilded Rose starting position in C# NUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

---

## Test Strategy

Tests are written per item type, covering:
- the normal (happy path) case
- boundary conditions (SellIn = 0, Quality = 0 or 50)
- post-sell-in behavior (doubled degradation or special rules)

Each test is isolated: one `Item` is created, `UpdateQuality()` is called once, and the result is asserted.
This makes failures easy to pinpoint.

### Item types covered

| Item type        | Rules tested |
|------------------|-------------|
| Normal Item      | Quality -1 per day; -2 after SellIn; Quality never < 0 |
| Aged Brie        | Quality +1 per day; +2 after SellIn; Quality never > 50 |
| Sulfuras         | Quality always stays at 80; SellIn never decreases |
| Backstage passes | *(to be added)* |

## Challenges

- **Deeply nested conditionals**: The original `UpdateQuality()` method uses heavily nested `if` blocks with no comments, making it hard to read. Reading `GildedRoseRequirements.md` alongside the code was necessary to confirm the intended behavior.
- **Post-sell-in edge cases**: The double-degradation rule for normal items and the double-increase for Aged Brie after SellIn=0 are easy to miss — these required dedicated tests.
- **Quality boundaries**: The 0 and 50 limits are enforced implicitly across multiple branches, so boundary tests are critical to catch regressions during refactoring.