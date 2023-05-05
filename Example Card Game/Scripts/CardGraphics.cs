using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardGraphics", menuName = "Card Game Example/CardGraphics", order = 1)]
public class CardGraphics : ScriptableObject
{
  public List<Texture> cardFaces;

  public Texture GetCardFaceSprite(Card card)
  {
    int cardIndex = ((int)card.rank * 4) + (int)card.suite;
    if(cardIndex >= 0 && cardIndex < 52)
    {
      return cardFaces[cardIndex];
    }
    return null;
  }
}
