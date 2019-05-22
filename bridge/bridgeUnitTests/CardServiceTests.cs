using bridge;
using bridge.model;
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
        
        [Fact]
        public void ShouldTieWhenSameHighCards()
        {
            var cardService = new CardService();

            Assert.Equal("Tie", cardService.Excute("2H 3D 5S 9C KD", "2C 3D 5H 9S KH"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWithHighCardA()
        {            
            var cardService = new CardService();

            Assert.Equal("Black wins - HighCard: Ace", cardService.Excute("2H 3D 5S 9C AD", "2C 3D 5H 9S KH"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWitFullHouse()
        {
            var cardService = new CardService();

            Assert.Equal("White wins - FullHouse: 4", cardService.Excute("2H 3D 2S 2C 3C", "4C 4D 4H 9S 9H"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWitDifferentTypeAndBlackIsFullHouse()
        {
            var cardService = new CardService();

            Assert.Equal("White wins - FullHouse", cardService.Excute("9C 3D 5H 9S KH","2H 3D 2S 2C 3C"));
        }
    }

    
}