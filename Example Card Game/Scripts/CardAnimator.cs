using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
  public AnimationProfile translateAnimationProfile;
  public AnimationProfile scaleAnimationProfile;
  public AnimationProfile rotationAnimationProfile;
  public bool isAnimating;

  private float startTime;
  private Vector2 startPostion, targetPosition;
  private Vector3 startScale, targetScale;
  private Quaternion startRotation, targetRotation;

  public void Animate(GameObject target)
  {
    isAnimating = true;

    RectTransform transform = gameObject.GetComponent<RectTransform>();
    RectTransform targetTransform = target.GetComponent<RectTransform>();

    startPostion = transform.anchoredPosition;
    startScale = transform.localScale;
    startRotation = transform.rotation;

    targetPosition = targetTransform.anchoredPosition;
    targetScale = targetTransform.localScale;
    targetRotation = targetTransform.rotation;

    startTime = Time.timeSinceLevelLoad;

  }

  public void Update()
  {
    if (isAnimating)
    {
      float timePassed = Time.timeSinceLevelLoad - startTime;

      RectTransform transform = gameObject.GetComponent<RectTransform>();

      transform.anchoredPosition = Vector2.LerpUnclamped(startPostion, targetPosition, translateAnimationProfile.animationCurve.Evaluate(timePassed / translateAnimationProfile.duration));

      transform.localScale = Vector3.LerpUnclamped(startScale, targetScale, scaleAnimationProfile.animationCurve.Evaluate(timePassed / scaleAnimationProfile.duration));

      transform.localRotation = Quaternion.LerpUnclamped(startRotation, targetRotation, rotationAnimationProfile.animationCurve.Evaluate(timePassed / rotationAnimationProfile.duration) );

      if (timePassed / translateAnimationProfile.duration > 1f && timePassed / scaleAnimationProfile.duration > 1f && timePassed / rotationAnimationProfile.duration > 1f)
      {
        isAnimating = false;
      }
    }

    
  }
}
