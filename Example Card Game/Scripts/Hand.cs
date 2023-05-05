using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
  public enum HandType { EMPTY, HIGH_CARD, TWO_OF_A_KIND, TWO_PAIR, THREE_OF_A_KIND, STRAIGHT, FLUSH, FULL_HOUSE, FOUR_OF_A_KIND, STRAIGHT_FLUSH, ROYAL_FLUSH }

  public HandType handType;
  public Card.ranks highRank;
  public List<Card> cards;

  private List<Card> cardsLessWilds;
  private int wildCount;

  public Hand()
  {
    cards = new List<Card>();
  }

  public void AddCard(Card card)
  {
    cards.Add(card);
    UpdateHandType();
  }

  public void ClearHand()
  {
    cards.Clear();
    UpdateHandType();
  }

  private void UpdateHandType()
  {
    if (cards.Count == 0)
    {
      handType = HandType.EMPTY;
      highRank = Card.ranks.TWO;
      return;
    }

    cardsLessWilds = new List<Card>();
    CountAndRemoveWilds(Manager.game.deckController.deck.wild);

    if (Straight(true) && Flush())
    {
      handType = HandType.ROYAL_FLUSH;
      return;
    }

    if (Straight() && Flush())
    {
      handType = HandType.STRAIGHT_FLUSH;
      return;
    }

    if (OfAKind(4))
    {
      handType = HandType.FOUR_OF_A_KIND;
      return;
    }

    if (OfAKind(3) && OfAKind(2) && cards.Count == 5 || wildCount == 1 && TwoPair(false) && cards.Count == 5)
    {
      handType = HandType.FULL_HOUSE;
      return;
    }

    if (Flush())
    {
      handType = HandType.FLUSH;
      return;
    }

    if (Straight())
    {
      handType = HandType.STRAIGHT;
      return;
    }

    if (OfAKind(3))
    {
      handType = HandType.THREE_OF_A_KIND;
      return;
    }

    if (TwoPair())
    {
      handType = HandType.TWO_PAIR;
      return;
    }

    if (OfAKind(2))
    {
      handType = HandType.TWO_OF_A_KIND;
      return;
    }

    highRank = (Card.ranks)HighestRank(true);
    handType = HandType.HIGH_CARD;
  }

  private void CountAndRemoveWilds(Card.ranks wild)
  {
    wildCount = 0;
    foreach (Card c in cards)
    {
      if (c.rank == wild)
      {
        wildCount++;
      }
      else
      {
        cardsLessWilds.Add(c);
      }
    }
  }

  private bool OfAKind(int amount)
  {
    Dictionary<int, int> sortedCards = new Dictionary<int, int>();
    foreach (Card c in cardsLessWilds)
    {
      if (sortedCards.ContainsKey((int)c.rank))
      {
        sortedCards[(int)c.rank] += 1;
      }
      else
      {
        sortedCards.Add((int)c.rank, 1);
      }
    }
    foreach (int i in sortedCards.Keys)
    {
      int numcards = sortedCards[i];

      if ((sortedCards[i] + wildCount) == amount)
      {
        return true;
      }

      if (sortedCards[i] + wildCount == 5 && amount == 4)
      {
        return true;
      }
    }
    return false;
  }

  private bool TwoPair(bool useWilds = true)
  {
    Dictionary<int, int> sortedCards = new Dictionary<int, int>();
    foreach (Card c in cardsLessWilds)
    {
      if (sortedCards.ContainsKey((int)c.rank))
      {
        sortedCards[(int)c.rank] += 1;
      }
      else
      {
        sortedCards.Add((int)c.rank, 1);
      }
    }
    int pairCount = 0;
    foreach (int i in sortedCards.Keys)
    {
      if (sortedCards[i] == 2)
      {
        pairCount++;
      }
    }

    if (useWilds && wildCount > 0)
    {
      foreach (int i in sortedCards.Keys)
      {
        if (sortedCards[i] == 1)
        {
          pairCount++;
          return pairCount == 2;
        }
      }
    }
    return pairCount == 2;
  }

  private bool Flush()
  {
    Dictionary<int, int> sortedCards = new Dictionary<int, int>();
    foreach (Card c in cardsLessWilds)
    {
      if (sortedCards.ContainsKey((int)c.suite))
      {
        sortedCards[(int)c.suite] += 1;
      }
      else
      {
        sortedCards.Add((int)c.suite, 1);
      }
    }
    foreach (int i in sortedCards.Keys)
    {
      if (sortedCards[i] + wildCount == 5)
      {
        return true;
      }
    }
    return false;
  }

  private bool Straight(bool checkForRoyals = false)
  {
    int highestRank = HighestRank(false);
    if (checkForRoyals)
    {
      highestRank = (int)Card.ranks.ACE;
    }
    if (highestRank < (4 - wildCount))
    {
      return false;
    }
    int wildsLeft = wildCount;
    for (int i = highestRank; i > highestRank - 5; i--)
    {
      if (!HasRank((Card.ranks)i))
      {
        if (wildsLeft > 0)
        {
          wildsLeft--;
        }
        else
        {
          return false;
        }
      }
    }
    return true;
  }

  private bool HasRank(Card.ranks rank)
  {
    foreach (Card c in cardsLessWilds)
    {
      if (c.rank == rank)
      {
        return true;
      }
    }
    return false;
  }

  private int HighestRank(bool countWilds)
  {
    if (countWilds && wildCount > 0)
    {
      return (int)Card.ranks.ACE;
    }

    int highestRank = -1;
    foreach (Card c in cardsLessWilds)
    {
      if ((int)c.rank > highestRank)
      {
        highestRank = (int)c.rank;
      }
    }
    return highestRank;
  }
}
