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
            Assert.Equal(0, Program.Compare("2H 3D 5S 9C KD", "2C 3D 5H 9S KH"));
        }
        
        [Fact]
        public void ShouldBlackWinsWhenWithHighCardA()
        {
            Assert.Equal(1, Program.Compare("2H 3D 5S 9C AD", "2C 3D 5H 9S KH"));
        }
    }
}