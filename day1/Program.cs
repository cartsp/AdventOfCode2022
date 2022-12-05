// See https://aka.ms/new-console-template for more information

var elfCalories = File.ReadAllLines("input.txt");

var totals = new List<long>();
long cals = 0;

foreach (var calories in elfCalories)
{
    if (calories != string.Empty)
    {
        cals += long.Parse(calories);
    }
    else
    {
        totals.Add(cals);
        cals = 0;
    }
}

Console.WriteLine(totals.OrderDescending().First());

Console.WriteLine(totals.OrderDescending().Take(3).Sum());

