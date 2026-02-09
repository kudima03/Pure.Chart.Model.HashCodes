using System.Collections;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record ChartHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "43265193734B4F789C5F3231B7963CB1A1B8A974444C0B00771C8BD970418095",
            new HexString(
                new ChartHash(
                    new Chart(
                        new String("dfinvhj"),
                        new String("dfvmnkj"),
                        new ChartType(new String("dfvsnkji")),
                        new Axis(new String("wesdiokj")),
                        new Axis(new String("dfvmkoj")),
                        [
                            new Series(
                                new String("wesdoijf"),
                                new String("sdnijkufv"),
                                new String("qwmkioda")
                            ),
                            new Series(
                                new String("dfjuipovb"),
                                new String("qwnbhjklde"),
                                new String("fdvjbkgio")
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
                    new Series(
                        new String("wesdoijf"),
                        new String("sdnijkufv"),
                        new String("qwmkioda")
                    ),
                    new Series(
                        new String("dfjuipovb"),
                        new String("qwnbhjklde"),
                        new String("fdvjbkgio")
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
            "43265193734B4F789C5F3231B7963CB1A1B8A974444C0B00771C8BD970418095",
            Convert.ToHexString([.. bytes])
        );
    }
}
