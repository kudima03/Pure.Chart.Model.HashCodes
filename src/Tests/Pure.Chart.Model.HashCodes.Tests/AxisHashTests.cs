using System.Collections;
using Pure.Primitives.String.Operations;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.Model.HashCodes.Tests;

public sealed record AxisHashTests
{
    [Fact]
    public void Determined()
    {
        Assert.Equal(
            "DDCDC18D002659E4FDCD79256F691AC682326FA077D9E18D0F9696D09A3ADD31",
            new HexString(new AxisHash(new Axis(new String("fhbnuiglvj")))).TextValue
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IEnumerable hash = new AxisHash(new Axis(new String("fhbnuiglvj")));

        ICollection<byte> bytes = new List<byte>(32);

        foreach (object b in hash)
        {
            bytes.Add((byte)b);
        }

        Assert.Equal(
            "DDCDC18D002659E4FDCD79256F691AC682326FA077D9E18D0F9696D09A3ADD31",
            Convert.ToHexString([.. bytes])
        );
    }
}
