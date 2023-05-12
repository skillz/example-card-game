using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
  public CardGraphics cardGraphics;
  public RawImage image;
  public Image wildCardBorder;

  private Card card;
  private Texture cardFace;

  public void SetCard(Card card, Card.ranks wildRank)
  {
    this.card = card;
    if (card == null)
    {
      image.texture = null;
      image.color = Color.clear;
      wildCardBorder.gameObject.SetActive(false);
    }
    else
    {
      image.texture = cardGraphics.GetCardFaceSprite(card);
      image.color = Color.white;
      ShowWildBorder(wildRank);
    }
    
  }

  public void ShowWildBorder(Card.ranks wildRank)
  {
    if (card.rank == wildRank)
    {
      wildCardBorder.gameObject.SetActive(true);
    }
    else
    {
      wildCardBorder.gameObject.SetActive(false);
    }
  }

  public Card GetCard()
  {
    return card;
  }
}
