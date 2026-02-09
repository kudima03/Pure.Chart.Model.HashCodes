using System.Collections;
using Pure.Chart.Model.Abstractions;
using Pure.HashCodes;
using Pure.HashCodes.Abstractions;

namespace Pure.Chart.Model.HashCodes;

public sealed record AxisHash : IDeterminedHash
{
    private static readonly byte[] TypePrefix =
    [
        139,
        65,
        156,
        1,
        6,
        39,
        19,
        120,
        186,
        142,
        248,
        153,
        168,
        252,
        195,
        238,
    ];

    private readonly IAxis _axis;

    public AxisHash(IAxis axis)
    {
        _axis = axis;
    }

    public IEnumerator<byte> GetEnumerator()
    {
        return new DeterminedHash(
            TypePrefix.Concat(new DeterminedHash(_axis.Legend))
        ).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
