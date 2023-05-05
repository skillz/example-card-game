using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAnimationController : MonoBehaviour
{
  public FadeController fadeController;

  public CardAnimator buttonAnimator;
  public CardAnimator titleAnimator1, titleAnimator2, titleAnimator3;
  public List<CardAnimator> cardAnimators;

  public GameObject titleTarget1, titleTarget2, titleTarget3;
  public GameObject buttonTarget;
  public List<GameObject> cardTargets;

  private void Start()
  {
    buttonAnimator.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    titleAnimator1.GetComponent<RectTransform>().position = titleAnimator1.GetComponent<RectTransform>().position + new Vector3(0, 1500, 0);
    titleAnimator2.GetComponent<RectTransform>().position = titleAnimator2.GetComponent<RectTransform>().position + new Vector3(-1500, 0, 0);
    titleAnimator3.GetComponent<RectTransform>().position = titleAnimator3.GetComponent<RectTransform>().position + new Vector3(1500, 0, 0);

    foreach (CardAnimator c in cardAnimators)
    {
      c.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
    }

    Invoke("FadeIn", .3f);
    Invoke("AnimateButton", 1.6f);
    Invoke("PulseButton", 2.3f);

    Invoke("AnimateTitle1", .4f);
    Invoke("AnimateTitle2", .8f);
    Invoke("AnimateTitle3", 1.2f);

    Invoke("AnimateCards", .8f);
  }

  private void FadeIn()
  {
    fadeController.StartFade();
  }

  private void AnimateTitle1()
  {
    titleAnimator1.Animate(titleTarget1);
  }

  private void AnimateTitle2()
  {
    titleAnimator2.Animate(titleTarget2);
  }

  private void AnimateTitle3()
  {
    titleAnimator3.Animate(titleTarget3);
  }

  private void AnimateButton()
  {
    buttonAnimator.Animate(buttonTarget);
  }

  private void PulseButton()
  {
    buttonAnimator.GetComponent<ButtonAnimator>().enabled = true;
  }

  private void AnimateCards()
  {
    for(int i = 0; i < cardAnimators.Count; i++)
    {
      cardAnimators[i].Animate(cardTargets[i]);
    }
  }
}
