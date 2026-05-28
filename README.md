# Pure.Chart.Model.HashCodes

Deterministic hash code implementations for chart model abstractions in the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.Model.HashCodes/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.Model.HashCodes/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.Model.HashCodes/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.Model.HashCodes/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.Model.HashCodes)](https://www.nuget.org/packages/Pure.Chart.Model.HashCodes)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.Model.HashCodes` provides deterministic, byte-enumerable hash codes for every type in the chart model abstraction layer. Each type wraps one of the `Pure.Chart.Model.Abstractions` interfaces and produces a stable byte sequence by prepending a fixed 16-byte type-discriminator prefix before hashing the object's fields. The resulting sequences compose cleanly with `Pure.HashCodes.DeterminedHash`, enabling structural equality checks and content-addressed storage across chart configurations.

## API

All types are `sealed record` and implement `IDeterminedHash` (which extends `IEnumerable<byte>`).

| Type | Wraps | Hashed fields |
|---|---|---|
| `ChartHash` | `IChart` | Title, Description, Type, XAxis, YAxis, Series |
| `ChartTypeHash` | `IChartType` | Name |
| `ChartSeriesHash` | `IChartSeries` | Legend, XAxisSource, YAxisSource |
| `AxisHash` | `IAxis` | Legend |

All hash types live in the `Pure.Chart.Model.HashCodes` namespace.

## Dependencies

- [`Pure.Chart.Model.Abstractions`](https://github.com/kudima03/Pure.Chart.Model.Abstractions/tree/0.1.0-preview.1.0.0) — chart domain interfaces (`IChart`, `IChartType`, `IChartSeries`, `IAxis`)
- [`Pure.HashCodes`](https://github.com/kudima03/Pure.HashCodes/tree/2.1.0) — deterministic, byte-enumerable hash computation over Pure primitives

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```
dotnet add package Pure.Chart.Model.HashCodes
```

## Usage

```csharp
using Pure.Chart.Model.HashCodes;

IChart chart = ...; // any IChart implementation

// Enumerate the hash bytes directly
byte[] hash = new ChartHash(chart).ToArray();

// Compose with other IDeterminedHash values
IEnumerable<byte> combined = new DeterminedHash(
    new ChartHash(chartA).Concat(new ChartHash(chartB))
);
```
