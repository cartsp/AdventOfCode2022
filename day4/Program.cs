var assignments = File.ReadAllLines("day4input.txt");

var part1 = assignments
    .Select(a => a.Split(',')).Select(a =>
    {
        var firstNums = a[0].Split('-');
        var secondNums = a[1].Split('-');
        var firstLower = int.Parse(firstNums[0]);
        var firstUpper = int.Parse(firstNums[1]);
        
        var secondLower = int.Parse(secondNums[0]);
        var secondUpper = int.Parse(secondNums[1]);

        if (firstLower >= secondLower && firstUpper <= secondUpper)
            return true;
        
        return secondLower >= firstLower && secondUpper <= firstUpper;
    })
    .Count(a => a);                    

var part2 = assignments
    .Select(a => a.Split(',')).Select(a =>
    {
        var firstNums = a[0].Split('-');
        var secondNums = a[1].Split('-');
        var firstLower = int.Parse(firstNums[0]);
        var firstUpper = int.Parse(firstNums[1]);
        
        var secondLower = int.Parse(secondNums[0]);
        var secondUpper = int.Parse(secondNums[1]);
        
        //(firstUpper >= secondLower && secondUpper >= firstLower);
        
        return firstLower >= secondLower && firstLower <= secondUpper ||
               (firstUpper >= secondLower && firstUpper <= secondUpper) ||
               (secondLower >= firstLower && secondLower <= firstUpper) ||
               (secondUpper >= firstLower && secondUpper <= firstUpper);
    })
    .Count(a => a);      

Console.WriteLine(part1);
Console.WriteLine(part2);