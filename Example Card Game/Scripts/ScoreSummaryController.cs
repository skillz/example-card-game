using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSummaryController : MonoBehaviour
{
  public List<ScoreSummaryItemController> scoreSummaryItems;
  public ScoreSummaryItemController totalScoreItem;

  public void DisplayScoreSummary(ScoreSummary scoreSummary)
  {
    foreach (ScoreSummaryItemController item in scoreSummaryItems)
    {
      if (scoreSummary.scoreItems.ContainsKey(item.handType))
      {
        ScoreItem scoreItem = scoreSummary.scoreItems[item.handType];
        item.SetScore(scoreItem.GetScore(), scoreItem.GetAmount());
      }
    }
    totalScoreItem.SetScore(scoreSummary.GetScore());
  }
}
