using System;
using bridge;
using Xunit;

namespace bridgeUnitTests
{
    public class Tests
    {
        [Fact]
        public void ShouldTieWhenSameHighCards()
        {
            Assert.Equal("Tie", Program.Compare("2H 3D 5S 9C KD", "2C 3D 5H 9S KH"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWithHighCardA()
        {
            Assert.Equal("Black wins - HighCard: Ace", Program.Compare("2H 3D 5S 9C AD", "2C 3D 5H 9S KH"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWitFullHouse()
        {
            Assert.Equal("White wins - FullHouse: 4", Program.Compare("2H 3D 2S 2C 3C", "4C 4D 4H 9S 9H"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWitDifferentTypeAndBlackIsFullHouse()
        {
            Assert.Equal("Black wins - FullHouse", Program.Compare("2H 3D 2S 2C 3C", "9C 3D 5H 9S KH"));
        }
    }
}