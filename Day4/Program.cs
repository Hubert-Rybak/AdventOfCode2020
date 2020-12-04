using System;
using System.IO;
using Day4;
using Day4.Validation;

Part1();
Part2();

void Part1()
{
    var validPassports = 0;
    var passport = new Passport();
    foreach (var line in File.ReadLines("input.txt"))
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            passport.AddData(line);
        }
        else
        {
            if (passport.IsValid())
            {
                validPassports++;
            }

            passport = new Passport();
        }
    }

    if (passport.IsValid())
    {
        validPassports++;
    }
    
    Console.WriteLine($"Part 1 valid passports {validPassports}");
}

void Part2()
{
    var validPassports = 0;
    var passport = Passport.CreateWithValidationRules();
    
    foreach (var line in File.ReadLines("input.txt"))
    {
        if (!string.IsNullOrWhiteSpace(line))
        {
            passport.AddData(line);
        }
        else
        {
            if (passport.IsValid())
            {
                validPassports++;
            }

            passport = Passport.CreateWithValidationRules();;
        }
    }

    if (passport.IsValid())
    {
        validPassports++;
    }
    
    Console.WriteLine($"Part 1 valid passports {validPassports}");
}