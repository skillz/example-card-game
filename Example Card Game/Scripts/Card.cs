using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
  public enum ranks { TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE };
  public enum suites { HEARTS, CLUBS, DIAMONDS, SPADES }
  public ranks rank { get; }
  public suites suite { get; }

  public Card(ranks rank, suites suite)
  {
    this.rank = rank;
    this.suite = suite;
  }

  public override string ToString()
  {
    return "(" + rank.ToString() + " of " + suite.ToString() + ")";
  }
}
