using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSummaryItemController : MonoBehaviour
{
  public TextMeshProUGUI amountText;
  public ScoreTicker scoreTicker;

  public GameObject animationTarget;
  
  public Hand.HandType handType;
  public bool isTimeScore;

  public void SetScore(int score, int amount = 0)
  {
    GetComponent<CanvasGroup>().alpha = 1f;
    scoreTicker.AddScore(score);
    amountText.text = "x" + amount.ToString();

    GetComponentInChildren<CardAnimator>().Animate(animationTarget);
  }

  public void Reset()
  {
    scoreTicker.ResetScore();
    GetComponentInChildren<CardAnimator>().Reset();
    GetComponent<CanvasGroup>().alpha = .3f;
  }
}
