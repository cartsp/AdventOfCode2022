
int WLDcalc(string p1move, string p2move)
{
   switch (p1move)
   {
      case "A":
         switch (p2move)
         {
            case "X":
               return 3;
            case "Y":
               return 6;
            case "Z":
               return 0;
         }

         break;
      case "B":
         switch (p2move)
         {
            case "X":
               return 0;
            case "Y":
               return 3;
            case "Z":
               return 6;
         }

         break;
      default:
         switch (p2move)
         {
            case "X":
               return 6;
            case "Y":
               return 0;
            case "Z":
               return 3;
         }

         break;
   }

   throw new InvalidOperationException();
}

int CalcRoundWinner(string p1move, string p2move)
{
   //1 for Rock, 2 for Paper, and 3 for Scissors
   //0 if you lost, 3 if the round was a draw, and 6 if you won
   //X lose, Y means draw, and Z means you need to win
   switch (p1move)
   {
      case "A":
         switch (p2move)
         {
            case "X":
               return 3;
            case "Y":
               return 4;
            case "Z":
               return 8;
         }

         break;
      case "B":
         switch (p2move)
         {
            case "X":
               return 1;
            case "Y":
               return 5;
            case "Z":
               return 9;
         }

         break;
      default:
         switch (p2move)
         {
            case "X":
               return 2;
            case "Y":
               return 6;
            case "Z":
               return 7;
         }

         break;
   }

   throw new InvalidOperationException();
}

var gameStrat = File.ReadAllLines("day2input.txt");
var total = 0;
foreach (var round in gameStrat)
{
   var res = round.Split(" ");
   
   switch (res[1])
   {
      case "X":
         total += 1;
         break;
      case "Y":
         total += 2;
         break;
      case "Z":
         total += 3;
         break;
   }
   
   total += WLDcalc(res[0], res[1]);
   
}

var secondTotal = gameStrat.
   Select(round => round.Split(" "))
   .Select(res => CalcRoundWinner(res[0], res[1]))
   .Sum();

Console.WriteLine(total);
Console.WriteLine(secondTotal);