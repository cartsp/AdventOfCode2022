var sackContents = File.ReadAllLines("day3input.txt");

char[] CreateLookupArray()
{
    List<char> list = new() { '_' };
    var lower = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
    var upper = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
    list.AddRange(lower);
    list.AddRange(upper);
    return list.ToArray();
}

(char[] compartment1, char[] compartment2) GetCompartments(char[] bagitems)
{
    var mid = bagitems.Length / 2;
    return (bagitems[0..mid], bagitems[mid..bagitems.Length]);
} 

var lookup = CreateLookupArray();

var tot = 0;
foreach (var line in sackContents)
{
    var cArray = line.ToCharArray();
    var (a, b) = GetCompartments(cArray);
    var same = a.Intersect(b);
    var score = Array.IndexOf(lookup, same.First());
    tot += score;
}

var newTot = 0;
for (var i = 0; i < sackContents.Length; i += 3)
{
    var items = sackContents.Skip(i).Take(3).ToArray(); 
    var same = items[0].Intersect(items[1]).Intersect(items[2]);
    
    var score = Array.IndexOf(lookup, same.First());
    newTot += score;
}

Console.WriteLine(tot);
Console.WriteLine(newTot);