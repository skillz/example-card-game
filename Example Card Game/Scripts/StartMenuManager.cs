using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
  public string gameSceneName;

  public void StartButtonPressed()
  {
    SceneManager.LoadScene(gameSceneName);
  }
}
