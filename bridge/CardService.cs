using System.Collections.Generic;
using System.Linq;

namespace bridge
{
    public class CardService
    {
        public Card Generate(string card)
        {
            var generateCard = new Card();
            var cardInfo = card.Split(' ').ToList();
            var cardNumbers = cardInfo.Select(x => ConvertCardNumber(x)).OrderBy(x => x).ToList();
            var cardColors = cardInfo.Select(x => x.Last().ToString()).ToList();

            generateCard.CardNumbers = GetCardNumbers(cardNumbers);
            generateCard.CardType = GetCardType(generateCard.CardNumbers, cardColors);

            return generateCard;
        }

        private int ConvertCardNumber(string number)
        {
            number = number.Remove(number.Length -1, 1);
            switch (number)
            {
                case "A": return 14; 
                case "K": return 13; 
                case "Q": return 12; 
                case "J": return 11; 
                default: return int.Parse(number);
            }
        }
        
        public static string ConvertCardNumber(int number)
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

        private static CardType GetCardType(Dictionary<int, int> sameNumber, List<string> cardColors)
        {
            var cardType = CardType.HighCard;
            var isFlush = cardColors.Distinct().Count() == 1;

            var sameNumberKeys = sameNumber.Keys.ToList();
            var isStraight = sameNumberKeys.Count == 5;
            for (int i = 1; i < sameNumberKeys.Count; i++)
            {
                isStraight = isStraight && (sameNumberKeys[i] - sameNumberKeys[i - 1] == 1);
            }

            switch (sameNumber.Keys.Count)
            {
                case 2:
                    cardType = sameNumber.Values.Contains(4) ? CardType.FourOfAKind : CardType.FullHouse;
                    break;
                case 3:
                    cardType = CardType.TwoPairs;
                    break;
                case 4:
                    cardType = CardType.OnePair;
                    break;
                case 5:
                    cardType = isFlush ? (isStraight ?  CardType.StraightFlush : CardType.Flush) : (isStraight ? CardType.Straight : CardType.HighCard);
                    break;
            }

            return cardType;
        }

        private static Dictionary<int, int> GetCardNumbers(List<int> cardNumbers)
        {
            var sameNumber = new Dictionary<int, int>()
            {
                {cardNumbers[0], 1}
            };


            for (int i = 1; i < cardNumbers.Count; i++)
            {
                if (sameNumber.ContainsKey(cardNumbers[i]))
                {
                    sameNumber[cardNumbers[i]]++;
                }
                else
                {
                    sameNumber.Add(cardNumbers[i], 1);
                }
            }

            return sameNumber;
        }
    }
}
