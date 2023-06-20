using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
  public FadeController fadeOutController;
  public StartMenuManager startMenuManager;

  public void PlayButtonPressed()
  {
    fadeOutController.StartFade();
    Invoke("PostFadeAction", fadeOutController.fadeAnimationProfile.duration);
  }

  private void PostFadeAction()
  {
    startMenuManager.PlayButtonPressed();
  }
}
