# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet test --no-build --verbosity normal     # run xUnit tests with code coverage
dotnet stryker --mutation-level Complete      # mutation testing (CI breaks at 98%)
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **hash code implementation library** — no interfaces, no configuration, no I/O. It contains exactly four `sealed record` types, one per chart model abstraction:

- `ChartHash` — hashes `IChart`: concatenates a 16-byte type-discriminator prefix with `DeterminedHash` values for Title, Description, Type, XAxis, YAxis, and each element of Series
- `ChartTypeHash` — hashes `IChartType`: prefix + Name
- `ChartSeriesHash` — hashes `IChartSeries`: prefix + Legend, XAxisSource, YAxisSource
- `AxisHash` — hashes `IAxis`: prefix + Legend

Every type implements `IDeterminedHash` (from `Pure.HashCodes.Abstractions`), which extends `IEnumerable<byte>`. The hash is computed lazily by enumerating bytes. The 16-byte type-discriminator prefix in each class ensures domain separation — two objects of different types with identical field values produce different hash sequences.

**Dependency chain:** `Pure.Chart.Model.Abstractions` supplies the interfaces being hashed; `Pure.HashCodes` supplies `DeterminedHash` (the byte-level compositor) and `IDeterminedHash`.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All types must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.1.0.0`. Breaking API changes fail the build.

**Publishing:** triggered by pushing a semver tag (e.g. `1.2.3`). The tag value becomes the `PackageVersion`. Packages are pushed to both GitHub Packages and NuGet.org.

**Tests:** xUnit project targeting net10.0 only. CI enforces ≥ 98% line coverage and ≥ 98% mutation score.

## Code Style

Enforced via `.editorconfig`, `dotnet format`, and `csharpier`:

- No `var` — always use explicit types
- No expression-bodied methods or constructors — use block bodies
- File-scoped namespace declarations (`namespace Foo;`)
- Private instance fields: `_camelCase` prefix
- Max line length: 90 characters
- `System.*` usings sorted before other usings, no blank line between using groups

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
