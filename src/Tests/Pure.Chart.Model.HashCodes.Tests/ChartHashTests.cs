using System.Collections;
using Pure.Chart.Model.HashCodes.Tests.Doubles;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record ChartHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "C9925DD52F84A3EE886562FDEDFEC4D535DB5A843D2B4E9933F0C9D300202368",
            new HexString(
                new ChartHash(
                    new Chart(
                        new String("dfinvhj"),
                        new String("dfvmnkj"),
                        new ChartType(new String("dfvsnkji")),
                        new Axis(new String("wesdiokj")),
                        new Axis(new String("dfvmkoj")),
                        [
                            new FakeChartSeries(
                                new String("wesdoijf"),
                                new String("sdnijkufv"),
                                new String("qwmkioda"),
                                new String("solid")
                            ),
                            new FakeChartSeries(
                                new String("dfjuipovb"),
                                new String("qwnbhjklde"),
                                new String("fdvjbkgio"),
                                new String("dashed")
                            ),
                        ]
                    )
                )
            ).TextValue
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable hash = new ChartHash(
            new Chart(
                new String("dfinvhj"),
                new String("dfvmnkj"),
                new ChartType(new String("dfvsnkji")),
                new Axis(new String("wesdiokj")),
                new Axis(new String("dfvmkoj")),
                [
                    new FakeChartSeries(
                        new String("wesdoijf"),
                        new String("sdnijkufv"),
                        new String("qwmkioda"),
                        new String("solid")
                    ),
                    new FakeChartSeries(
                        new String("dfjuipovb"),
                        new String("qwnbhjklde"),
                        new String("fdvjbkgio"),
                        new String("dashed")
                    ),
                ]
            )
        );

        ICollection<byte> bytes = new List<byte>(32);

        foreach (object b in hash)
        {
            bytes.Add((byte)b);
        }

        Assert.Equal(
            "C9925DD52F84A3EE886562FDEDFEC4D535DB5A843D2B4E9933F0C9D300202368",
            Convert.ToHexString([.. bytes])
        );
    }
}
