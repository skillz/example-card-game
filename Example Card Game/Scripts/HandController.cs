using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandController : MonoBehaviour
{
  public Hand hand;
  public HandScoreAnimation handScoreAnimation;
  public List<CardController> cardControllers;
  public GameObject cardTarget;
  public Button handButton;
  public TextMeshProUGUI handText;

  public int handScore = 0;

  public void Awake()
  {
    hand = new Hand();
  }

  public void AddCardToHand()
  {
    Manager.game.isMatchRunning = true;

    if (Manager.game.deckController.topCard.GetCard() == null)
    {
      return;
    }

    hand.AddCard(Manager.game.deckController.topCard.GetCard());

    UpdateHand();

    Manager.game.deckController.ShowNextCard();

    if (hand.cards.Count >= 5)
    {
      handButton.enabled = false;
      Invoke("SubmitHandScore", .5f);
    }
  }

  public void UpdateHand()
  {
    UpdateHandScore();

    UpdateCards();
  }

  private void UpdateCards()
  {
    for (int i = 0; i < 5; i++)
    {
      if (i == hand.cards.Count - 1)
      {
        RectTransform cardTransform = cardControllers[i].GetComponent<RectTransform>();
        cardTransform.rotation = Quaternion.Euler(0, 0, 0);
        cardTransform.localScale = new Vector3(1, 1, 1);
        cardTransform.position = Manager.game.deckController.topCard.GetComponent<RectTransform>().position;

        cardControllers[i].SetCard(hand.cards[i], Manager.game.deckController.deck.wild);

        cardTarget.GetComponent<RectTransform>().rotation = GetCardRotation(i);

        cardControllers[i].GetComponent<CardAnimator>().Animate(cardTarget);
      }
      else
      {
        if (hand.cards.Count > i)
        {
          cardTarget.GetComponent<RectTransform>().rotation = GetCardRotation(i);

          cardControllers[i].GetComponent<CardAnimator>().Animate(cardTarget);
        }
        else
        {
          cardControllers[i].SetCard(null, Card.ranks.TWO);
        }
      }
    }
  }

  private Quaternion GetCardRotation(int cardIndex)
  {
    float cardAngle = (((hand.cards.Count - 1) * 22.5f) * .5f) - (22.5f * cardIndex);
    return Quaternion.Euler(0, 0, cardAngle);
  }

  public void SubmitHandScore()
  {
    Manager.game.scoreSummary.AddScore(new ScoreItem(hand.handType, handScore, hand.highRank));
    handScoreAnimation.AnimateHandScore(this, 1.35f);
    Invoke("ClearHand", 1.35f);
  }

  private void ClearHand()
  {
    handButton.enabled = true;
    hand.ClearHand();
    handText.text = "";
    UpdateHand();
  }

  private void UpdateHandScore()
  {
    if (hand.handType == Hand.HandType.EMPTY)
    {
      handScore = 0;
      handText.text = "";
    }
    if (hand.handType == Hand.HandType.HIGH_CARD)
    {
      handScore = ((int)hand.highRank + 2) * 5;
      string cardRankName = (hand.highRank).ToString();
      cardRankName = cardRankName.ToLower();
      cardRankName = char.ToUpper(cardRankName[0]) + cardRankName.Substring(1);
      handText.text = cardRankName + " High";
    }
    if (hand.handType == Hand.HandType.TWO_OF_A_KIND)
    {
      handScore = 100;
      handText.text = "Two of a Kind";
    }
    if (hand.handType == Hand.HandType.TWO_PAIR)
    {
      handScore = 250;
      handText.text = "Two Pair";
    }
    if (hand.handType == Hand.HandType.THREE_OF_A_KIND)
    {
      handScore = 350;
      handText.text = "Three of a Kind";
    }
    if (hand.handType == Hand.HandType.STRAIGHT)
    {
      handScore = 400;
      handText.text = "Straight";
    }
    if (hand.handType == Hand.HandType.FLUSH)
    {
      handScore = 500;
      handText.text = "Flush";
    }
    if (hand.handType == Hand.HandType.FULL_HOUSE)
    {
      handScore = 600;
      handText.text = "Full House";
    }
    if (hand.handType == Hand.HandType.FOUR_OF_A_KIND)
    {
      handScore = 800;
      handText.text = "Four of a Kind";
    }
    if (hand.handType == Hand.HandType.STRAIGHT_FLUSH)
    {
      handScore = 1000;
      handText.text = "Straight Flush";
    }
    if (hand.handType == Hand.HandType.ROYAL_FLUSH)
    {
      handScore = 1200;
      handText.text = "Royal Flush";
    }
  }
}
