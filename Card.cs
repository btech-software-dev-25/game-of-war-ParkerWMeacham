namespace GameOfWar
{
    public class Card
    {
        public string Suit { get; private set; }
        public int Rank { get; private set; }  // 0 = Two, 12 = Ace

        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static bool operator >(Card c1, Card c2)
        {
            return c1.Rank > c2.Rank;
        }

        public static bool operator <(Card c1, Card c2)
        {
            return c1.Rank < c2.Rank;
        }

        public string RankString()
        {
            string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10",
                               "Jack", "Queen", "King", "Ace" };
            return names[Rank];
        }
    }
}
