using System.Text.RegularExpressions;
using AdventOfCode.Services.Interfaces;

namespace AdventOfCode.Services;

public class RegexService : IRegexService
{
    public string GetNumbersInString(string input) => string.Join("", Regex.Matches(input, @"\d+"));
}