using System.Collections.Generic;

namespace bridge
{
    public class Card
    {
        public CardType CardType { get; set; }
        
        public Dictionary<int, int> CardNumbers { get; set; }
    }
}