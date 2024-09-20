using AoC2019Libraries;
using FluentAssertions;

namespace AoC2019Tests;

public class IntCodeComputerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Day2_Part1()
    {
        var target = new IntCodeComputer(TestInputs.Day2Program, 12, 2);

        target.Run();

        target[0].Should().Be(2894520);
    }
}