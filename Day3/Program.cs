using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputLines = File.ReadLines("input.txt").ToList();

Part1();
Part2();

void Part1()
{
    var numberOfTreesHit = CalculateSlope(inputLines, goRight: 3, goDown: 1);

    Console.WriteLine($"Part 1 number of trees: {numberOfTreesHit}");
}

void Part2()
{
    var treeHitProduct = CalculateSlope(inputLines, goRight: 1, goDown: 1) *
                         CalculateSlope(inputLines, goRight: 3, goDown: 1) *
                         CalculateSlope(inputLines, goRight: 5, goDown: 1) *
                         CalculateSlope(inputLines, goRight: 7, goDown: 1) *
                         CalculateSlope(inputLines, goRight: 1, goDown: 2);

    Console.WriteLine($"Part 2 number of trees: {treeHitProduct}");
}

long CalculateSlope(List<string> list, int goRight, int goDown)
{
    {
        var treeMap = BuildTreeMap(list, goRight: goRight);
        var numberOfTreesHit = GetNumberOfTreesHit(treeMap, goRight: goRight, goDown: goDown);
        return numberOfTreesHit;
    }
}

char[,] BuildTreeMap(IReadOnlyList<string> lines, int goRight)
{
    // We go right 3 steps and down 1 step
    // If we want to be able to arrive to the end of the map we must create a rectangle with ratio 1x3
    var verticalMapEdge = lines.Count;
    var horizontalMapEdge = goRight * lines.Count;

    var map = new char[verticalMapEdge, horizontalMapEdge];

    foreach (var (row, rowIndex) in lines.Select((item, index) => (item, index)))
    {
        var rowCharArray = row.ToArray();
        for (int column = 0; column < horizontalMapEdge; column++)
        {
            var columnIndex = CalculateExtendedColumnIndex(rowCharArray.Length, column);
            map[rowIndex, column] = rowCharArray[columnIndex];
        }
    }

    return map;

    int CalculateExtendedColumnIndex(int lineLength, int newColumn)
    {
        while (true)
        {
            if (newColumn < lineLength)
            {
                return newColumn;
            }

            newColumn -= lineLength;
        }
    }
}

int GetNumberOfTreesHit(char[,] map, int goRight, int goDown)
{
    var numberOfTrees = 0;

    var upperBound = map.GetUpperBound(dimension: 0);

    var row = 0;
    var column = 0;
    while (true)
    {
        row += goDown;
        column += goRight;

        // We came to the vertical end of the map 
        if (row > upperBound)
        {
            return numberOfTrees;
        }

        var place = map[row, column];
        if (place == '#')
        {
            numberOfTrees++;
        }
    }
}