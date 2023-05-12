using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSummaryController : MonoBehaviour
{
  public List<ScoreSummaryItemController> scoreSummaryItems;
  public ScoreSummaryItemController totalScoreItem;
  public Button playAgainButton;
  public GameObject playAgainButtonTarget;

  private ScoreSummary scoreSummary;
  private int scoreSummaryIndex;

  public void DisplayScoreSummary(ScoreSummary scoreSummary)
  {
    this.scoreSummary = scoreSummary;
    scoreSummaryIndex = 0;

    DisplayNextScoreItem();
  }

  public void Reset()
  {
    foreach (ScoreSummaryItemController item in scoreSummaryItems)
    {
      item.Reset();
    }
    playAgainButton.GetComponent<CardAnimator>().Reset();
    playAgainButton.GetComponent<ButtonAnimator>().enabled = false;
  }

  public void DisableButton()
  {
    playAgainButton.enabled = false;
  }

  private void DisplayNextScoreItem()
  {
    ScoreSummaryItemController itemController;
    do
    {
      itemController = scoreSummaryItems[scoreSummaryIndex];
      scoreSummaryIndex++;
    } while (!scoreSummary.scoreItems.ContainsKey(itemController.handType) && scoreSummaryIndex < scoreSummaryItems.Count);

    if (scoreSummaryIndex >= scoreSummaryItems.Count)
    {
      totalScoreItem.SetScore(scoreSummary.GetScore());
      Invoke("EnableButton", .8f);
      return;
    }

    ScoreItem scoreItem = scoreSummary.scoreItems[itemController.handType];
    itemController.SetScore(scoreItem.GetScore(), scoreItem.GetAmount());
    Invoke("DisplayNextScoreItem", .8f);
  }

  private void EnableButton()
  {
    playAgainButton.enabled = true;
    playAgainButton.GetComponent<CardAnimator>().Animate(playAgainButtonTarget);
    Invoke("PulseButton", .7f);
  }

  private void PulseButton()
  {
    playAgainButton.GetComponent<ButtonAnimator>().enabled = true;
  }
}
