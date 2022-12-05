using System.Text.RegularExpressions;

namespace day5;

public static class InstructionsParser
{
    public static (List<List<char>>stacks, List<List<int>> operations) ParseInstructions(string input)
    {
        List<List<char>> stacks = new();

        var (unparsedStack, unparsedInstructions) = SplitInstructionFile(input);

        PopulateStacks(unparsedStack, stacks);

        var parsedInstructions = PopulateInstructions(unparsedInstructions);

        return (stacks, parsedInstructions);
    }

    private static List<List<int>> PopulateInstructions(string[] unparsedInstructions)
    {
        var parsedInstructions = new List<List<int>>();

        foreach (var line in unparsedInstructions)
        {
            if(string.IsNullOrWhiteSpace(line)) continue;
            var ins = Regex.Split(line, @"\D+");
            var tempNums = new List<int>();

            foreach (var num in ins)
            {
                if (string.IsNullOrWhiteSpace(num)) continue;
                tempNums.Add(int.Parse(num));
            }

            parsedInstructions.Add(tempNums);
        }

        return parsedInstructions;
    }

    private static void PopulateStacks(string[] unparsedStack, List<List<char>> stacks)
    {
        var stackCount = GetStackCount(unparsedStack);

        InitStacks(stackCount, stacks);
        
        for (var index = 0; index < unparsedStack.Length - 1; index++)
        {
            var line = unparsedStack[index];
            for (int i = 0; i < line.Length; i += 4)
            {
                var cellContents = line.Substring(i, 3);

                if (string.IsNullOrWhiteSpace(cellContents))
                    continue;

                var stackToPopulate = i / 4;

                stacks[stackToPopulate].Add(cellContents[1]);
            }
        }

        foreach (var list in stacks)
        {
            list.Reverse();
        }
    }

    private static void InitStacks(int stackCount, List<List<char>> stacks)
    {
        for (var i = 0; i < stackCount; i++)
        {
            stacks.Add(new List<char>());
        }
    }

    private static int GetStackCount(string[] unparsedStack)
    {
        return unparsedStack
            .Last()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .OrderDescending()
            .First();
    }

    private static (string[] val1, string[] val2) SplitInstructionFile(string input)
    {
        var res = input.Split(new[] { "\n\n" }, StringSplitOptions.None);
        return (res[0].Split(new[] { "\n" }, StringSplitOptions.None), 
            res[1].Split(new[] { "\n" }, StringSplitOptions.None));
    }
}