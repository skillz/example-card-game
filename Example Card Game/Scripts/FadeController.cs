using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeController : MonoBehaviour
{
  [SerializeField] private bool isFadeIn;
  [SerializeField] private bool fadeOnEnable;
  [SerializeField] private float fadeDuration;
  [SerializeField] private CanvasGroup canvasGroup;
  [SerializeField] private UnityEvent onFadeFinished;
  public AnimationProfile fadeAnimationProfile;

  private bool isfading;
  private float fadeStartTime;

  public void StartFade()
  {
    if (isFadeIn)
    {
      canvasGroup.alpha = 1f;
    }
    else
    {
      canvasGroup.alpha = 0;
    }

    isfading = true;
    fadeStartTime = Time.realtimeSinceStartup;

  }
  public void EndFade()
  {
    isfading = false;
    if (isFadeIn)
    {
      canvasGroup.alpha = 0f;
    }
    else
    {
      canvasGroup.alpha = 1f;
    }
    onFadeFinished.Invoke();
  }

  private void OnEnable()
  {
    if (fadeOnEnable)
    {
      StartFade();
    }
  }

  private void Update()
  {
    if (isfading)
    {
      if (Time.realtimeSinceStartup - fadeStartTime > fadeDuration || fadeDuration == 0)
      {
        EndFade();
        return;
      }
      if (isFadeIn)
      {
        canvasGroup.alpha = fadeAnimationProfile.animationCurve.Evaluate( 1 - (Time.realtimeSinceStartup - fadeStartTime) / fadeDuration );
      }
      else
      {
        canvasGroup.alpha = fadeAnimationProfile.animationCurve.Evaluate( (Time.realtimeSinceStartup - fadeStartTime) / fadeDuration );
      }
    }
  }
}

