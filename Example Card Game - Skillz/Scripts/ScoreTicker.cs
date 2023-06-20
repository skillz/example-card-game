using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTicker : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI newScoreText;
  public GameObject newScoreTarget;
  public float scoreTickDuration;

  private float timeOfAddedScore;
  private int shownScore;
  private int targetScore;
  private int originalScore;

  public void AddScore(int score, ScoreItem scoreItem = null, string prefix = "")
  {
    targetScore = score;
    timeOfAddedScore = Time.time;
    originalScore = shownScore;

    if (newScoreText && scoreItem != null)
    {
      ResetAnimation();
      newScoreText.text = prefix + "+" + scoreItem.GetScore().ToString();
      newScoreText.GetComponent<CardAnimator>().Animate(newScoreTarget);
    }
  }

  public void ShowScore(int score)
  {
    scoreText.text = score.ToString();
  }

  public void ResetScore()
  {
    scoreText.text = "0";
    targetScore = 0;
  }

  private void ResetAnimation()
  {
    newScoreText.GetComponent<CardAnimator>().Reset();
    newScoreText.text = null;
  }

  private void Update()
  {
    if (Time.time > timeOfAddedScore + scoreTickDuration)
    {
      shownScore = targetScore;
    }
    else
    {
      shownScore = (int)Mathf.Lerp((float)originalScore, (float)targetScore, (Time.time - timeOfAddedScore) / scoreTickDuration);
    }

    ShowScore(shownScore);
  }
}
