using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.Model.HashCodes.Tests.Doubles;

internal sealed record FakeChartSeries : IChartSeries
{
    public FakeChartSeries(
        IString legend,
        IString xAxisSource,
        IString yAxisSource,
        IString lineType
    )
    {
        Legend = legend;
        XAxisSource = xAxisSource;
        YAxisSource = yAxisSource;
        LineType = lineType;
    }

    public IString Legend { get; }

    public IString XAxisSource { get; }

    public IString YAxisSource { get; }

    public IString LineType { get; }
}
