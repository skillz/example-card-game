using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
  public string gameSceneName;

  public void PlayButtonPressed()
  {
    SceneManager.LoadScene(gameSceneName);
  }
}
