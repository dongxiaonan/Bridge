namespace bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int Compare(string blackCards, string whiteCards)
        {
            var black = GenerateCard(blackCards);
            var white = GenerateCard(whiteCards);

            return 0;
        }

        private static Card GenerateCard(string cards)
        {
            var cardService = new CardService();
            return cardService.Generate(cards);
        }
    }
}