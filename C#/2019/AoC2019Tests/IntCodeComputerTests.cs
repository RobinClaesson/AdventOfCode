using AoC2019Libraries;
using FluentAssertions;
using Newtonsoft.Json.Bson;

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

    [Test]
    public void Day5_Example1_Input42()
    {
        var target = new IntCodeComputer(TestInputs.Day5Example1);
        target.AddInput(42);

        target.Run();

        target.GetOutput().Should().Be(42);
    }

    [Test]
    public void Day5_Example1_Input13()
    {
        var target = new IntCodeComputer(TestInputs.Day5Example1);
        target.AddInput(13);

        target.Run();

        target.GetOutput().Should().Be(13);
    }

    [Test]
    public void Day5_Example2()
    {
        var target = new IntCodeComputer(TestInputs.Day5Example2);

        target.Run();

        target[0].Should().Be(1002);
        target[1].Should().Be(4);
        target[2].Should().Be(3);
        target[3].Should().Be(4);
        target[4].Should().Be(99);
    }

    [Test]
    public void Day5_Example3()
    {
        var target = new IntCodeComputer(TestInputs.Day5Example3);

        target.Run();

        target[0].Should().Be(1101);
        target[1].Should().Be(100);
        target[2].Should().Be(-1);
        target[3].Should().Be(4);
        target[4].Should().Be(99);
    }
}