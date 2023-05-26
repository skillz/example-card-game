using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
  public DeckController deckController;
  public List<HandController> hands;
  public TextMeshProUGUI timeText;
  public ScoreTicker scoreTicker;
  public MatchCompleteFlow matchCompleteFlow;
  public ScoreSummary scoreSummary;
  public bool isMatchRunning;
  [HideInInspector] public float timeRemaining;

  private int matchTime = 90;

  private void Awake()
  {
    InitializeGameManager();
  }

  private void Update()
  {
    UpdateTime();
  }

  public void PlayAgain()
  {
    RestartGame();
  }

  public void GameFinished()
  {
    isMatchRunning = false;
    matchCompleteFlow.StartFlow();
    HandesEnabled(false);
  }

  private void InitializeGameManager()
  {
    scoreSummary = new ScoreSummary(scoreTicker);
    Manager.game = this;
    timeRemaining = matchTime;
    UpdateTime();
  }

  private void UpdateTime()
  {
    SetTime(timeRemaining);

    if (isMatchRunning)
    {
      timeRemaining -= Time.deltaTime;
    }
  }

  public void SetTime(float timeRemaining)
  {
    if (timeText)
    {
      TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
      if (timeRemaining >= 60f)
      {
        timeText.text = time.ToString("mm':'ss");
      }
      else if (timeRemaining < 60f && timeRemaining >= 0f)
      {
        timeText.text = time.ToString("ss':'ff");
      }
      else
      {
        timeText.text = "00:00";
        if (isMatchRunning)
        {
          GameFinished();
        }
      }
    }
  }

  private void RestartGame()
  {
    matchCompleteFlow.ResetFlow();
    deckController.InitializeDeck();
    timeRemaining = matchTime;
    SetTime(timeRemaining);
    scoreSummary.ClearScore();
    HandesEnabled(true);
  }

  private void HandesEnabled(bool enabled)
  {
    foreach (HandController hand in hands)
    {
      hand.handButton.enabled = enabled;
    }
  }
}
