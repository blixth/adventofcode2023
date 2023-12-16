using AdventOfCode.Services.Interfaces;
using EnsureThat;

namespace AdventOfCode.Services;

public class AdventOfCodeService : IAdventOfCodeService
{
    private readonly IRegexService _regexService;

    public AdventOfCodeService(IRegexService regexService)
    {
        Ensure.Any.IsNotNull(regexService, nameof(regexService));

        _regexService = regexService;
    }

    public int GetPart1(IEnumerable<string> puzzleInput)
    {
        return puzzleInput
            .Select(row => _regexService.GetNumbersInString(row))
            .Select(numbers => int.Parse($"{numbers.First()}{numbers.Last()}"))
            .ToList()
            .Sum();
    }
}