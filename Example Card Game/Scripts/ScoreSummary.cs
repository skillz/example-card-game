using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSummary
{
  public Dictionary<Hand.HandType, ScoreItem> scoreItems;

  public ScoreSummary()
  {
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
  }

  public void ClearScore()
  {
    scoreItems.Clear();
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
  Card.ranks highRank;
  int amount;
  int score;
  bool isTimeScore;

  public ScoreItem(int score, float timeRemaining)
  {
    this.isTimeScore = true;
    this.score = (int)timeRemaining;
    this.handType = Hand.HandType.EMPTY;
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
