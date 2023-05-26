using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckController : MonoBehaviour
{
  public CardDeck deck;
  public CardController topCard;
  public TextMeshProUGUI deckText;

  public GameObject bottomCardsContainer;

  private List<CardController> bottomCards;

  public void Awake()
  {
    InitializeDeck();
  }

  public void InitializeDeck()
  {
    deck = new CardDeck();

    deck.Shuffle();
    deck.SetWild();

    InitializeBottomCards();
    ShowNextCard();
  }

  public void ShowNextCard()
  {
    if (deck.IsEmpty())
    {
      topCard.SetCard(null, Card.ranks.TWO);
      Debug.Log("Deck Is Empty - Ending Game");
      Manager.game.GameFinished();
      deckText.text = "0";
      return;
    }
    deckText.text = deck.CardsLeft().ToString();
    topCard.SetCard(deck.TakeTopCard(), deck.wild);

    DisplayBottomCards();
  }

  private void InitializeBottomCards()
  {
    bottomCards = new List<CardController>(bottomCardsContainer.GetComponentsInChildren<CardController>(true));
    bottomCards.Reverse();

    Vector3 bottomCardsPosition = bottomCards[0].GetComponent<RectTransform>().position;
    int ct = 0;

    foreach (CardController c in bottomCards)
    {
      ct++;
      c.GetComponent<RectTransform>().position = bottomCardsPosition + new Vector3(0, -1.2f * ct, 0);
    }

    DisplayBottomCards();
  }

  private void DisplayBottomCards()
  {
    int ct = 0;
    foreach (CardController c in bottomCards)
    {
      ct++;
      if (ct > deck.CardsLeft())
      {
        c.gameObject.SetActive(false);
      }
      else
      {
        c.gameObject.SetActive(true);
      }
    }

  }
}
