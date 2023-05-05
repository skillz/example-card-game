using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
  public CardGraphics cardGraphics;
  public RawImage image;

  private Card card;
  private Texture cardFace;

  public void SetCard(Card card)
  {
    this.card = card;
    if (card == null)
    {
      image.texture = null;
      image.color = Color.clear;
    }
    else
    {
      image.texture = cardGraphics.GetCardFaceSprite(card);
      image.color = Color.white;
    }
  }

  public Card GetCard()
  {
    return card;
  }
}
