using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

const int expectedSum = 2020;

var entries = File.ReadLines("input.txt").Select(int.Parse).ToHashSet();

PartOne(entries);
PartTwo(entries);

// 2020 = x + z
// y = x * z
void PartOne(HashSet<int> entriesMap)
{
    foreach (var expectedX in entriesMap)
    {
        var y = expectedSum - expectedX;
        if (entriesMap.TryGetValue(y, out var foundY))
        {
            Console.WriteLine($"Part 1 result: {expectedX * foundY}");
            return;
        }
    }
}

// 2020 = x + z + q
// y = x * z * q
void PartTwo(HashSet<int> entriesMap)
{
    foreach (var expectedX in entriesMap)
    {
        var expectedZAndQ = expectedSum - expectedX;
        foreach (var expectedZ in entriesMap)
        {
            var expectedQ = expectedZAndQ - expectedZ;
            if (!entries.Contains(expectedQ))
            {
                continue;
            }

            Console.WriteLine($"Part 2 result: {expectedX * expectedZ * expectedQ}");
            return;
        }
    }
}