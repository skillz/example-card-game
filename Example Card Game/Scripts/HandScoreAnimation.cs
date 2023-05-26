using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandScoreAnimation : MonoBehaviour
{
  [Header("Hand Score Text")]
  public TextMeshProUGUI handScoreText;
  public GameObject handScoreTextTarget;

  [Header("Hand Type Text")]
  public TextMeshProUGUI handTypeText;
  public GameObject handTypeTextTarget;
  
  [Header("Cards")]
  public AnimationProfile cardScaleAnimationProfile;
  public ParticleSystem handScoreParticles;

  private HandController handController;
  private CardAnimator handScoreTextAnimator;
  private CardAnimator handTypeTextAnimator;
  private AnimationProfile tempCardScaleAnimationProfile;

  private void Awake()
  {
    //handScoreTextAnimator = handScoreText.GetComponent<CardAnimator>();
    //handTypeTextAnimator = handTypeText.GetComponent<CardAnimator>();
  }

  public void AnimateHandScore(HandController handController, float animationDuration)
  {
    this.handController = handController;
    Invoke("AnimationFinished", animationDuration);

    foreach (CardController c in handController.cardControllers)
    {
      CardAnimator animator = c.GetComponent<CardAnimator>();
      tempCardScaleAnimationProfile = animator.scaleAnimationProfile;
      animator.scaleAnimationProfile = cardScaleAnimationProfile;
      animator.Animate(c.GetComponent<RectTransform>().GetChild(0).gameObject);
    }

    handTypeText.GetComponent<CardAnimator>().Animate(handTypeTextTarget);

    handScoreText.GetComponent<CardAnimator>().Animate(handScoreTextTarget);
    handScoreText.text = "+" + handController.handScore.ToString();
  }

  public void AnimationFinished()
  {
    foreach (CardController c in handController.cardControllers)
    {
      CardAnimator animator = c.GetComponent<CardAnimator>();
      animator.scaleAnimationProfile = cardScaleAnimationProfile;
      animator.Reset();
    }

    handTypeText.GetComponent<CardAnimator>().Reset();

    handScoreText.GetComponent<CardAnimator>().Reset();
    handScoreText.text = null;
  }
}
