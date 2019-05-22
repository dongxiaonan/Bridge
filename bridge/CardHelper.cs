using System;

static internal class CardHelper
{
    public static int Convert(string number)
    {
        number = number.Remove(number.Length -1, 1);
        switch (number)
        {
            case "A": return 14; 
            case "K": return 13; 
            case "Q": return 12; 
            case "J": return 11; 
            default: return Int32.Parse(number);
        }
    }

    public static string Convert(int number)
    {
        switch (number)
        {
            case 14: return "Ace"; 
            case 13: return "K"; 
            case 12: return "Q"; 
            case 11: return "J"; 
            default: return number.ToString();
        }
    }
}