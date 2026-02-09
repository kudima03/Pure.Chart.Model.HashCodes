using System.Collections;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record ChartTypeHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "FF661928963AB452AD3C16B79B6F6FC7871BFFD664D41CEE6C39F0151DABCAB0",
            new HexString(
                new ChartTypeHash(new ChartType(new String("fhbnuiglvj")))
            ).TextValue
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable hash = new ChartTypeHash(new ChartType(new String("fhbnuiglvj")));

        ICollection<byte> bytes = new List<byte>(32);

        foreach (object b in hash)
        {
            bytes.Add((byte)b);
        }

        Assert.Equal(
            "FF661928963AB452AD3C16B79B6F6FC7871BFFD664D41CEE6C39F0151DABCAB0",
            Convert.ToHexString([.. bytes])
        );
    }
}
