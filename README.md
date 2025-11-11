# Creational Patterns Program — Builder Pattern (C#/.NET)

A console app that demonstrates the **Builder** creational design pattern by generating RPG characters.
Using a single construction recipe (the **Director**), we produce different results via **Warrior / Mage / Custom** builders.

> This README includes everything needed for your assignment: overview, run/test steps, a reproducible debugging demo, and a short Loom script.

---

## Project Structure

```
RpgBuilderSolution.sln
src/
  RpgBuilder/
    Program.cs
    Character.cs
    CharacterBuilder.cs
    RpgBuilder.csproj
tests/
  RpgBuilder.Tests/
    UnitTest1.cs
    RpgBuilder.Tests.csproj
```

> The project uses a simple Builder pattern implementation with `Character` as the product and `CharacterBuilder` as the builder class.

---

## Prerequisites

* **.NET 8 or later**
  Check with:

  ```bash
  dotnet --version
  ```

---

## How to Run

```bash
dotnet run --project src/RpgBuilder
```

* Choose from the console menu:

  * `1` Warrior preset
  * `2` Mage preset
  * `3` Custom (enter stats, skills, and equipment interactively)

---

## How to Test

```bash
dotnet test
```

---

## Pattern Walkthrough (What’s implemented)

* **IRPGCharacterBuilder** – declares the step-by-step build API (fluent methods)
* **Concrete Builders** – `WarriorBuilder`, `MageBuilder`, `CustomCharacterBuilder`
* **Director** – `CharacterDirector` encapsulates reusable build recipes (presets)
* **Program** – simple CLI that wires user input → Director → Builder

**Why Builder?**

* Separates **construction** from **representation**, improving reuse and clarity.
* To add a new character type, keep the Director recipe and implement a new builder.

---

## Debugging Demo (Use this in your Loom video)

Goal: show how **forgetting to reset builder state** causes cross-build leakage.

1. Temporarily comment out `Reset();` inside a builder’s `Build()` method (e.g., `WarriorBuilder.Build()`):

   ```csharp
   public RPGCharacter Build()
   {
       var result = _character;
       // Reset();   // <-- comment this out for the demo
       return result;
   }
   ```
2. Run tests:

   ```bash
   dotnet test
   ```

   You should see **failure** in something like `RpgBuilder.StateLeakBug.Tests` because
   skills/equipment from the previous build “leak” into the next one.
3. Explain the cause (stateful lists were reused).
4. Restore `Reset();` and run tests again → now **pass**.

This demonstrates a classic Builder lifecycle pitfall and how to fix it.

---

## Loom Script (≈ 2–3 minutes)

**1) What it does (≈30s)**
“This app uses the **Builder** pattern to generate RPG characters. The Director holds the build recipe, and different concrete builders produce different character variants.”

**2) Demo (≈60–90s)**

* Run the app → choose `1` (Warrior) → show output (stats/skills/equipment).
* Run again → choose `2` (Mage) → highlight differences.
* Choose `3` (Custom) → input stats and add a couple skills/equipment → show output.
* Open `CharacterDirector` and show the fluent build sequence for a preset.

**3) Debugging (≈45–60s)**

* Comment out `Reset();` in `Build()` → run `dotnet test` → watch the failure.
* Explain state leakage between builds.
* Restore `Reset();` → re-run tests → all pass.

**4) Wrap-up (≈15s)**
“Builder cleanly separates construction from representation. Links to the GitHub repo and Loom video are in the README.”

---

## Submission Checklist

* [ ] Code compiles locally: `dotnet run --project src/RpgBuilder`
* [ ] Tests pass locally: `dotnet test`
* [ ] **GitHub URL** added to your assignment
* [ ] **Loom URL** added to your assignment
* [ ] README includes run/test instructions + video outline (this file)

---

## (Optional) GitHub Actions CI

Add `.github/workflows/dotnet.yml` to auto-build and test on every push:

```yaml
name: .NET
on:
  push: { branches: [ "main" ] }
  pull_request: { branches: [ "main" ] }
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'
      - run: dotnet restore
      - run: dotnet build --no-restore --configuration Release
      - run: dotnet test --no-build --configuration Release
```

---

## Extending to Other Creational Patterns (If you want variants)

* **Factory Method** – Notification sender (`Email/SMS/Push`) created by concrete creators
* **Abstract Factory** – Theme family (Light/Dark) creates UI component sets
* **Singleton** – Settings manager or event logger (thread-safe, single instance)
* **Prototype** – Clone from templates (documents/characters/configs)

---

## License

MIT (or your preference)

---

**TL;DR**
Run with `dotnet run --project src/RpgBuilder`, test with `dotnet test`.
The app showcases the **Builder** pattern and includes a reproducible debugging scenario for your Loom video.
