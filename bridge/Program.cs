using System.Linq;

namespace bridge
{
    public class Program
    {
        public const string sameTypeOutputTemplate = "{0} wins - {1}: {2}";
        public const string diffTypeOutputTemplate = "{0} wins - {1}";
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
                        return string.Format(sameTypeOutputTemplate, "Black", black.CardType.ToString(), CardService.ConvertCardNumber(blackKeys[i]));
                    }
                    
                    if (blackKeys[i] < whiteKeys[i])
                    {
                        return string.Format(sameTypeOutputTemplate, "White", white.CardType.ToString(), CardService.ConvertCardNumber(whiteKeys[i]));
                    }
                }
            }
            else
            {
                if (black.CardType > white.CardType)
                {
                    return string.Format(diffTypeOutputTemplate, "Black", black.CardType.ToString());
                }
                
                if (black.CardType < white.CardType)
                {
                    return string.Format(diffTypeOutputTemplate, "White", white.CardType.ToString());
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