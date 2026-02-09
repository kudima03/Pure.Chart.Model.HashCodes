using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.Model.HashCodes;

public sealed record SeriesHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        142,
        65,
        156,
        1,
        109,
        170,
        226,
        118,
        166,
        39,
        114,
        109,
        64,
        11,
        90,
        187,
    ];

    private readonly ISeries _series;

    public SeriesHash(ISeries series)
    {
        _series = series;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix
                .Concat(new DeterminedHash(_series.Legend))
                .Concat(new DeterminedHash(_series.XAxisSource))
                .Concat(new DeterminedHash(_series.YAxisSource))
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
