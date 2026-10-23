using System.Collections;
using Pure.Chart.Model.HashCodes.Tests.Doubles;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record ChartSeriesHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "58BD5668305D6F7B6E2C880D34B307EE60CE1C3DFBFB3DA3C8E2DA87999E62CA",
            new HexString(
                new ChartSeriesHash(
                    new FakeChartSeries(
                        new String("rtfgnbhju"),
                        new String("efrhisuyodn"),
                        new String("dfvbjnkhil"),
                        new String("dashed")
                    )
                )
            ).TextValue
        );
    }

    [Fact]
    public void LineTypeAffectsHash()
    {
        Assert.NotEqual(
            new HexString(
                new ChartSeriesHash(
                    new FakeChartSeries(
                        new String("rtfgnbhju"),
                        new String("efrhisuyodn"),
                        new String("dfvbjnkhil"),
                        new String("solid")
                    )
                )
            ).TextValue,
            new HexString(
                new ChartSeriesHash(
                    new FakeChartSeries(
                        new String("rtfgnbhju"),
                        new String("efrhisuyodn"),
                        new String("dfvbjnkhil"),
                        new String("dotted")
                    )
                )
            ).TextValue
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable hash = new ChartSeriesHash(
            new FakeChartSeries(
                new String("rtfgnbhju"),
                new String("efrhisuyodn"),
                new String("dfvbjnkhil"),
                new String("dashed")
            )
        );

        ICollection<byte> bytes = new List<byte>(32);

        foreach (object b in hash)
        {
            bytes.Add((byte)b);
        }

        Assert.Equal(
            "58BD5668305D6F7B6E2C880D34B307EE60CE1C3DFBFB3DA3C8E2DA87999E62CA",
            Convert.ToHexString([.. bytes])
        );
    }
}
