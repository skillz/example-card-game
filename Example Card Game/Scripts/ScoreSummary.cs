using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSummary
{
  public Dictionary<Hand.HandType, ScoreItem> scoreItems;

  private ScoreTicker scoreTicker;

  public ScoreSummary(ScoreTicker scoreText)
  {
    this.scoreTicker = scoreText;
    scoreItems = new Dictionary<Hand.HandType, ScoreItem>();
  }

  public void AddScore(ScoreItem scoreItem)
  {
    if (scoreItems.ContainsKey(scoreItem.handType))
    {
      scoreItems[scoreItem.handType].AddScore(scoreItem.GetScore());
    }
    else
    {
      scoreItems.Add(scoreItem.handType, scoreItem);
    }

    if (scoreItem.isTimeScore)
    {
      scoreTicker.AddScore(GetScore(), scoreItem, "Time Bonus ");
    }
    else
    {
      scoreTicker.AddScore(GetScore(), scoreItem);
    }
  }

  public void ClearScore()
  {
    scoreItems.Clear();
    scoreTicker.ResetScore();
  }

  public int GetScore()
  {
    int score = 0;
    foreach (Hand.HandType handType in scoreItems.Keys)
    {
      score += scoreItems[handType].GetScore();
    }
    return score;
  }
}

public class ScoreItem
{
  public Hand.HandType handType;
  public bool isTimeScore;

  private Card.ranks highRank;
  private int amount;
  private int score;

  public ScoreItem(int score)
  {
    this.score = score;
    this.handType = Hand.HandType.EMPTY;
    this.isTimeScore = true;
  }

  public ScoreItem(Hand.HandType handType, int score, Card.ranks highRank = Card.ranks.TWO)
  {
    this.handType = handType;
    this.highRank = highRank;
    this.score = score;
    this.amount++;
  }

  public void AddScore(int score)
  {
    this.score += score;
    this.amount++;
  }

  public int GetScore()
  {
    return score;
  }

  public int GetAmount()
  {
    return amount;
  }
}
