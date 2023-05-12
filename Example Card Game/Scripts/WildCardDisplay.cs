using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WildCardDisplay : MonoBehaviour
{
  public TextMeshProUGUI wildCardText;

  private Dictionary<Card.ranks, string> ranksToString;

  private void Awake()
  {
    ranksToString = new Dictionary<Card.ranks, string>();
    ranksToString.Add(Card.ranks.TWO, "2");
    ranksToString.Add(Card.ranks.THREE, "3");
    ranksToString.Add(Card.ranks.FOUR, "4");
    ranksToString.Add(Card.ranks.FIVE, "5");
    ranksToString.Add(Card.ranks.SIX, "6");
    ranksToString.Add(Card.ranks.SEVEN, "7");
    ranksToString.Add(Card.ranks.EIGHT, "8");
    ranksToString.Add(Card.ranks.NINE, "9");
    ranksToString.Add(Card.ranks.TEN, "10");
    ranksToString.Add(Card.ranks.JACK, "J");
    ranksToString.Add(Card.ranks.QUEEN, "Q");
    ranksToString.Add(Card.ranks.KING, "K");
    ranksToString.Add(Card.ranks.ACE, "A");
  }

  private void Update()
  {
    wildCardText.text = ranksToString[Manager.game.deckController.deck.wild];
  }
}
