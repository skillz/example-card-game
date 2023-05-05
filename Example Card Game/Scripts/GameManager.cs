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
  public TextMeshProUGUI scoreText;
  public GameObject PostGameMenu;
  public TextMeshProUGUI PostGameScore;
  public ScoreSummary scoreSummary;
  public bool isMatchRunning;

  private float timeRemaining;

  private void Awake()
  {
    scoreSummary = new ScoreSummary();
    Manager.game = this;
    timeRemaining = 100;
    UpdateTime();
  }

  private void Update()
  {
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

  public void GameFinished()
  {
    isMatchRunning = false;

    scoreSummary.AddScore(new ScoreItem((int)(timeRemaining * 2), timeRemaining));

    foreach (HandController hand in hands)
    {
      hand.SubmitHandScore();
    }
    PostGameMenu.SetActive(true);
    PostGameMenu.GetComponentInChildren<ScoreSummaryController>().DisplayScoreSummary(scoreSummary);
  }

  public void RestartGame()
  {
    PostGameMenu.SetActive(false);
    deckController.InitializeDeck();
    timeRemaining = 120;
    SetTime(timeRemaining);
    scoreSummary.ClearScore();
    scoreText.text = scoreSummary.GetScore().ToString();
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
}
