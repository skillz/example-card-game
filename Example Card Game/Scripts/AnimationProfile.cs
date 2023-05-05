using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationProfile", menuName = "Card Game Example/Animation Profile", order = 1)]
public class AnimationProfile : ScriptableObject
{
  public AnimationCurve animationCurve;
  public float duration;
}
