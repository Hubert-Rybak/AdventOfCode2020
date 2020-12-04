using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

Part1();
Part2();

void Part1()
{
    var ruleExtractRegex = new Regex(@"(?<minOccurrenceRequired>\d+)-(?<maxOccurrenceRequired>\d+)\s{1}(?<letter>[a-z])(:\s)(?<password>[a-z]+)",
        RegexOptions.Compiled);

    var validPasswords = File.ReadLines("input.txt").Count(IsValid);
    Console.WriteLine($"Part 1 valid passwords: {validPasswords}");

    bool IsValid(string line)
    {
        var match = ruleExtractRegex.Match(line);

        var password = match.Groups["password"].Value;
        var charToCheck = char.Parse(match.Groups["letter"].Value);
        var minOccurenceAllowed = int.Parse(match.Groups["minOccurrenceRequired"].Value);
        var maxOccurenceAllowed = int.Parse(match.Groups["maxOccurrenceRequired"].Value);

        var foundOccurrences = password.Count(c => c == charToCheck);
        return minOccurenceAllowed <= foundOccurrences && foundOccurrences <= maxOccurenceAllowed;
    }
}

void Part2()
{
    var ruleExtractRegex = new Regex(@"(?<firstExpectedPlace>\d+)-(?<secondExpectedPlace>\d+)\s{1}(?<letter>[a-z])(:\s)(?<password>[a-z]+)",
        RegexOptions.Compiled);
    
    var validPasswords = File.ReadLines("input.txt").Count(IsValid);
    Console.WriteLine($"Part 2 valid passwords: {validPasswords}");
    
    bool IsValid(string line)
    {
        var match = ruleExtractRegex.Match(line);
        
        var password = match.Groups["password"].Value;
        var expectedChar = char.Parse(match.Groups["letter"].Value);
        var firstExpectedPlace = int.Parse(match.Groups["firstExpectedPlace"].Value);
        var secondExpectedPlace = int.Parse(match.Groups["secondExpectedPlace"].Value);

        var passwordArray = password.ToArray();
        
        var isFirstCharValid = passwordArray[firstExpectedPlace - 1] == expectedChar;
        var isSecondCharValid = passwordArray[secondExpectedPlace - 1] == expectedChar;
        
        return isFirstCharValid && !isSecondCharValid || !isFirstCharValid && isSecondCharValid;
    }
}