using System.Collections.Generic;
using System.Linq;
using bridge.model;

namespace bridge
{
    public class CardService
    {
        public Card Generate(string card)
        {
            var cardInfo = card.Split(' ').ToList();
            var cardNumbers = cardInfo.Select(CardHelper.Convert).OrderBy(x => x).ToList();
            var cardColors = cardInfo.Select(x => x.Last().ToString()).ToList();

            var generateCardNumbers = GetCardNumbers(cardNumbers);
            return new Card()
            {
                CardNumbers = generateCardNumbers,
                CardType = GetCardType(generateCardNumbers, cardColors)
            };
        }

        private CardType GetCardType(Dictionary<int, int> sameNumber, List<string> cardColors)
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

        private Dictionary<int, int> GetCardNumbers(List<int> cardNumbers)
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

        private List<Player> InitializePlayers(string blackCards, string whiteCards)
        {
            return new List<Player>()
            {
                new Player()
                {
                    Name = "Black",
                    Card = Generate(blackCards)
                }, 
                new Player()
                {
                    Name = "White",
                    Card = Generate(whiteCards)
                }
            };
        }
        
        public string Excute(string blackCards, string whiteCards)
        {
            var playerList = InitializePlayers(blackCards, whiteCards)
                .OrderByDescending(p => p.Card.CardType)
                .ToList();

            return Compare(playerList);
        }

        private static string Compare(List<Player> playerList)
        {
            if (playerList.First().Card.CardType == playerList.Last().Card.CardType)
            {
                var black = playerList.First();
                var white = playerList.Last();

                var blackKeys = black.Card.CardNumbers.Keys.ToList();
                var whiteKeys = white.Card.CardNumbers.Keys.ToList();
                for (var i = 0; i < blackKeys.Count; i++)
                {
                    if (blackKeys[i] > whiteKeys[i])
                    {
                        return $"{black.Name} wins - {black.Card.CardType.ToString()}: {CardHelper.Convert(blackKeys[i])}";
                    }

                    if (blackKeys[i] < whiteKeys[i])
                    {
                        return $"{white.Name} wins - {white.Card.CardType.ToString()}: {CardHelper.Convert(whiteKeys[i])}";
                    }
                }
            }
            else
            {
                return $"{playerList.First().Name} wins - {playerList.First().Card.CardType.ToString()}";
            }

            return "Tie";
        }
    }
}
