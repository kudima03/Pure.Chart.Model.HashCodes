using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.Model.HashCodes;

public sealed record ChartTypeHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        132,
        65,
        156,
        1,
        204,
        63,
        32,
        117,
        135,
        123,
        81,
        182,
        151,
        95,
        46,
        129,
    ];

    private readonly IChartType _chartType;

    public ChartTypeHash(IChartType chartType)
    {
        _chartType = chartType;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix.Concat(new DeterminedHash(_chartType.Name))
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
