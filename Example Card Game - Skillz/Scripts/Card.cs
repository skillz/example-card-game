using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
  public enum ranks { TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE };
  public enum suits { HEARTS, CLUBS, DIAMONDS, SPADES }
  public ranks rank { get; }
  public suits suit { get; }

  public Card(ranks rank, suits suite)
  {
    this.rank = rank;
    this.suit = suite;
  }

  public override string ToString()
  {
    return "(" + rank.ToString() + " of " + suit.ToString() + ")";
  }
}
