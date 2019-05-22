using bridge;
using Xunit;

namespace bridgeUnitTests
{
    public class CardServiceTests
    {
        [Fact]
        public void ShouldGenerateCardWithTypeWhenHighCard()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3D 5S 9H KD");
            Assert.Equal(CardType.HighCard, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenFullHouse()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3D 2S 3H 2D");
            Assert.Equal(CardType.FullHouse, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenOnePair()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3D 2S 4H 7D");
            Assert.Equal(CardType.OnePair, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenTwoPair()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3D 2S 3H 7D");
            Assert.Equal(CardType.TwoPairs, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenFourOfAKind()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 2D 2S 2C 7D");
            Assert.Equal(CardType.FourOfAKind, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenFlush()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3H 9H 4H 7H");
            Assert.Equal(CardType.Flush, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenStraight()
        {
            var cardService = new CardService();
            var card = cardService.Generate("10H JD QS KH AD");
            Assert.Equal(CardType.Straight, card.CardType);
        }
        
        [Fact]
        public void ShouldGenerateCardWithTypeWhenStraightFlush()
        {
            var cardService = new CardService();
            var card = cardService.Generate("2H 3H 5H 4H 6H");
            Assert.Equal(CardType.StraightFlush, card.CardType);
        }
    }

    
}