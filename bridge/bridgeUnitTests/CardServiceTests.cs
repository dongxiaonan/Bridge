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
    }

    
}