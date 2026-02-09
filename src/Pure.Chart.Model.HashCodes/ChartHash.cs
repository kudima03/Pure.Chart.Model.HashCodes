using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.Model.HashCodes;

public sealed record ChartHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        149,
        65,
        156,
        1,
        59,
        244,
        197,
        120,
        150,
        213,
        161,
        6,
        209,
        242,
        94,
        48,
    ];

    private readonly IChart _chart;

    public ChartHash(IChart chart)
    {
        _chart = chart;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix
                .Concat(new DeterminedHash(_chart.Title))
                .Concat(new DeterminedHash(_chart.Description))
                .Concat(new ChartTypeHash(_chart.Type))
                .Concat(new AxisHash(_chart.XAxis))
                .Concat(new AxisHash(_chart.YAxis))
                .Concat(new DeterminedHash(_chart.Series.Select(x => new SeriesHash(x))))
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
