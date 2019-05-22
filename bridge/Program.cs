using System.Linq;

namespace bridge
{
    public class Program
    {
        public const string outputTemplate = "{0} wins - {1}: {2}";
        public static void Main(string[] args)
        {
        }

        public static string Compare(string blackCards, string whiteCards)
        {
            var black = GenerateCard(blackCards);
            var white = GenerateCard(whiteCards);

            var blackKeys = black.CardNumbers.Keys.ToList();
            var whiteKeys = white.CardNumbers.Keys.ToList();
            
            if (black.CardType == white.CardType && blackKeys.Count == whiteKeys.Count)
            {
                for (int i = 0; i < blackKeys.Count; i++)
                {
                    if (blackKeys[i] > whiteKeys[i])
                    {
                        return string.Format(outputTemplate, "Black", black.CardType.ToString(), CardService.ConvertCardNumber(blackKeys[i]));
                    }
                    
                    if (blackKeys[i] < whiteKeys[i])
                    {
                        return string.Format(outputTemplate, "White", white.CardType.ToString(), CardService.ConvertCardNumber(whiteKeys[i]));
                    }
                }
            }
            
            return "Tie";
        }

        private static Card GenerateCard(string cards)
        {
            var cardService = new CardService();
            return cardService.Generate(cards);
        }
    }
}