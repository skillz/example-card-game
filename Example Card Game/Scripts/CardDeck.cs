using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck
{
  List<Card> deck;
  public Card.ranks wild;

  public CardDeck()
  {
    deck = new List<Card>();
    for (int s = 0; s < 4; s++)
    {
      for (int r = 0; r < 13; r++)
      {
        Card.ranks rank = (Card.ranks)r;
        Card.suites suite = (Card.suites)s;
        
        deck.Add(new Card(rank, suite));
      }
    }
  }

  public Card TakeTopCard()
  {
    if (IsEmpty())
      return null;
    Card nextCard = deck[0];
    deck.RemoveAt(0);
    return nextCard;
  }

  public bool IsEmpty()
  {
    return CardsLeft() == 0;
  }

  public int CardsLeft()
  {
    return deck.Count;
  }

  public void Shuffle()
  {
    for (int cardIndex = 0; cardIndex < deck.Count; cardIndex++)
    {
      int swapIndex = UnityEngine.Random.Range(0, deck.Count);
      Swap(cardIndex, swapIndex);
    }
  }

  public void SetWild()
  {
    wild = (Card.ranks)UnityEngine.Random.Range(0, 12);
  }

  public override string ToString()
  {
    string s = "CardDeck:{";
    foreach (Card card in deck)
    {
      s += (card.ToString() + ", ");
    }
    s.Remove(s.Length - 2, 2);
    s += "}";

    return s;
  }

  private void Swap(int original, int other)
  {
    Card temp = deck[original];
    deck[original] = deck[other];
    deck[other] = temp;
  }
}
