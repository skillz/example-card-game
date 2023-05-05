using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSummaryItemController : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI amountText;
  public Hand.HandType handType;
  public bool isTimeScore;

  public void SetScore(int score, int amount = 0)
  {
    scoreText.text = score.ToString();
    amountText.text = "x" + amount.ToString(); 
  }
}
