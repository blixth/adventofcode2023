using AdventOfCode.Services;
using FluentAssertions;

namespace AdventOfCodeTests.Services;

public class AdventOfCodeServiceTests
{
    private readonly AdventOfCodeService _adventOfCodeService;

    public AdventOfCodeServiceTests()
    {
        var regexService = new RegexService();

        _adventOfCodeService = new AdventOfCodeService(regexService);
    }

    [Fact]
    public void GetPart1_Example1()
    {
        var puzzleInput = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        };

        var result = _adventOfCodeService.GetPart1(puzzleInput);

        result.Should().Be(142);
    }
}