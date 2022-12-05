using System.Text.RegularExpressions;
using day5;

var assignments = File.ReadAllText("day5input.txt");

var (stacks, instructions) = InstructionsParser.ParseInstructions(assignments);

for (var index = 0; index < instructions.Count; index++)
{
    var order = instructions[index];
    var rangeToMove = stacks[order[1]-1].GetRange(stacks[order[1]-1].Count - order[0], order[0]);
    stacks[order[1]-1].RemoveRange(stacks[order[1]-1].Count - order[0], order[0]);
    //rangeToMove.Reverse();
    stacks[order[2]-1].AddRange(rangeToMove);
}

var c = stacks.Select(a => a.Last());

var b = 1;