using System;
using System.IO;
using System.Linq;

// 2020 = x + y
// y = x * y

var expectedSum = 2020;

var entries = File.ReadAllLines("input.txt").Select(int.Parse).ToHashSet();

foreach (var foundX in entries)
{
    var y = expectedSum - foundX;
    if (entries.TryGetValue(y, out var foundY))
    {
        Console.WriteLine($"Result: {foundX * foundY}");
        return;
    }
}