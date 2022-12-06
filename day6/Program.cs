var signal = File.ReadAllText("day6input.txt");

var signalArray = signal.ToCharArray();

var part1 = DistinctPoisition(4);
Console.WriteLine($"Part 1: {part1}");

var part2 = DistinctPoisition(14);
Console.WriteLine($"Part 2: {part2}");

int DistinctPoisition(int range)
{
    for (int i = 0; i < signalArray.Length; i++)
    {
        var distinctSignalCount = signal.Skip(i).Take(range).Distinct().Count();
        if (distinctSignalCount == range)
        {
            return i + range;
        }
    }

    return 0;
}