using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchCompleteFlow : MonoBehaviour
{
  public CardAnimator endGameMessage;
  public GameObject endGameMessageTarget;
  public GameObject PostGameMenu;

  public void StartFlow()
  {
    Invoke("DisplayEndGameMessage", .6f);
    Invoke("ScoreHand1", 1.6f);
    Invoke("ScoreHand2", 2.4f);
    Invoke("ScoreHand3", 3.2f);
    Invoke("ScoreTimeBonus", 4.0f);
    Invoke("OpenScoreSummaryPanel", 4.8f);
    
  }

  public void ResetFlow()
  {
    PostGameMenu.SetActive(false);
    PostGameMenu.GetComponentInChildren<ScoreSummaryController>().Reset();
    endGameMessage.Reset();
  }

  private void DisplayEndGameMessage()
  {
    if(Manager.game.timeRemaining > 0)
    {
      endGameMessage.GetComponent<TextMeshProUGUI>().text = "Match Complete!";
    }
    else
    {
      endGameMessage.GetComponent<TextMeshProUGUI>().text = "Time's Up!";
    }
    endGameMessage.Animate(endGameMessageTarget);
  }

  private void ScoreHand1()
  {
    Manager.game.hands[0].SubmitHandScore();
  }

  private void ScoreHand2()
  {
    Manager.game.hands[1].SubmitHandScore();
  }

  private void ScoreHand3()
  {
    Manager.game.hands[2].SubmitHandScore();
  }

  private void ScoreTimeBonus()
  {
    Manager.game.scoreSummary.AddScore(new ScoreItem((int)(Manager.game.timeRemaining * 5)));
  }

  private void OpenScoreSummaryPanel()
  {
    PostGameMenu.SetActive(true);
    PostGameMenu.GetComponentInChildren<ScoreSummaryController>().DisplayScoreSummary(Manager.game.scoreSummary);
  }
}
