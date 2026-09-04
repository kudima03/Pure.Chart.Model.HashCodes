# Changelog

All notable changes to Pure.Chart.Model.HashCodes are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.1.0.0] — 2026-04-19

### Changed
- **`SeriesHash`** renamed to **`ChartSeriesHash`**, following the
  `ISeries` → `IChartSeries` rename in `Pure.Chart.Model.Abstractions`.
  Its constructor now takes `IChartSeries` instead of `ISeries`.
- Bumped `Pure.Chart.Model.Abstractions` and `Pure.Chart.Model`
  dependencies to `0.1.0-preview.1.0.0`.

## [0.1.0-preview.0.1.0] — 2026-02-09

Initial release.

### Added
- **`ChartHash`** — deterministic hash of an `IChart`, combining its
  title, description, `ChartTypeHash`, X/Y `AxisHash`, and per-item
  `SeriesHash` of its series.
- **`ChartTypeHash`** — deterministic hash of an `IChartType`, derived
  from its name.
- **`AxisHash`** — deterministic hash of an `IAxis`, derived from its
  legend.
- **`SeriesHash`** — deterministic hash of an `ISeries`, derived from
  its legend, X-axis source, and Y-axis source.

All hash types implement `IDeterminedHash` from `Pure.HashCodes.Abstractions`.
