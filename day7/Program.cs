// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using day7;

var ioInstructions = File.ReadAllLines("day7input.txt");

var aocFileSystem = ParseInstructions();

var res = aocFileSystem.GetAllSubDirectories().Where(a => a.Size <= 100000).Sum(a => a.Size);
Console.WriteLine($"part 1:{res}");

var spaceNeeded = 30000000 - (70000000 - aocFileSystem.Size);
var res2 = aocFileSystem.GetAllSubDirectories().Where(a => a.Size > spaceNeeded).OrderBy(o=>o.Size);

Console.WriteLine($"part 2:{res2.First().Size}");

AocDirectory ParseInstructions()
{
    var fs = new AocDirectory("/", null);
    AocDirectory currentDirectory = fs;
    
    string lastIns;
    foreach (var ins in ioInstructions.Skip(1))
    {
        if (ins.StartsWith("$ cd"))
        {
            if (ins.StartsWith("$ cd .."))
            {
                currentDirectory = currentDirectory.Parent;
            }
            else
            {
                var dirName = ins.Substring(5, ins.Length - 5);
                currentDirectory = currentDirectory.GoToSubDirectory(dirName);
            }
            continue;
            ;
        }
        if (ins.StartsWith("$ ls"))
        {
            continue;
        }        
        if (ins.StartsWith("dir "))
        {
            var newDir = new AocDirectory(ins.Substring(4, ins.Length - 4), currentDirectory);
            currentDirectory.Add(newDir);
            continue;
        }

        var regexMatches = Regex.Matches(ins, @"\d+");
        var fileSize = long.Parse(regexMatches.First().Value);
        var start = regexMatches.First().Value.Length + 1;
        var len = ins.Length - regexMatches.First().Value.Length -1;
        var newFile = new AocFile(fileSize, ins.Substring(start, len), currentDirectory);
        currentDirectory.Add(newFile);
    }

    return fs;
}