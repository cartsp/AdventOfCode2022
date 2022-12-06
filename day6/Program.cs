var signal = File.ReadAllText("day6input.txt");

var part1 = DistinctPosition(4);
Console.WriteLine($"Part 1: {part1}");

var part2 = DistinctPosition(14);
Console.WriteLine($"Part 2: {part2}");

int DistinctPosition(int range)
{
    for (int i = 0; i < signal.Length; i++)
    {
        var distinctSignalCount = signal.Skip(i).Take(range).Distinct().Count();
        if (distinctSignalCount == range)
        {
            return i + range;
        }
    }

    return 0;
}