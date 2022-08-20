using System;

namespace SortingCards;

public class Card : IComparable<Card> {
    public int rank = 0;
    public int suit = 0;

    public Card(int rank, int suit) {
        this.rank = rank;
        this.suit = suit;
    }

    public int CompareTo(Card c) {
        //as pr the CompareTo implementation @Microsoft
        if (c == null) return 1;

        //Creating an instance of the other card
        Card otherCard = c as Card;

        //rank[1,13]
        //suit[1,4]

        //not sure if this is pretty but it works
        //only compare rank if suits are the same, else compare rank

        if (this.suit == otherCard.suit){
            if (this.rank < otherCard.rank){
                return -1;
            } 
            else return 1;
        } 
        else
            {
            if (this.suit < otherCard.suit){
                return -1;
            } 
            else return 1;
        }
    }

    public override string ToString() {
        return $"{this.rank}, {this.suit}";
    }
}