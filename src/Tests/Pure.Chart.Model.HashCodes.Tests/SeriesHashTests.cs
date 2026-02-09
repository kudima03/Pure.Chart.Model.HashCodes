using System.Collections;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record SeriesHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "AE644C66047BCE80C1AFD870147090D5710E130BC4B47098F6FD86467E6B06C6",
            new HexString(
                new SeriesHash(
                    new Series(
                        new String("rtfgnbhju"),
                        new String("efrhisuyodn"),
                        new String("dfvbjnkhil")
                    )
                )
            ).TextValue
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable hash = new SeriesHash(
            new Series(
                new String("rtfgnbhju"),
                new String("efrhisuyodn"),
                new String("dfvbjnkhil")
            )
        );

        ICollection<byte> bytes = new List<byte>(32);

        foreach (object b in hash)
        {
            bytes.Add((byte)b);
        }

        Assert.Equal(
            "AE644C66047BCE80C1AFD870147090D5710E130BC4B47098F6FD86467E6B06C6",
            Convert.ToHexString([.. bytes])
        );
    }
}
