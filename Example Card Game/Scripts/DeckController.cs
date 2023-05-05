using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckController : MonoBehaviour
{
  public CardDeck deck;
  public CardController topCard;
  public CardController wildCard;
  public TextMeshProUGUI deckText;

  public void Awake()
  {
    InitializeDeck();
  }

  public void InitializeDeck()
  {
    deck = new CardDeck();

    deck.Shuffle();
    deck.SetWild();

    deckText.text = deck.CardsLeft().ToString();
    topCard.SetCard(deck.TakeTopCard());

    wildCard.SetCard(new Card(deck.wild, Card.suites.SPADES));
  }

  public void ShowNextCard()
  {
    if (deck.IsEmpty())
    {
      topCard.SetCard(null);
      Debug.Log("Deck Is Empty - Ending Game");
      Manager.game.GameFinished();
      deckText.text = "0";
      return;
    }
    deckText.text = deck.CardsLeft().ToString();
    topCard.SetCard(deck.TakeTopCard());
  }
}
